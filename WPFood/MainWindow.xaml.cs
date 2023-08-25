using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WPFood.Vues;
using WPFood.Vues.UC_Client;
using WPFood.Vues.UC_Cuisinier;
using WPFood.Vues.UC_Admin;
using WPFood.Vues.UC_Serveur;
using WPFood.VuesModeles.VM_Connexion;
using WPFood.Vues.UC_Connexion;

namespace WPFood
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserControl Ecran { get; set; }
        public UC_Connexion ecranConnexion;
        private bool bougerEcran;

        public MainWindow()
        {
            InitializeComponent();

            OutilsEF outilsEF = new OutilsEF();
            // Cache les boutons au debut puisqu'ils ne sont pas utilisés
            mainSeparator.Visibility = Visibility.Hidden;
            btnDeconnexion.Visibility = Visibility.Hidden;

            ecranConnexion = new UC_Connexion();
            GestionEcran.ChangerEcran(ecranConnexion);
            bougerEcran = false;

            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#D64161");
            btnBougerEcran.Background = brush;
        }

        /// <summary>
        /// Lors que la grid est chargée, changer le titre de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridLoaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Écran de connexion";
        }

        //-----------------------------------------------------------------------------
        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir quitter?", "Quitter", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void btn_Deco(object sender, RoutedEventArgs e)
        {
            btnDeconnexion.Visibility = Visibility.Hidden;
            mainSeparator.Visibility = Visibility.Hidden;
            GestionEcran.ChangerEcran(ecranConnexion);
        }

        private void btnEcran_Click(object sender, RoutedEventArgs e)
        {
            if (bougerEcran)
            {
                bougerEcran = false;
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#D64161");
                btnBougerEcran.Background = brush;
            }
            else
            {
                bougerEcran = true;
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#435E55");
                btnBougerEcran.Background = brush;
            }
        }
        //-----------------------------------------------------------------------------

        /// <summary>
        /// Faire bouger la fenêtre lors d'un clic gauche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (bougerEcran)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    WindowState = WindowState.Normal;
                    DragMove();
                    WindowState = WindowState.Maximized;
                }
            }
        }


    }
}
