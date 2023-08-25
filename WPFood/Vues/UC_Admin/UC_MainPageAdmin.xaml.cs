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
    /// Logique d'interaction pour UC_MainPageAdmin.xaml
    /// </summary>
    public partial class UC_MainPageAdmin : UserControl
    {
        UC_GestionTables gestionTables;
        UC_GestionEquipe gestionEquipe;
        UC_GestionMenu gestionMenu;
        UC_GestionStock gestionStock;
        UC_AfficherStatistiques afficherStatistiques;
        UC_GestionCommentaires gestionCommentaires;            

        public UC_MainPageAdmin()
        {
            InitializeComponent();


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           Window window = Window.GetWindow(this);
           window.Title = "Administration";    
        }

        #region Boutons

        private void btnTables_Click(object sender, RoutedEventArgs e)
        {
            gestionTables = new UC_GestionTables();
            GestionEcran.ChangerEcran(gestionTables);
        }

        private void btnEquipe_Click(object sender, RoutedEventArgs e)
        {
            gestionEquipe = new UC_GestionEquipe();
            GestionEcran.ChangerEcran(gestionEquipe);
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            gestionMenu = new UC_GestionMenu();
            GestionEcran.ChangerEcran(gestionMenu);
        }

        private void btnStock_Click(object sender, RoutedEventArgs e)
        {
            gestionStock = new UC_GestionStock();
            GestionEcran.ChangerEcran(gestionStock);
        }

        private void btnStatistiques_Click(object sender, RoutedEventArgs e)
        {
            afficherStatistiques = new UC_AfficherStatistiques();
            GestionEcran.ChangerEcran(afficherStatistiques);
        }

        private void btnCommentaires_Click(object sender, RoutedEventArgs e)
        {
            gestionCommentaires = new UC_GestionCommentaires();
            GestionEcran.ChangerEcran(gestionCommentaires);
        }

        #endregion
    }
}
