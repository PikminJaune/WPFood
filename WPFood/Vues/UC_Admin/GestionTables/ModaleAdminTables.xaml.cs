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
using System.Windows.Shapes;
using WPFood.Modeles;
using WPFood.VuesModeles.VM_Administrateur;

namespace WPFood.Vues.UC_Admin.GestionTables
{
    /// <summary>
    /// Logique d'interaction pour ModaleAdminTables.xaml
    /// </summary>
    public partial class ModaleAdminTables : Window
    {
        VM_AdminTable vm_AdminTable;

        public ModaleAdminTables(VM_AdminTable vmAdminTable, Table? table = null)
        {
            InitializeComponent();
            vm_AdminTable = vmAdminTable;

            //Ajouter une table
            if (table == null)
            {
                ModaleType.Text = "Ajouter une table";
                Option = "Ajouter";
                btnAjoutModif.Content = Option;
            }

            //Modifier une table
            else
            {
                ModaleType.Text = "Modifier une table";
                Option = "Modifier";
                btnAjoutModif.Content = Option;

                TableSelectionne = table;

                tbNbPlaceMax.Text = table.NbPlacesMax.ToString();

            }
        }

        //----------------------------------------------------------------

        #region Props

        private string? _option;

        public string? Option
        {
            get { return _option; }
            set
            {
                _option = value;
            }
        }

        //-------------------------

        private Table? _tableSelectionne;

        public Table? TableSelectionne
        {
            get { return _tableSelectionne; }
            set
            {
                _tableSelectionne = value;
            }
        }

        #endregion

        //----------------------------------------------------------------

        #region Boutons

        private void BtnAjoutModif_Click(object sender, RoutedEventArgs e)
        {
            //Si les places de textes sont vides
            if (tbNbPlaceMax.Text != "")
            {
                try
                {
                    int id; //Le id va être initialisé selon l'option
                    int nbPlaceMax = int.Parse(tbNbPlaceMax.Text);

                    if (nbPlaceMax > 0)
                    {
                        //Ajouter une table
                        if (Option == "Ajouter")
                        {
                            Table table = new Table(nbPlaceMax);
                            vm_AdminTable.AjouterTable(table);
                        }

                        //Modifier une table
                        else if (Option == "Modifier")
                        {
                            id = TableSelectionne!.Id;
                            Table table = new Table(id, nbPlaceMax);
                            vm_AdminTable.ModifierTable(table);
                        }


                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Attention! Nombre de places non valide.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                        tbNbPlaceMax.Text = "";

                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Attention! Nombre de places non valide.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbNbPlaceMax.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Veillez entrer un nombre de table maximum", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

        }

        #endregion

    }
}
