using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WPFood.Modeles;
using WPFood.Outils;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace WPFood.VuesModeles.VM_Serveur
{
    internal class VM_serveurPayer : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }
        #endregion 

        
        public VM_serveurPayer(Table table)
        {
            Table = table;
            InitClients();
            ItemsClient = new ObservableCollection<ItemClient>();
        }

        public void AddItemClient(Client client)
        {
            var query = QueryCommandesClient(client);

            //init des items dans ma liste de tout les items
            foreach (var ccItem in query)
            {
                var itemC = new ItemClient(ccItem.item, ccItem.Quantite);

                if (!ExistsInArrayItemClient(itemC, ItemsClient))
                {
                    ItemsClient.Add(itemC);
                    AddToFacture(itemC);
                }
            }
        }

        public void RemoveItemClient(Client client)
        {
            var query = QueryCommandesClient(client);

            //init des items dans ma liste de tout les items
            foreach (var ccItem in query)
            {
                var itemC = new ItemClient(ccItem.item, ccItem.Quantite);

                if (ExistsInArrayItemClient(itemC, ItemsClient))
                {
                    ItemsClient.Remove(ItemsClient.SingleOrDefault(i => i.Nom == itemC.Nom));
                    RemoveFromFacture(itemC);
                }
            }
        }
        private bool ExistsInArrayItemClient(ItemClient item, ObservableCollection<ItemClient> array)
        {
            foreach (var itemP in array)
            {
                if (itemP.Nom == item.Nom)
                {
                    return true;
                }
            }
            return false;
        }

        private void RemoveFromClients(List<int> ids)
        {
            List<Client> clientToRemove = new List<Client>();

            //Remove client to observable collection of Clients once their Commande is passed.
            clientToRemove = Clients.Where(x => ids.Any(id => x.Id == id)).ToList();

            foreach (var client in clientToRemove)
            {
                Clients.Remove(client);
                ServeurGlobale.IdsclientsSelectiones.Remove(client.Id);
            }
        }

        #region query
        private void InitClients()
        {
            Clients = new ObservableCollection<Client>();
            List<int> clientsIds = new List<int>();

            var requete = from client in OutilsEF.WPFoodContext!.Clients where Table.Id == client.IdTable select client;

            foreach (Client item in requete)
            {
                clientsIds.Add(item.Id);
            }

            List<CommandeClient> commande = RetrieveAllCommandeNonPayeFromClients(clientsIds);

            foreach (var item  in commande)
            {
                //Si le client n,est pas déja contenu dans la liste.
                if (!Clients.Any(i => i.Id == item.Client.Id))
                    Clients.Add(item.Client);
            }

        }

        //Requete pour aller chercher toutes les commande d'un client et les commandeclientitems
        private IQueryable<CommandeClientItem> QueryCommandesClient(Client client)
        {
            var query =
                from commande in OutilsEF.WPFoodContext?.CommandesClients
                where commande.Client == client
                where commande.EstTermine
                where !commande.EstPaye
                join CCItem in OutilsEF.WPFoodContext?.CommandesClientsItems! on commande equals CCItem.CommandeClient
                select CCItem;

            return query;
        }

        //reuqete pour aller chercher les commandes des clients selectionnées
        private List<CommandeClient> QueryCommandesClients()
        {
            try
            {
                var query = OutilsEF.WPFoodContext?.CommandesClients
                    .Include(comm => comm.CommandeClientItems)
                    .Include(comm => comm.Client)
                    .Where(e => ServeurGlobale.IdsclientsSelectiones.Any(id => e.Client.Id == id))
                    .Where(comm => !comm.EstPaye)
                    .Where(comm => comm.EstTermine)
                    .ToList();
                
                return query!; 

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //retreieve toute les commandes non payé et terminé par le cuisinier des clients donné par la liste d'id en parametre.
        private List<CommandeClient> RetrieveAllCommandeNonPayeFromClients(List<int> ids)
        {
            var query = 
                OutilsEF.WPFoodContext.CommandesClients
                .Where(com => ids
                .Any(id => id == com.Client.Id))
                .Where(com => !com.EstPaye)
                .Where(com => com.EstTermine)
                .ToList();

            return query;
        }

        #endregion

        #region Facture
        private void RemoveFromFacture(ItemClient item)
        {
            if (ItemsClient.Count == 0)
                SousTotal = 0.00;
            else
                SousTotal = SousTotal - (item.Quantite * item.Prix);

            CalculTaxes();
            CalculTotal();
        }

        private void AddToFacture(ItemClient item)
        {
            SousTotal = SousTotal + (item.Quantite * item.Prix);
            CalculTaxes();
            CalculTotal();
        }
        private void CalculTaxes()
        {

            MontantTPS = SousTotal * Taxes.TPS;
            MontantTVQ = SousTotal * Taxes.TVQ;
        }

        private void CalculTotal()
        {
            Total = SousTotal + MontantTPS + MontantTVQ;
        }

        public void Paiement()
        {
            List<int> ids = ServeurGlobale.IdsclientsSelectiones;
            if (ids.Count == 0)
            {
                MessageBox.Show("Vous devez choisir des clients pour procéder au paiement.", "Aucun client choisi", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var query = QueryCommandesClients();
            if (query != null)
            {
                foreach (CommandeClient commande in query)
                {
                    commande.EstPaye = true;
                }
            }

            //Création en BD de la facture.
            Facture facture = new Facture(query, DateTime.Now, SousTotal, MontantTPS, MontantTVQ, Total);
            OutilsEF.WPFoodContext.Factures.Add(facture);

            //Clear le UI
            RemoveFromClients(ids);
            ItemsClient.Clear();
            ResetMontantFacture();
 
            //Sauvegarder en BD
            OutilsEF.WPFoodContext.SaveChanges();
            MessageBox.Show("La commande a bien été payé.", "Paiement réussis !", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ResetMontantFacture()
        {
            SousTotal = 0.00;
            CalculTaxes();
            CalculTotal();
        }
        #endregion

        #region properties
        private Table _table { get; set; }
        public Table Table
        {
            get { return _table; }
            set
            {
                _table = value;
                if (_table == null)
                    return;
                OnPropertyChanged("Table");
            }
        }

        private ObservableCollection<Client> _clients { get; set; }
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                if (_clients == null)
                    return;
                OnPropertyChanged("Clients");
            }
        }

        private ObservableCollection<ItemClient> _itemsClient { get; set; }
        public ObservableCollection<ItemClient> ItemsClient
        {
            get { return _itemsClient; }
            set
            {
                _itemsClient = value;
                if (_itemsClient == null)
                    return;
                OnPropertyChanged("ItemsClient");
            }
        }

        private double _sousTotal { get; set; }
        public double SousTotal
        {
            get { return _sousTotal; }
            set
            {
                _sousTotal = value;
                if (_sousTotal == null)
                    return;
                OnPropertyChanged("SousTotal");
            }
        }

        private double _montantTPS { get; set; }
        public double MontantTPS
        {
            get { return _montantTPS; }
            set
            {
                _montantTPS = value;
                if (_montantTPS == null)
                    return;
                OnPropertyChanged("MontantTPS");
            }
        }

        private double _montantTVQ { get; set; }
        public double MontantTVQ
        {
            get { return _montantTVQ; }
            set
            {
                _montantTVQ = value;
                if (_montantTVQ == null)
                    return;
                OnPropertyChanged("MontantTVQ");
            }
        }

        private double _total { get; set; }
        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                if (_total == null)
                    return;
                OnPropertyChanged("Total");
            }
        }

        #endregion
    }
}
