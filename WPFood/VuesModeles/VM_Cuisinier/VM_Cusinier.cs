using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFood.Modeles;
using WPFood.Outils;
using WPFood.Vues.UC_Cuisinier;

namespace WPFood.VuesModeles.VM_Cuisinier
{
    internal class VM_Cusinier : INotifyPropertyChanged
    {
        public VM_Cusinier()
        {
            ListeCommandeClient = new ObservableCollection<CommandeClient>();
            InitCommandeClient();
            InitCommandeCuisinier();

        }

        public void GenererCommandeCuisinier(UC_MainPageCuisinier ucMainPageCui)
        {
            if (ucMainPageCui != null)
            {
                ucMainPageCui.stackCommande.Children.Clear();
                InitCommandeClient();
                InitCommandeCuisinier();
            }
                

            if (ListeCommandeCuisinier!.Count > 0)
            {
                
                foreach (commandeCuisinier ccuisinier in ListeCommandeCuisinier)
                {
                    ucMainPageCui.stackCommande.Children.Add(creationCommandeCuisinier(ccuisinier));                   
                }
            }
            monUC_Cuisinier = ucMainPageCui;
        }

        public UserControl creationCommandeCuisinier(commandeCuisinier ccui)
        {
            UserControl uc_commentaire = new UC_TemplateCommandeCuisinier(ccui);

            return uc_commentaire;
        }

        private void InitCommandeCuisinier()
        {
            ListeCommandeCuisinier = new ObservableCollection<commandeCuisinier>();

            foreach (CommandeClient commande in ListeCommandeClient)
            {

                commandeCuisinier cc = new commandeCuisinier(commande.Client.IdTable, commande.CommandeClientItems, commande);
                ListeCommandeCuisinier.Add(cc);
            }
        }


        private void InitCommandeClient()
        {
            ListeCommandeClient = new ObservableCollection<CommandeClient>();

            List<CommandeClient> commandes = OutilsEF.WPFoodContext.CommandesClients
                .Include(commande => commande.Client)
                .Include(commande => commande.CommandeClientItems).ToList();

            foreach (CommandeClient cl in commandes)
            {
                if (cl.EstTermine != true)
                {
                    ListeCommandeClient.Add(cl);
                }
            }
        }


        public void TerminerUneCommande(CommandeClient c)
        {
            c.EstTermine = true;
            OutilsEF.WPFoodContext!.SaveChanges();
            ListeCommandeClient!.Clear();
            ListeCommandeCuisinier!.Clear();
            InitCommandeClient();
            InitCommandeCuisinier();
            

        }


        private ObservableCollection<Table>? _listeTableOccupe;
        public ObservableCollection<Table>? ListeTableOccupe
        {
            get { return _listeTableOccupe; }
            set
            {
                _listeTableOccupe = value;
                if (_listeTableOccupe == null)
                    return;
                OnPropertyChanged("ListeTableOccupe");
            }

        }

        private ObservableCollection<commandeCuisinier>? _listeCommandeCuisinier;
        public ObservableCollection<commandeCuisinier>? ListeCommandeCuisinier
        {
            get { return _listeCommandeCuisinier; }
            set
            {
                _listeCommandeCuisinier = value;
                if (_listeCommandeCuisinier == null)
                    return;
                OnPropertyChanged("ListeCommandeCuisinier");
            }

        }


        private ObservableCollection<CommandeClient>? _listeCommandeClient;
        public ObservableCollection<CommandeClient>? ListeCommandeClient
        {
            get { return _listeCommandeClient; }
            set
            {
                _listeCommandeClient = value;
                if (_listeCommandeClient == null)
                    return;
                OnPropertyChanged("ListeCommandeClient");
            }

        }

        public UC_MainPageCuisinier monUC_Cuisinier { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }
    }
}
