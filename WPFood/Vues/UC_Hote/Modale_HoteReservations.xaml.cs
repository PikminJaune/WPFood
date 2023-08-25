using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFood.Modeles;
using WPFood.VuesModeles.VM_Hote;

namespace WPFood.Vues.UC_Hote
{
    /// <summary>
    /// Logique d'interaction pour Modale_HoteReservations.xaml
    /// </summary>
    public partial class Modale_HoteReservations : Window
    {
        VM_Hote vM_Hote;
        Reservation reservationActuelle;
        private int niveau = 1;

        private int nbClients;
        private DateTime dateVoulue;
        private string heureVoulue;

        public Modale_HoteReservations(VM_Hote vm_Hote, Reservation reservation = null)
        {
            InitializeComponent();
            vM_Hote = vm_Hote;
            DataContext = vM_Hote;
            _lstHeures = new List<string>() {
                "06:00",
                "06:30",
                "07:00",
                "07:30",
                "08:00",
                "08:30",
                "09:00",
                "09:30",
                "10:00",
                "10:30",
                "11:00",
                "11:30",
                "12:00",
                "12:30",
                "13:00",
                "13:30",
                "14:00",
                "14:30",
                "15:00",
                "15:30",
                "16:00",
                "16:30",
                "17:00",
                "17:30",
                "18:00",
                "18:30",
                "19:00",
                "19:30",
                "20:00",
                "20:30"
            };
            cbHeures.ItemsSource = _lstHeures;
            //cbTables.ItemsSource = vM_Hote.LstTables;

            gridNomTel.Visibility = Visibility.Visible;
            gridClients.Visibility = Visibility.Hidden;
            gridNumTables.Visibility = Visibility.Hidden;
            gridDate.Visibility = Visibility.Hidden;
            gridHeure.Visibility = Visibility.Hidden;
            btnAjoutModif.Visibility = Visibility.Hidden;

            //-----------------------------------------------------
            //Nouvelle réservation
            if (reservation == null)
            {
                _option = "Ajouter";
                cbHeures.SelectedIndex = -1;
                cbHeures.Padding = new Thickness(0, 0, 0, 0);
            }
            //-----------------------------------------------------
            //Ancienne réservation
            else
            {
                _option = "Modifier";
                tbNom.Text = reservation.NomClient;
                tbNumTel.Text = reservation.NumeroTelephone;
                tbNbClients.Text = reservation.NbClientAttendu.ToString();

                //cbTables.Text = reservation.Table.ToString();

                dpDate.Text = reservation.DateReservation.ToString();

                if (reservation.DateReservation.Hour > 10)
                {
                    if (reservation.DateReservation.Minute > 10)
                    {
                        cbHeures.Text = reservation.DateReservation.Hour.ToString() + ":" + reservation.DateReservation.Minute.ToString();
                    }
                    else
                    {
                        cbHeures.Text = reservation.DateReservation.Hour.ToString() + ":0" + reservation.DateReservation.Minute.ToString();
                    }
                }
                else
                {
                    if (reservation.DateReservation.Minute > 10)
                    {
                        cbHeures.Text = "0" + reservation.DateReservation.Hour.ToString() + ":" + reservation.DateReservation.Minute.ToString();
                    }
                    else
                    {
                        cbHeures.Text = "0" + reservation.DateReservation.Hour.ToString() + ":0" + reservation.DateReservation.Minute.ToString();
                    }
                }

                cbHeures.Padding = new Thickness(155, 0, 0, 0);
                reservationActuelle = reservation;
            }

            //Démarrer le visuel
            tbTitre.Text = "Action: " + _option;
            btnAjoutModif.Content = _option;

        }
        //-----------------------------------------------------------------
        #region Props

        private List<string> _lstHeures;

        public List<string> ListHeures
        {
            get { return _lstHeures; }
            set
            {
                _lstHeures = value;
            }
        }

        //--------------

        private string _option;

        public string Option
        {
            get { return _option; }
            set
            {
                _option = value;
            }
        }

        #endregion

        //-----------------------------------------------------------------
        #region Outils
        private void TextBoxChiffres(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //-----------------------------------------------------------------------------

        private void cbHeures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbHeures.Padding = new Thickness(155, 0, 0, 0);
        }

        #endregion

