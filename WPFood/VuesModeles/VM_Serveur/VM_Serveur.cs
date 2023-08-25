using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFood.Modeles;
using WPFood.Outils;

namespace WPFood.VuesModeles.VM_Serveur
{
    public class VM_Serveur : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }
        #endregion 

        public ICommand cmdEnregistrer { get; set; }

        public VM_Serveur()
        {
            InitTable();
            InitClient();
            InitItemsMenu();

            cmdEnregistrer = new Commande(CmdEnregistrer);
        }

        #region Init
        public void InitTable()
        {
            Tables = new ObservableCollection<Table>();

            var tRequete = from table in OutilsEF.WPFoodContext!.Tables where table.Etat == "Occupée" select table;
            if (tRequete != null)
            {
                foreach (Table table in tRequete)
                {
                    Tables!.Add(table);
                }
            }
            if (Tables.Count > 0)
            {
                //Au départ de l'application, la table sélectionné est la première table de la liste de table
                TableSelectionnee = Tables[0];
            }        

        }

        private void InitClient()
        {
            //Init les clients seulement s'il y a une table seletionnee
            if (TableSelectionnee != null)
            {
                Clients = new ObservableCollection<Client>();

                //requete pour aller chercher les clients
                var requete = from client in OutilsEF.WPFoodContext?.Clients where client.IdTable == TableSelectionnee.Id && client.EstPasse == false select client;

                //ajoute les clients de la recherche dans la liste de client.
                foreach (var client in requete)
                {
                    Clients.Add(client);
                }

                //Définie le client Selectionne avec le premier client de la liste par défaut.
                if (Clients.Count > 0)
                {
                    ClientSelectionne = Clients[0];
                }
                else
                {
                    ClientSelectionne = null;
                }
            }
        }

        private void InitItemsMenu()
        {
            ItemsMenu = new ObservableCollection<Item>();
            try
            {
                var requete = from item in OutilsEF.WPFoodContext?.Items select item;
                foreach (Item item in requete)
                {
                    ItemsMenu.Add(item);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public void InitCommandesDuClient()
        {
            CommandesDuClient = new ObservableCollection<CommandeClient>();

            try
            {
                var query =
                    OutilsEF.WPFoodContext.CommandesClients
                    .Include(com => com.Client)
                    .Include(com => com.CommandeClientItems)
                    .Where(com => com.Client.Id == ClientSelectionne.Id)
                    .Where(com => com.CommandeClientItems.Count > 0);

                query = query.OrderByDescending(c => c.Id);

                if (query != null)
                {
                    foreach (CommandeClient commande in query)
                    {
                        CommandesDuClient.Add(commande);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        #endregion


        public void AddItemClient(string nomItemClient)
        {
            Item? item = OutilsEF.WPFoodContext?.Items?.FirstOrDefault(i => i.Nom == nomItemClient);

            bool itemExists = ItemsClient.Any(ic => ic.Nom == item!.Nom);
            if (itemExists)
            {
                ItemClient? ic = ItemsClient.FirstOrDefault(x => x.Nom == item!.Nom);
                if (ic != null)
                {
                    ic.Quantite++;
                    refreshList();
                }
                else
                {
                    MessageBox.Show("Erruer l.107 VM_Serveur, ic == null");
                }
            }
            else
            {
                ItemsClient.Add(new ItemClient(item!));
                refreshList();
            }
        }

        public void AddNoteToItem(string nomItemClient,string note)
        {
            foreach (var item in ItemsClient)
            {
                if(item.Nom == nomItemClient)
                {
                    item.Note = note;
                    refreshList();
                    break;
                }
            }
        }

        public void RemoveItemClient(ItemClient itemClient)
        {
            if (itemClient.Quantite > 1)
            {
                itemClient.Quantite--;
                refreshList();
            }
            else
            {
                itemClient.Quantite = 0;
                ItemsClient.Remove(itemClient);
            }

        }

        private void refreshList()
        {
            if (ItemsClient == null) return;

            List<ItemClient> itemsClientTemp = ItemsClient.ToList();
            ItemsClient.Clear();
            foreach (var i in itemsClientTemp)
            {
                ItemsClient.Add(i);
            }
        }

        //rafraichit la bd avec les items de la BD
        public void refreshItems()
        {
            if (ItemsMenu == null) return;

            ItemsMenu.Clear();
            //Remet chaque item de la bd dans la liste d'itemsMenu
            var requete = from item in OutilsEF.WPFoodContext?.Items select item;
            foreach (var item in requete)
            {
                ItemsMenu.Add(item);
            }
        }

        #region TreeView
        public void RemoveCommandeClientItem(CommandeClientItem CCItem)
        {
            CommandeClient commande = CCItem.CommandeClient;

            if (CCItem.Quantite > 1)
            {
                CCItem.Quantite--;
                refreshTreeView();
            }
            else
            {
                CCItem.Quantite = 0;
                commande.CommandeClientItems.Remove(CCItem);

                if (commande.CommandeClientItems.Count == 0)
                {
                    CommandesDuClient.Remove(commande);
                    OutilsEF.WPFoodContext.CommandesClients.Remove(commande);
                    OutilsEF.WPFoodContext.SaveChanges();
                }


                //trouver la commande en bd
                CommandeClient comm = OutilsEF.WPFoodContext.CommandesClients.FirstOrDefault(c => c.Id == commande.Id);
                if (comm != null && comm.EstTermine)
                {
                    //Si j'arrive pour modifier la commande, et que la commande est deja terminer
                    //Donc elle a été terminer par le cuisinier avant que moi je puisse le voir
                    //je return et met message d'erreur, c'est juste un double check up si jamais une situation assez rare se produit

                    MessageBox.Show("Cette commande à déjà été modifié", "Déjà modifié", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                    //InitCommandesDuClient();
                }

                refreshTreeView();
            }
        }

        public void refreshTreeView()
        {
            if (CommandesDuClient == null) return;

            List<CommandeClient> commandesTemp = CommandesDuClient.ToList();
            CommandesDuClient.Clear();
            foreach (var com in commandesTemp)
            {
                CommandesDuClient.Add(com);
            }
        }
        #endregion

        private void CmdEnregistrer(object sender)
        {
            if (ItemsClient == null) return;

            if (ItemsClient.Count == 0 )
            {
                MessageBox.Show("Vous devez ajouter des items avant d'enregistrer la commande du client", "Erreur, pas d'items", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //commence par me faire une commandeClient
            CommandeClient commandeClient = new CommandeClient(ClientSelectionne);
            commandeClient.CommandeClientItems = new List<CommandeClientItem>();
            commandeClient.Date = DateTime.Now;

            //Itère dans les items de la commande du client
            foreach (var itemClient in ItemsClient)
            {
                var item = OutilsEF.WPFoodContext?.Items?.FirstOrDefault(i => i.Nom == itemClient.Nom);
                if (item != null)
                {
                    CommandeClientItem CCItem = new CommandeClientItem(item, commandeClient, itemClient.Quantite,itemClient.Note);
                    item.CommandeClientsItem = new List<CommandeClientItem>();
                    item.CommandeClientsItem.Add(CCItem);
                    commandeClient.CommandeClientItems.Add(CCItem);
                }
            }
            OutilsEF.WPFoodContext?.SaveChanges();
            //clear la liste d'items du client
            ItemsClient = new ObservableCollection<ItemClient>();
            InitCommandesDuClient();

            //Afficher au client que la commande a été enregistré
            MessageBox.Show($"Commande enregistré pour le {ClientSelectionne}", "Commande enregistré", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        #region properties
        private ObservableCollection<Table> _tables { get; set; }
        public ObservableCollection<Table> Tables
        {
            get
            {
                return _tables;
            }
            set
            {
                _tables = value;
                if (_tables == null)
                    return;
                OnPropertyChanged("Tables");
            }
        }

        private ObservableCollection<Client> _clients { get; set; }
        public ObservableCollection<Client> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                _clients = value;
                if (_clients == null)
                    return;
                OnPropertyChanged("Clients");
            }
        }

        private Table _tableSelectionnee { get; set; }
        public Table TableSelectionnee
        {
            get
            {
                return _tableSelectionnee;
            }
            set
            {
                _tableSelectionnee = value;
                if (_tableSelectionnee == null)
                    return;
                OnPropertyChanged("TableSelectionnee");
                InitClient();
            }
        }

        private Client _clientSelectionne { get; set; }
        public Client ClientSelectionne
        {
            get
            {
                return _clientSelectionne;
            }
            set
            {
                _clientSelectionne = value;
                if (_clientSelectionne == null)
                {
                    ItemsClient = new ObservableCollection<ItemClient>();
                    HeaderCommandeClient = "Client";
                    return;
                }
                OnPropertyChanged("ClientSelectionne");
                ItemsClient = new ObservableCollection<ItemClient>();
                HeaderCommandeClient = $"Client #{value.NumTable} ";
                InitCommandesDuClient();
            }
        }

        private ObservableCollection<Item> _itemsMenu { get; set; }
        public ObservableCollection<Item> ItemsMenu
        {
            get
            {
                return _itemsMenu;
            }
            set
            {
                _itemsMenu = value;
                if (_itemsMenu == null)
                    return;
                OnPropertyChanged("ItemsMenu");
            }
        }

        private ObservableCollection<ItemClient> _itemsClient { get; set; }
        public ObservableCollection<ItemClient> ItemsClient
        {
            get
            {
                return _itemsClient;
            }
            set
            {
                _itemsClient = value;
                if (_itemsClient == null)
                    return;
                OnPropertyChanged("ItemsClient");
            }
        }

        private string _headerCommandeClient { get; set; }
        public string HeaderCommandeClient
        {
            get
            {
                return _headerCommandeClient;
            }
            set
            {
                _headerCommandeClient = value;
                if (_headerCommandeClient == null)
                    return;
                OnPropertyChanged("HeaderCommandeClient");
            }
        }

        private ObservableCollection<CommandeClient> _commandesDuClient { get; set; }
        public ObservableCollection<CommandeClient> CommandesDuClient
        {
            get
            {
                return _commandesDuClient;
            }
            set
            {
                _commandesDuClient = value;
                if (_commandesDuClient == null)
                    return;
                OnPropertyChanged("CommandesDuClient");
            }
        }

        private ObservableCollection<CommandeClientItem> _itemsDeLaCommande { get; set; }
        public ObservableCollection<CommandeClientItem> ItemsDeLaCommande
        {
            get
            {
                return _itemsDeLaCommande;
            }
            set
            {
                _itemsDeLaCommande = value;
                if (_itemsDeLaCommande == null)
                    return;
                OnPropertyChanged("ItemsDeLaCommande");
            }
        }

        public string CommandeDuClientCouleur { get; set; }

        #endregion
    }
}