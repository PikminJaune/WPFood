using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
using WPFood.Vues.UC_Admin;
using WPFood.Vues.UC_Admin.Menu_et_Items;
using WPFood.VuesModeles;
using WPFood.VuesModeles.VM_Admin;
using WPFood.VuesModeles.VM_Admin.VM_Admin;
using Menu = WPFood.Modeles.Menu;

namespace WPFood.Vues.UC_Admin
{
    /// <summary>
    /// Logique d'interaction pour UC_GestionMenu.xaml
    /// </summary>
    public partial class UC_GestionMenu : UserControl
    {
        UC_MainPageAdmin mainPageAdmin;
        VM_Admin_Menu vM_Admin_Menu;

        public UC_GestionMenu()
        {
            vM_Admin_Menu = new VM_Admin_Menu();
            
            InitializeComponent();
            DataContext = vM_Admin_Menu;
            btnModifierMenu.IsEnabled = false;
            btnSupprimerMenu.IsEnabled = false;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Gestion des menus";
        }

        private void RetourMenuAdmin_Click(object sender, RoutedEventArgs e)
        {
            mainPageAdmin = new UC_MainPageAdmin();
            GestionEcran.ChangerEcran(mainPageAdmin);
        }

        private void btnClickModifierMenu(object sender, RoutedEventArgs e)
        {          
            if (dg_Menus.SelectedItem != null)
            {
                Menu leMenuSelectionner = dg_Menus.SelectedItem as Menu;
                UC_ModifierMenu ucModifMenu = new UC_ModifierMenu(leMenuSelectionner);
                GestionEcran.ChangerEcran(ucModifMenu);

            }                
        }

        private void btnClick_AjouterMenu(object sender, RoutedEventArgs e)
        {
            Modale_Ajouter_Menu mAjoutMenu = new Modale_Ajouter_Menu(vM_Admin_Menu);
            mAjoutMenu.Show();
        }

        // Lorsqu'une case est sélectionné
        private void DataGridCellSelected(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Menus.SelectedItem != null)
            {
                btnModifierMenu.IsEnabled = true;
                btnSupprimerMenu.IsEnabled = true;
            }
        }

        private void BtnDoubleClick_ModifierMenu(object sender, MouseButtonEventArgs e)
        {
            Menu leMenuSelectionner = dg_Menus.SelectedItem as Menu;
            UC_ModifierMenu ucModifMenu = new UC_ModifierMenu(leMenuSelectionner);
            GestionEcran.ChangerEcran(ucModifMenu);
        }
    }
}
