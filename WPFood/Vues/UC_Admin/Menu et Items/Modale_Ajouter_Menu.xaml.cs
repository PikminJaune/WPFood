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
using System.Windows.Shapes;
using WPFood.Modeles;
using WPFood.VuesModeles.VM_Admin.VM_Admin;
using WPFood.VuesModeles.VM_Administrateur;
using Menu = WPFood.Modeles.Menu;

namespace WPFood.Vues.UC_Admin
{
    /// <summary>
    /// Logique d'interaction pour Modale_Ajouter_Menu.xaml
    /// </summary>
    public partial class Modale_Ajouter_Menu : Window
    {
        VM_Admin_Menu vmAdminMenu;
        public Modale_Ajouter_Menu(VM_Admin_Menu vM_Admin_Menu)
        {
            InitializeComponent();
            vmAdminMenu = vM_Admin_Menu;
            btnAjout.Visibility = Visibility.Hidden;
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Ajouter un menu";
        }

        private void btn_AjouterUnMenu(object sender, RoutedEventArgs e)
        {
                Menu menuACreer = new Menu(txbNomMenu.Text, cmbCategorie.Text, cmbSaison.Text);
                vmAdminMenu.CreerMenu(menuACreer);
                this.Close();           
        }

        private void changementDeTexte(object sender, TextChangedEventArgs e)
        {
            if(txbNomMenu.Text.Length > 0)
            {
                btnAjout.Visibility = Visibility.Visible;
            }
            else
            {
                btnAjout.Visibility = Visibility.Hidden;
            }
        }
    }
}
