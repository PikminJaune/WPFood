using System;
using System.Collections.Generic;
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
using WPFood.Modeles;
using WPFood.Outils;
using WPFood.Vues.UC_Admin.GestionTables;
using WPFood.VuesModeles.VM_Administrateur;
using static WPFood.Outils.Evenements;

namespace WPFood.Vues.UC_Admin
{
    /// <summary>
    /// Logique d'interaction pour UC_GestionTables.xaml
    /// </summary>
    public partial class UC_GestionTables : UserControl
    {
        UC_MainPageAdmin mainPageAdmin;
        VM_AdminTable vm_AdminTable;

        public UC_GestionTables()
        {
            InitializeComponent();
            vm_AdminTable = new VM_AdminTable();
            DataContext = vm_AdminTable;

            btnModifier.Visibility = Visibility.Hidden;
            btnSupprimer.Visibility = Visibility.Hidden;
        }

        //-----------------------------------------------------------------------------

        #region Boutons
        private void RetourMenuAdmin_Click(object sender, RoutedEventArgs e)
        {
            mainPageAdmin = new UC_MainPageAdmin();
            GestionEcran.ChangerEcran(mainPageAdmin);
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            ModaleAdminTables modaleAdminTables = new ModaleAdminTables(vm_AdminTable);
            modaleAdminTables.ShowDialog();
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            if (dgTables.SelectedValue != null)
            {
                Table table = (Table)dgTables.SelectedItem;

                dgTables.SelectedItem = null;
                ModaleAdminTables modaleAdminTables = new ModaleAdminTables(vm_AdminTable, table);
                modaleAdminTables.ShowDialog();

            }
            else
            {
                MessageBox.Show("Veillez selectionner une table à modifier en premier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (dgTables.SelectedValue != null)
            {
                Table table = (Table)dgTables.SelectedItem;

                MessageBoxResult result = MessageBox.Show("Vous êtes sur le point de supprimer la " + table + ". Êtes-vous sûr?", "Attention", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    dgTables.SelectedItem = null;
                    vm_AdminTable.SupprimerTable(table);
                }

            }
            else
            {
                MessageBox.Show("Veillez selectionner une table à supprimer en premier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        #endregion

        //---------------------------------------------------------------------------

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Gestion des tables";
        }

        //---------------------------------------------------------------------------

        private void dgTables_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
            if (dgTables.SelectedValue != null)
            {
                Table table = (Table)dgTables.SelectedItem;

                if (table.Etat == "Occupée")
                {
                    btnModifier.Visibility = Visibility.Hidden;
                    btnSupprimer.Visibility = Visibility.Hidden;
                }
                else
                {
                    btnModifier.Visibility = Visibility.Visible;
                    btnSupprimer.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
