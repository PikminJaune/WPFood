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
using WPFood.Vues.UC_Admin.GestionEquipe;
using WPFood.VuesModeles.VM_Admin;
using WPFood.VuesModeles.VM_Administrateur;

namespace WPFood.Vues.UC_Admin
{
    /// <summary>
    /// Logique d'interaction pour UC_GestionEquipe.xaml
    /// </summary>
    public partial class UC_GestionEquipe : UserControl
    {
        UC_MainPageAdmin mainPageAdmin;
        VM_AdminEquipe vM_Admin;

        //-----------------------------------------------------------------------------

        public UC_GestionEquipe()
        {
            InitializeComponent();
            vM_Admin = new VM_AdminEquipe();
            DataContext = vM_Admin;
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
            ModaleAdminEmploye modaleAdminEmploye = new ModaleAdminEmploye(vM_Admin);
            modaleAdminEmploye.ShowDialog();

        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployes.SelectedValue != null)
            {
                ModaleAdminEmploye modaleAdminEmploye = new ModaleAdminEmploye(vM_Admin, (Employe)dgEmployes.SelectedItem);
                modaleAdminEmploye.ShowDialog();
            }
            else
            {
                MessageBox.Show("Veillez selectionner un employé à modifier en premier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployes.SelectedValue != null)
            {
                Employe employe = (Employe)dgEmployes.SelectedItem;
                MessageBoxResult result = MessageBox.Show("Vous êtes sur le point de supprimer l'employé: " + employe.Prenom + " " + employe.Nom + " Êtes-vous sûr?", "Erreur", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    vM_Admin.SupprimerEmploye(employe);
                }
            }
            else
            {
                MessageBox.Show("Veillez selectionner un employé à supprimer en premier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion

        //-----------------------------------------------------------------------------

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Gestion de l'équipe";
        }
    }
}
