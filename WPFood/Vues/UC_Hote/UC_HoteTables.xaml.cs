using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFood.Modeles;
using WPFood.Outils;
using WPFood.Vues.UC_Hote;
using WPFood.VuesModeles.VM_Hote;
using Table = WPFood.Modeles.Table;
using System.Text.RegularExpressions;

namespace WPFood.Vues
{
    /// <summary>
    /// Logique d'interaction pour UC_HoteTables.xaml
    /// </summary>
    public partial class UC_HoteTables : UserControl
    {
        UC_HoteReservations hoteReservations;
        VM_Hote vM_Hote;

        public UC_HoteTables()
        {
            InitializeComponent();
            vM_Hote = new VM_Hote();
            DataContext = vM_Hote;
            RBToutesLesTables.IsChecked = true;
            TBNbTables.Text = "Nombre total de tables: " + vM_Hote.LstTables.Count;
        }

        //-------------------------------------------------------------------

        #region Clicks
        /// <summary>
        /// Clic sur une table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (LBTables.SelectedValue != null)
            {
                Table table = (Table)LBTables.SelectedItem;

                //A Nettoyer -> Libre
                if (table.Etat == "A Nettoyer")
                {
                    MessageBoxResult messageBox = MessageBox.Show("Table nettoyée?", "Nettoyage", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (messageBox == MessageBoxResult.Yes)
                    {
                        vM_Hote.ModifierTable(table, "Libre", 0);
                    }
                }
                /*
                //Occupée -> Libre
                else if (table.Etat == "Occupée")
                {
                    MessageBoxResult messageBox = MessageBox.Show("Table a nettoyer?", "Nettoyage", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (messageBox == MessageBoxResult.Yes)
                    {
                        vM_Hote.ClientsEstPasse(table);
                        vM_Hote.ModifierTable(table, "A Nettoyer", 0);
                    }
                    else
                    {
                        Modale_HoteTables modale_HoteTables;
                        modale_HoteTables = new Modale_HoteTables(vM_Hote, table!);
                        modale_HoteTables.ShowDialog();
                    }

                }
                */
                else
                {
                    Modale_HoteTables modale_HoteTables;
                    modale_HoteTables = new Modale_HoteTables(vM_Hote, table!);
                    modale_HoteTables.ShowDialog();
                }

                //Retirer la selection de la table
                LBTables.SelectedValue = -1;
            }

        }

        private void Reservations_Click(object sender, RoutedEventArgs e)
        {
            hoteReservations = new UC_HoteReservations();
            GestionEcran.ChangerEcran(hoteReservations);
        }

        #endregion

        //-------------------------------------------------------------------

        #region Plus
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Associer Tables";
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion

        //-------------------------------------------------------------------

        #region RadioButtons
        private void ToutesTables_Checked(object sender, RoutedEventArgs e)
        {
            int? nbPlaces = null;
            if (tbNbPlace.Text.Length > 0)
            {
                nbPlaces = int.Parse(tbNbPlace.Text);
            }

            vM_Hote.LstTables = vM_Hote.GetAllTables(nbPlaces);
            HoteGlobale.Option = null;
        }

        private void TablesLibres_Checked(object sender, RoutedEventArgs e)
        {
            int? nbPlaces = null;
            if (tbNbPlace.Text.Length > 0)
            {
                nbPlaces = int.Parse(tbNbPlace.Text);
            }

            vM_Hote.LstTables = vM_Hote.GetTablesFiltre("Libre", nbPlaces);
            HoteGlobale.Option = "Libre";
        }

        private void TablesNettoyage_Checked(object sender, RoutedEventArgs e)
        {
            int? nbPlaces = null;
            if (tbNbPlace.Text.Length > 0)
            {
                nbPlaces = int.Parse(tbNbPlace.Text);
            }
            vM_Hote.LstTables = vM_Hote.GetTablesFiltre("A Nettoyer", nbPlaces);
            HoteGlobale.Option = "A Nettoyer";
        }
        #endregion

        //-------------------------------------------------------------------

        private void TbNbPlaces_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (tbNbPlace.Text.Length > 0)
            {
                int nbPlaces = int.Parse(tbNbPlace.Text);
                vM_Hote.LstTables = vM_Hote.GetTablesNbPlaces(nbPlaces);
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();

            if (tbNbPlace.Text.Length == 0)
            {
                vM_Hote.LstTables = vM_Hote.GetTablesNbPlaces(0);
            }
        }
    }
}
