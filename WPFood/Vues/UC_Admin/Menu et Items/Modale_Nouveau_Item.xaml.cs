using Microsoft.Win32;
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
using WPFood.Outils;
using WPFood.VuesModeles.VM_Administrateur;

namespace WPFood.Vues.UC_Admin.Menu_et_Items
{
    /// <summary>
    /// Logique d'interaction pour Modale_Ajouter_MenuItem.xaml
    /// </summary>
    public partial class Modale_Ajouter_MenuItem : Window
    {
        VM_Admin_MenuItem vmAdminMenuI;
        public Modale_Ajouter_MenuItem(VM_Admin_MenuItem vmAMI)
        {
            InitializeComponent();
            vmAdminMenuI = vmAMI;
                          
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Ajouter un Item";
        }

        private void btn_AjouterUnItem(object sender, RoutedEventArgs e)
        {
            if(txbNomItem.Text.Length >= 2 && txbNomItem.Text.Length <= 30)
            {
                if (vmAdminMenuI.CrerUnItemMenu(txbNomItem.Text, cbxCategorieItem.Text, txbPrixItem.Text))
                {
                    MessageBox.Show("L'item " + txbNomItem.Text + ",Categorie : " + cbxCategorieItem.Text + ", Prix : " + txbPrixItem.Text + " à été ajouté.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("L'item n'a pas été ajouté.Vérifier qu'il n'est pas déjà existant et que les champs soient bien remplis.");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Le menu doit contenir 2 lettres minimum et 30 lettres maximum.","Attention",MessageBoxButton.OK);
            }
            
            
        }

        private void btnInsertImage_Click(object sender, RoutedEventArgs e)
        {
            if (txbNomItem.Text.ToLower().Trim().Length < 2 || txbNomItem.Text.ToLower().Trim().Length > 30)
            {
                MessageBox.Show("Vous devez entrer un nom à votre item dans le bon format avant de lui assigner une image", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string nomFichier;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if ((bool)openFileDialog.ShowDialog()! )
            {
                nomFichier = openFileDialog.FileName;
                string fileExt = nomFichier.Substring(nomFichier.LastIndexOf('.') + 1).ToUpper(); // Pour aller chercher l'extension du fichier.
                if (fileExt != "PNG")
                {
                    MessageBox.Show("Malheureusement, nous n'accpetons que les images .png pour le moment.", "Erreur: Extension", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                BitmapImage bmi = new BitmapImage();
                bmi.BeginInit();
                bmi.UriSource = new Uri(nomFichier);
                bmi.EndInit();

                // + 1 Parce que lors de la creation de l'Image, l'item n,est pas encore existant et lorsqu'il va se créer il va avoir +1 que le plus gros id item 
                string nomFichierDestination = "Item" + (biggestItemId() + 1) + ".png"; 
                ImageGlobale.TeleverserFichier(bmi.UriSource.LocalPath, nomFichierDestination);
            }
        }

        private int biggestItemId()
        {
            var biggestItem = OutilsEF.WPFoodContext.Items.OrderByDescending(i => i.Id).First();
            return biggestItem.Id;
        }
    }
}
