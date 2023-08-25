using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFood.Outils;
using WPFood.Vues.UC_Client;
using WPFood.Vues.UC_Cuisinier;
using WPFood.Vues.UC_Hote;
using WPFood.Vues;
using WPFood.Vues.UC_Serveur;
using WPFood.Vues.UC_Admin;
using System.Collections.ObjectModel;
using WPFood.Modeles;
using System.Windows;
using System.Windows.Controls;
using WPFood.Vues.UC_Connexion;

namespace WPFood.VuesModeles.VM_Connexion
{
    internal class VM_Connexion : INotifyPropertyChanged
    {

        private bool isConnected = false;
        private Employe employeConnecter;

        //Page Client
        public UC_ClientCommentaire clientCommentaire;
        // Pages HOTES
        public UC_HoteTables hoteTables;
        public UC_HoteReservations hoteReservations;
        // PAGE CUISNIER
        public UC_MainPageCuisinier mainPageCuisiner;
        // PAGE SERVEUR
        public UC_Serveur mainPageServeur;
        // PAGE ADMIN
        public UC_MainPageAdmin mainPageAdmin;
        // Page de connexion  
        public UC_Connexion ucC;

        MainWindow mw = (MainWindow)Application.Current.MainWindow;



        public VM_Connexion()
        {
            clientCommentaire = new UC_ClientCommentaire();
            
            hoteReservations = new UC_HoteReservations();
            
            mainPageServeur = new UC_Serveur();
            mainPageAdmin = new UC_MainPageAdmin();
           
            InitListeEmploye();

        }

        public bool ValiderConnexion(string txtUtilisateur,string txtPassword)
        {
            InitListeEmploye();           
            foreach (var employe in ListeEmployes)
            {
                if (txtUtilisateur == employe.Identifiant && txtPassword == employe.MotDePasse)
                {
                    isConnected = true;
                    employeConnecter = employe;
                }
            }

            if (isConnected)
            {
                mw.btnDeconnexion.Visibility = Visibility.Visible;
                mw.mainSeparator.Visibility = Visibility.Visible;
                switch (employeConnecter.Fonction)
                {
                    case "Cuisinier":
                        mainPageCuisiner = new UC_MainPageCuisinier();
                        GestionEcran.ChangerEcran(mainPageCuisiner);
                        break;
                    case "Hote":
                        hoteTables = new UC_HoteTables();
                        GestionEcran.ChangerEcran(hoteTables);
                        break;
                    case "Serveur":
                        mainPageServeur = new UC_Serveur();
                        GestionEcran.ChangerEcran(mainPageServeur);
                        break;
                    case "Admin":
                        mainPageAdmin = new UC_MainPageAdmin();
                        GestionEcran.ChangerEcran(mainPageAdmin);
                        break;
                    case "Client":
                        clientCommentaire = new UC_ClientCommentaire();
                        GestionEcran.ChangerEcran(clientCommentaire);
                        break;
                }
                isConnected = false;
                return true;
            }
            else
            {
                MessageBox.Show("problème de connection");
                return false;
            }
        }



        private void InitListeEmploye()
        {
            ListeEmployes = new ObservableCollection<Employe>();

            var eRequete = from employe in OutilsEF.WPFoodContext.Employes select employe;
            foreach (Employe emp in eRequete)
                ListeEmployes.Add(emp);
        }

        private ObservableCollection<Employe> _listeEmployes;
        public ObservableCollection<Employe> ListeEmployes
        {
            get { return _listeEmployes; }
            set
            {
                _listeEmployes = value;
                if (_listeEmployes == null)
                    return;
                OnPropertyChanged("ListeEmployes");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }

    }
}
