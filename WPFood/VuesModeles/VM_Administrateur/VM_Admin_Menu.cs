using LiveCharts.Helpers;
using Microsoft.EntityFrameworkCore;
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
using WPFood.Vues.UC_Admin;

namespace WPFood.VuesModeles.VM_Admin.VM_Admin
{
    public class VM_Admin_Menu : INotifyPropertyChanged
    {
        public ICommand cmdSupprimerMenu_Menu { get; set; }

        public VM_Admin_Menu()
        {
            cmdSupprimerMenu_Menu = new Commande(cmdSupprimerMenu);
            ListeMenu = new ObservableCollection<Menu>();
            InitMenu();
            InitMenuItem();
        }

        private void InitMenu()
        {
            ListeMenu = new ObservableCollection<Menu>();

            var mRequete =
                from menu
                in OutilsEF.WPFoodContext.Menus
                select menu;
            foreach (Menu men in mRequete)
            {
                ListeMenu!.Add(men);
            }
        }

        private void InitMenuItem()
        {
            ListeMenuItem = new ObservableCollection<MenuItem>();

            var mRequete =
                from menu
                in OutilsEF.WPFoodContext.MenusItems
                select menu;
            foreach (MenuItem meni in mRequete)
            {
                ListeMenuItem!.Add(meni);
            }
        }

        public void CreerMenu(Menu menuACreer)
        {
            if (menuACreer.Nom.Length != 0)
            {
                ListeMenu.Add(menuACreer);
                OutilsEF.WPFoodContext.Menus.Add(menuACreer);
                OutilsEF.WPFoodContext.SaveChanges();
                MessageBox.Show("Menu créer!", "Succès", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Le menu doit avoir un nom", "Problème de création", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void SupprimerItemDesMenu(Item itemASupprimer)
        {
            int nbSuppression = 0;

            foreach (var lstMenuItem in ListeMenuItem)
            {

                if (lstMenuItem.Item.Nom == itemASupprimer.Nom)
                {

                    nbSuppression++;

                }

            }
            
            var result = MessageBox.Show("La suppression de l'item '" + itemASupprimer.Nom + "' va affecter " + nbSuppression + " menu(s) , êtes-vous sûr de vouloir faire ça ?"
                , "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning);


            //----------------------------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------------


            if (result == MessageBoxResult.Yes)
            {

                OutilsEF.WPFoodContext?.Items?.Remove(itemASupprimer);
                OutilsEF.WPFoodContext?.SaveChanges();           
            }
        }

        public bool SauvegarderMenu(string nomMenu, string categorieMenu, string saisonMenu, List<Item> itemDuMenu, Menu menuAModifier)
        {
            if (nomMenu.Length > 0 && categorieMenu.Length > 0 && saisonMenu.Length > 0)
            {
                Menu mModif = OutilsEF.WPFoodContext.Menus.Find(menuAModifier.Id);
                mModif.Nom = nomMenu;
                mModif.Categorie = categorieMenu;
                mModif.Saison = saisonMenu;
                if (mModif.MenusItems != null)
                    mModif.MenusItems.Clear();

                mModif.MenusItems = new List<MenuItem>();
                foreach (var item in itemDuMenu)
                {
                    mModif.MenusItems.Add(new MenuItem(item, menuAModifier));
                }
                OutilsEF.WPFoodContext.SaveChanges();

                MessageBox.Show("Menu sauvegarder!");
                return true;
            }
            else
            {
                MessageBox.Show("Veuillez bien remplir les champs des menus");
                return false;
            }
        }


        private ObservableCollection<Menu> _listeMenu;
        public ObservableCollection<Menu> ListeMenu
        {
            get { return _listeMenu; }
            set
            {
                _listeMenu = value;
                if (_listeMenu == null)
                    return;
                OnPropertyChanged("ListeMenu");
            }
        }

        private ObservableCollection<MenuItem> _listeMenuItem;
        public ObservableCollection<MenuItem> ListeMenuItem
        {
            get { return _listeMenuItem; }
            set
            {
                _listeMenuItem = value;
                if (_listeMenuItem == null)
                    return;
                OnPropertyChanged("ListeMenuItem");
            }
        }

        private Menu? _menuSelectionner;
        public Menu? MenuSelectionner
        {
            get { return _menuSelectionner; }
            set
            {
                _menuSelectionner = value;
                if (_menuSelectionner == null)
                    return;
                Id = _menuSelectionner.Id;
                Nom = _menuSelectionner.Nom;
                Categorie = _menuSelectionner.Categorie;
                Saison = _menuSelectionner.Saison;
                OnPropertyChanged("MenuSelectionner");
            }
        }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                if (_nom == null)
                    return;
                OnPropertyChanged("Nom");

            }
        }

        private string _categorie;
        public string Categorie
        {
            get { return _categorie; }
            set
            {
                _categorie = value;
                if (_categorie == null)
                    return;
                OnPropertyChanged("Categorie");

            }
        }
        private string _saison;
        public string Saison
        {
            get { return _saison; }
            set
            {
                _saison = value;
                if (_saison == null)
                    return;
                OnPropertyChanged("Saison");

            }
        }
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                if (_id == null)
                    return;
                OnPropertyChanged("Id");

            }
        }

        private void cmdSupprimerMenu(object sender)
        {
            if (MenuSelectionner == null)
                return;

            var result = MessageBox.Show("Êtes-vous certain de supprimer ce menu ?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                OutilsEF.WPFoodContext.Menus.Remove(MenuSelectionner);
                OutilsEF.WPFoodContext.SaveChanges();
                MenuSelectionner = null;
                InitMenu();
                MessageBox.Show("Menu supprimer avec succès.");
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
