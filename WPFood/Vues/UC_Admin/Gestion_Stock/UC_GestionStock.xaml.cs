using System;
using System.Collections.Generic;
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
using WPFood.Outils;

namespace WPFood.Vues.UC_Admin
{
    /// <summary>
    /// Logique d'interaction pour UC_GestionStock.xaml
    /// </summary>
    public partial class UC_GestionStock : UserControl
    {
        UC_MainPageAdmin mainPageAdmin;

        public UC_GestionStock()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Gestion de l'inventaire";
        }

        private void RetourMenuAdmin_Click(object sender, RoutedEventArgs e)
        {
            mainPageAdmin = new UC_MainPageAdmin();
            GestionEcran.ChangerEcran(mainPageAdmin);
        }

        private void btn_ClickCommandeFournisseur(object sender, RoutedEventArgs e)
        {
            GestionEcran.ChangerEcran(new UC_CommandeFournisseur("pageAdmin"));
        }
    }
}
