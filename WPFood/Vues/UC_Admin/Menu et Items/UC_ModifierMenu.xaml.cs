using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFood.Modeles;
using WPFood.Outils;
using WPFood.VuesModeles.VM_Admin.VM_Admin;
using WPFood.VuesModeles.VM_Administrateur;
using Menu = WPFood.Modeles.Menu;
using MenuItem = WPFood.Modeles.MenuItem;

namespace WPFood.Vues.UC_Admin.Menu_et_Items
{
    /// <summary>
    /// Logique d'interaction pour UC_ModifierMenu.xaml
    /// </summary>
    public partial class UC_ModifierMenu : UserControl
    {
        Menu menuAModifier;
        public List<Item> lstItemTempoAjout = new List<Item>();
        public Item itemTempoSupprimer = new Item();
        public List<Item> lstItemDispoTempoSupprimer = new List<Item>();
        public List<Item> lstItemASauvegarder = new List<Item>();
        VM_Admin_MenuItem vmdmi;
        VM_Admin_Menu vmAdminMenu;
        public UC_ModifierMenu(Menu menuModif)
        {
            // Importer les menus et aller chercher deep dans le menu les items quil contient
            VM_Admin_MenuItem vmAdminItem = new VM_Admin_MenuItem(menuModif);
            DataContext = vmAdminItem;
            vmdmi = vmAdminItem;
            menuAModifier = menuModif;
            vmAdminMenu = new VM_Admin_Menu();
            InitializeComponent();

            txbNomMenuModif.Text = menuAModifier.Nom;
            txbNomMenu.Text = menuAModifier.Nom;
            cmbCategorie.Text = menuAModifier.Categorie;
            cmbSaison.Text = menuAModifier.Saison;

            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = false;

            btnSupprimerDuMenu.IsEnabled = false;
            btnAjouterAuMenu.IsEnabled = false;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Modifier un menu";
        }

        private void btnClick_CreerUnItem(object sender, RoutedEventArgs e)
        {
            Modale_Ajouter_MenuItem ajoutItem = new Modale_Ajouter_MenuItem(vmdmi);
            ajoutItem.Show();
        }

        private void btnClick_ModifierUnItem(object sender, RoutedEventArgs e)
        {
            if(dg_ItemDispo.SelectedItems.Count == 1)
            {
                Modale_Modifier_Item modifItemModale = new Modale_Modifier_Item(vmdmi, dg_ItemDispo.SelectedItem as Item);
                modifItemModale.Show();
            }
                
        }

        private void btnClick_Retour(object sender, RoutedEventArgs e)
        {
            UC_GestionMenu UCGestMenu = new UC_GestionMenu();
            GestionEcran.ChangerEcran(UCGestMenu);
            
        }

        private void btnClick_AjouterItemAuMenu(object sender, RoutedEventArgs e)
        {
            if(dg_ItemDispo.SelectedItems.Count != 0)
            {
                foreach (Item itemSelectPourAjout in dg_ItemDispo.SelectedItems)
                {
                    lstItemTempoAjout.Add(itemSelectPourAjout);
                }
                vmdmi.AjoutItemAuMenu(lstItemTempoAjout);
                dg_ItemDispo.SelectedIndex = -1;
                lstItemTempoAjout.Clear();
            }
        }

        private void btnClick_SupprimerItemDuMenu(object sender, RoutedEventArgs e)
        {
            if(dg_ItemMenu.SelectedItems.Count != 0)
            {
                var result = MessageBox.Show("Êtes-vous certain de supprimer cet item du menu ?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    itemTempoSupprimer = dg_ItemMenu.SelectedItem as Item;
                    vmdmi.SupprimerItemMenu(itemTempoSupprimer);                   
                    

                }
                dg_ItemDispo.SelectedIndex = -1;
            }
        }

        private void btnClick_SupprimerUnItemDispo(object sender, RoutedEventArgs e)
        {
            if (dg_ItemDispo.SelectedItems.Count == 1)
            {
                Item itemASupprimer = (Item)dg_ItemDispo.SelectedItem;

                vmAdminMenu.SupprimerItemDesMenu(itemASupprimer);
                vmdmi.ResetAffichage();

                dg_ItemDispo.SelectedIndex = -1;
            }
        }

        private void btnClickEnregistrerMenu(object sender, RoutedEventArgs e)
        {
            foreach (var item in dg_ItemMenu.Items)
            {
                lstItemASauvegarder.Add(item as Item);
            }
            if(vmAdminMenu.SauvegarderMenu(txbNomMenu.Text, cmbCategorie.Text, cmbSaison.Text, lstItemASauvegarder, menuAModifier))
            {
                UC_GestionMenu ucMOdif = new UC_GestionMenu();
                GestionEcran.ChangerEcran(ucMOdif);
            }            
        }

        private void CacherBoutonMultipleSelection(object sender, RoutedEventArgs e)
        {
            if(dg_ItemDispo.SelectedItems.Count >= 1)
            {                
                btnAjouterAuMenu.IsEnabled = true;
            }
            else
            {            
                btnAjouterAuMenu.IsEnabled = false;
            }

            if (dg_ItemDispo.SelectedItems.Count == 1)
            {
                btnSupprimer.IsEnabled = true;
                btnModifier.IsEnabled = true;
            }
            else
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
            }

        }

        private void ChangementDataGridMenu(object sender, SelectionChangedEventArgs e)
        {
            if(dg_ItemMenu.SelectedItems != null)
            {
                btnSupprimerDuMenu.IsEnabled = true;
            }
            else
            {
                btnSupprimerDuMenu.IsEnabled = false;
            }
        }
    }
}
