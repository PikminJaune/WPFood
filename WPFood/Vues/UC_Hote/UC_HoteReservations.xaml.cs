using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using WPFood.Modeles;
using WPFood.Outils;
using WPFood.VuesModeles.VM_Hote;
using WPFood.Vues.UC_Hote;

namespace WPFood.Vues
{
    /// <summary>
    /// Logique d'interaction pour UC_HoteReservations.xaml
    /// </summary>
    public partial class UC_HoteReservations : UserControl
    {

        public UC_HoteTables hoteTables;
        VM_Hote vM_Hote;

        public UC_HoteReservations()
        {
            InitializeComponent();
            vM_Hote = new VM_Hote();
            DataContext = vM_Hote;

            btnModifier.Visibility = Visibility.Hidden;
            btnRetirer.Visibility = Visibility.Hidden;
        }

        //-----------------------------------------------------------------
        private void Associer_Click(object sender, RoutedEventArgs e)
        {
            hoteTables = new UC_HoteTables();
            GestionEcran.ChangerEcran(hoteTables);
        }

        //-----------------------------------------------------------------
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Réservations";
        }

        //-----------------------------------------------------------------

        private void AjouterReservation_Click(object sender, RoutedEventArgs e)
        {
            Modale_HoteReservations modale_HoteReservations = new Modale_HoteReservations(vM_Hote);
            modale_HoteReservations.ShowDialog();
        }

        private void ModifierReservation_Click(object sender, RoutedEventArgs e)
        {

            Reservation reservation = (Reservation)dgReservations.SelectedValue;
            dgReservations.SelectedValue = null;

            Modale_HoteReservations modale_HoteReservations = new Modale_HoteReservations(vM_Hote, reservation);
            modale_HoteReservations.ShowDialog();

        }

        private void SupprimerReservation_Click(object sender, RoutedEventArgs e)
        {
            Reservation reservation = (Reservation)dgReservations.SelectedValue;
            dgReservations.SelectedValue = null;

            vM_Hote.RetirerReservation(reservation);
            MessageBox.Show("La réservation a été retirée!", "Réservation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void dgReservations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgReservations.SelectedValue == null)
            {
                btnModifier.Visibility = Visibility.Hidden;
                btnRetirer.Visibility = Visibility.Hidden;
            }
            else
            {
                btnModifier.Visibility = Visibility.Visible;
                btnRetirer.Visibility = Visibility.Visible;
            }
            
        }
    }
}
