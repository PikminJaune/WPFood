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
using WPFood.Outils;
using WPFood.VuesModeles.VM_Hote;

namespace WPFood.Vues.UC_Hote
{
    /// <summary>
    /// Logique d'interaction pour Modale_HoteTables.xaml
    /// </summary>
    public partial class Modale_HoteTables : Window
    {
        VM_Hote vM_Hote;
        Table tableSelectionnee;

        public Modale_HoteTables(VM_Hote vm_Hote, Table table)
        {
            InitializeComponent();
            vM_Hote = vm_Hote;
            tableSelectionnee = table;
            DataContext = vM_Hote;
            tbClients.Text = table.NbClients.ToString();

            //La table est occupé par des clients
            if (table.Etat == "Occupée")
            {
                cbOccupee.IsChecked = true;
                wpClients.Visibility = Visibility.Visible;
            }
            //La table est libre
            else
            {
                cbOccupee.IsChecked = false;
                wpClients.Visibility = Visibility.Hidden;
            }

            tbNumTable.Text = "Table #" + table.Id.ToString();
            tbMaxClients.Text = "Cette table à un maximum de " + tableSelectionnee.NbPlacesMax + " clients";
        }

        //-----------------------------------------------------------------------------

        #region Boutons
        private void BtConfirmer_Click(object sender, RoutedEventArgs e)
        {
            bool estOccupee = cbOccupee.IsChecked!.Value;
            bool estOccupeeOriginal;
            if (tableSelectionnee.Etat == "Libre")
            {
                estOccupeeOriginal = false;
            }
            else
            {
                estOccupeeOriginal = true;
            }


            try
            {
                int nbClients = int.Parse(tbClients.Text);

                //Avant de placer les clients, il faut s'assurer que le nombre de clients qu'on rentre est plus grand que le minimum
                if (tableSelectionnee.NbPlacesMax < nbClients)
                {
                    MessageBox.Show("Le nombre de clients doit être inférieur au nombre maximum de client à cette table: "+ tableSelectionnee.NbPlacesMax + "!", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {           
                //Si la table n'était pas occupée à la base: On ne fait rien
                if (estOccupeeOriginal == false && estOccupee == false)
                {
                    this.Close();
                }
                //Si la table était occupée: On la rend libre
                else if (estOccupeeOriginal == true && estOccupee == false)
                {
                    vM_Hote.RetirerClients(tableSelectionnee.Id);
                    vM_Hote.ModifierTable(tableSelectionnee, "Libre", 0);
                    this.Close();
                }
                //Si la table est déjà libre et qu'on l'occupe: On y ajoute des clients
                else if (estOccupeeOriginal == false && estOccupee == true)
                {
                    if (nbClients > 0)
                    {
                        List<Client> clients = new List<Client>();

                        for (int i = 0; i < nbClients; i++)
                        {
                            Client client = new Client(tableSelectionnee.Id);
                            client.NumTable = i + 1; // Sinon commence a 0
                            clients.Add(client);
                        }
                        
                        vM_Hote.AjoutClients(clients);

                        vM_Hote.ModifierTable(tableSelectionnee, "Occupée", nbClients);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Le nombre de clients doit être supérieur à 0!", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                }
            }
            catch (FormatException)
            {
                if (tbClients.Text == "" && !estOccupee)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Le nombre de clients doit être un nombre!", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        //-----------------------------------------------------------------------------

        private void CbOccupee_Click(object sender, RoutedEventArgs e)
        {
            if (tableSelectionnee.Etat == "Occupée" && (bool)cbOccupee.IsChecked!)
            {
                tbClients.Text = tableSelectionnee.NbClients.ToString();
            }
            if ((bool)cbOccupee.IsChecked!)
            {
                wpClients.Visibility = Visibility.Visible;
            }
            else
            {
                wpClients.Visibility = Visibility.Hidden;
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
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbClients_GotFocus(object sender, RoutedEventArgs e)
        {
            tbClients.Text = "";
        }
    }
}