        //-----------------------------------------------------------------------------
        #region Boutons
        private void AjoutModif_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Valider que toutes les sections sont pleines
                if (cbTables.Text != "")
                {
                    string nomClient = tbNom.Text;
                    string numTel = tbNumTel.Text;
                    int nbClients = int.Parse(tbNbClients.Text);
                    Table table = (Table)cbTables.SelectedItem;
                    string dateConstruction = dpDate.Text + " " + cbHeures.Text + ":00";
                    DateTime date = DateTime.Parse(dateConstruction);

                    Reservation nouvelleReservation = new Reservation(nomClient, numTel, nbClients, table, date);

                    if (_option == "Ajouter")
                    {
                        vM_Hote.AjouterReservation(nouvelleReservation);
                        MessageBox.Show("La réservation a été faite!", "Réservation", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    else
                    {
                        vM_Hote.ModifierReservation(nouvelleReservation, reservationActuelle);
                        MessageBox.Show("La réservation a été modifiée!", "Réservation", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    this.Close();
                }

                else
                {
                    MessageBox.Show("La table est invalide", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
            }
        }

        //-----------------------------------------------------------------------------
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        //-----------------------------------------------------------------------------
        #region Navigation
        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            niveau--;
            btnSuivant.Visibility = Visibility.Visible;
            if (niveau < 2)
            {
                btnRetour.Visibility = Visibility.Hidden;
                btnAjoutModif.Visibility = Visibility.Hidden;
            }
            //---------------------------------------------
            switch (niveau)
            {
                case 1:
                    gridNomTel.Visibility = Visibility.Visible;
                    gridClients.Visibility = Visibility.Hidden;
                    gridDate.Visibility = Visibility.Hidden;
                    gridHeure.Visibility = Visibility.Hidden;
                    gridNumTables.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    gridNomTel.Visibility = Visibility.Hidden;
                    gridClients.Visibility = Visibility.Visible;
                    gridDate.Visibility = Visibility.Hidden;
                    gridHeure.Visibility = Visibility.Hidden;
                    gridNumTables.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    gridNomTel.Visibility = Visibility.Hidden;
                    gridClients.Visibility = Visibility.Hidden;
                    gridDate.Visibility = Visibility.Visible;
                    gridHeure.Visibility = Visibility.Hidden;
                    gridNumTables.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    gridNomTel.Visibility = Visibility.Hidden;
                    gridClients.Visibility = Visibility.Hidden;
                    gridDate.Visibility = Visibility.Hidden;
                    gridHeure.Visibility = Visibility.Visible;
                    gridNumTables.Visibility = Visibility.Hidden;
                    btnAjoutModif.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    gridNomTel.Visibility = Visibility.Hidden;
                    gridClients.Visibility = Visibility.Hidden;
                    gridDate.Visibility = Visibility.Hidden;
                    gridHeure.Visibility = Visibility.Hidden;
                    gridNumTables.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void btnSuivant_Click(object sender, RoutedEventArgs e)
        {
            //Si niveau 1, vérifier Nom + Tel avant de procéder
            if (niveau == 1)
            {
                if (tbNom.Text != "" && tbNumTel.Text != "")
                {
                    niveau++;
                    btnRetour.Visibility = Visibility.Visible;

                    gridNomTel.Visibility = Visibility.Hidden;
                    gridClients.Visibility = Visibility.Visible;
                    gridNumTables.Visibility = Visibility.Hidden;
                    gridDate.Visibility = Visibility.Hidden;
                    gridHeure.Visibility = Visibility.Hidden;

                    return;
                }
                else
                {
                    MessageBox.Show("Nom ou numéro de téléphone vide", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            //Si niveau 2, vérifier nbClient avant de procéder
            if (niveau == 2)
            {
                if (tbNbClients.Text != "")
                {
                    niveau++;
                    btnRetour.Visibility = Visibility.Visible;

                    gridNomTel.Visibility = Visibility.Hidden;
                    gridClients.Visibility = Visibility.Hidden;
                    gridDate.Visibility = Visibility.Visible;
                    gridHeure.Visibility = Visibility.Hidden;
                    gridNumTables.Visibility = Visibility.Hidden;

                    //--------------------------------------------

                    try
                    {
                        nbClients = int.Parse(tbNbClients.Text);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

                    return;
                }
                else
                {
                    MessageBox.Show("Nombre de clients invalide", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            //Si niveau 3, vérifier la date avant de procéder
            if (niveau == 3)
            {
                if (dpDate.Text != "")
                {
                    niveau++;
                    btnRetour.Visibility = Visibility.Visible;

                    gridNomTel.Visibility = Visibility.Hidden;
                    gridClients.Visibility = Visibility.Hidden;
                    gridDate.Visibility = Visibility.Hidden;
                    gridHeure.Visibility = Visibility.Visible;
                    gridNumTables.Visibility = Visibility.Hidden;

                    //--------------------------------------------

                    try
                    {
                        dateVoulue = Convert.ToDateTime(dpDate.Text);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

                    return;
                }
                else
                {
                    MessageBox.Show("Date invalide", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            //Si niveau 4, vérifier l'heure avant de procéder. Afficher les tables après.
            if (niveau == 4)
            {
                if (cbHeures.Text != "")
                {
                    #region Visibilité
                    niveau++;
                    btnSuivant.Visibility = Visibility.Hidden;

                    gridNomTel.Visibility = Visibility.Hidden;
                    gridClients.Visibility = Visibility.Hidden;
                    gridDate.Visibility = Visibility.Hidden;
                    gridHeure.Visibility = Visibility.Hidden;

                    btnAjoutModif.Visibility = Visibility.Visible;
                    gridNumTables.Visibility = Visibility.Visible;
                    #endregion

                    //--------------------------------------------

                    try
                    {

                        //Aller chercher les tables qui sont valides
                        if (_option == "Modifier")
                        {
                            cbTables.ItemsSource = vM_Hote.GetTablesReservations(nbClients, dateVoulue, cbHeures.Text, reservationActuelle);
                        }
                        else
                        {
                            cbTables.ItemsSource = vM_Hote.GetTablesReservations(nbClients, dateVoulue, cbHeures.Text);
                        }
                       

                        //Si c'est une modification, 
                        if (_option == "Modifier")
                        {
                            cbTables.Text = reservationActuelle.Table.ToString();
                        }

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

                    return;
                }
                else
                {
                    MessageBox.Show("Heure choisie invalide", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        #endregion
    }
}
