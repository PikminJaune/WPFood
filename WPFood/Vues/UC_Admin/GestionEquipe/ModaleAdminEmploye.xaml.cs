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
using WPFood.Modeles;
using WPFood.VuesModeles.VM_Administrateur;

namespace WPFood.Vues.UC_Admin.GestionEquipe
{
    /// <summary>
    /// Logique d'interaction pour ModaleAdminEmploye.xaml
    /// </summary>
    public partial class ModaleAdminEmploye : Window
    {
        VM_AdminEquipe vM_Admin;

        public ModaleAdminEmploye(VM_AdminEquipe vm_Admin, Employe? employe = null)
        {
            InitializeComponent();
            vM_Admin = vm_Admin;
            DataContext = vM_Admin;

            //Ajouter un employé
            if (employe == null)
            {
                Option = "Ajouter";
                btnAjoutModif.Content = Option;
            }

            //Modifier un employé
            else
            {
                Option = "Modifier";
                btnAjoutModif.Content = Option;

                EmployeSelectionne = employe;

                tbNom.Text = employe.Nom;
                tbPrenom.Text = employe.Prenom;
                cbFonction.SelectedValue = employe.Fonction;
                tbIdentifiant.Text = employe.Identifiant;
                tbMDP.Text = employe.MotDePasse;
                dpDateNaissance.Text = employe.DateNaissance.ToString();
                tbGenre.Text = employe.Genre;

            }

            dpDateNaissance.Focusable = false;
            ModaleType.Text = Option;

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

        private Employe? _employeSelectionne;

        public Employe? EmployeSelectionne
        {
            get { return _employeSelectionne; }
            set
            {
                _employeSelectionne = value;
            }
        }

        #endregion

        //----------------------------------------------------------------

        #region Boutons

        private void BtnAjoutModif_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbNom.Text != "" &&
                    tbPrenom.Text != "" && 
                    cbFonction.SelectedItem.ToString() != "" && 
                    tbIdentifiant.Text != "" 
                    && tbMDP.Text != "" 
                    && dpDateNaissance.Text != "" 
                    && tbGenre.Text != "")
                {
                    int id;
                    string nom = tbNom.Text;
                    string prenom = tbPrenom.Text;
                    string fonction = cbFonction.Text;
                    string identifiant = tbIdentifiant.Text;
                    string motdepasse = tbMDP.Text;
                    DateTime dateNaissance = Convert.ToDateTime(dpDateNaissance.Text);
                    string genre = tbGenre.Text;

                    bool doublon = false;

                    //--------------------------------------------------------------------------------------------------------
                    //Vérification des doublons
                    if (Option == "Ajouter")
                    {
                        foreach (Employe em in vM_Admin.LstEmployes!)
                        {
                            if (em.Identifiant == identifiant)
                            {
                                doublon = true;
                            }
                        }

                        if (doublon)
                        {
                            MessageBox.Show("Cet identifiant est déjà utilisé.", "Attention.", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                    //------------------------------------------

                    if (Option == "Modifier")
                    {
                        //Nombre de fois que l'identifiant est rencontré
                        int identif = 0;

                        foreach (Employe em in vM_Admin.LstEmployes!)
                        {
                            //Si on ne change pas son identifiant il devrait être là une seule fois
                            //Si l'identifiant et le ID provient de la même personne
                            if (em.Identifiant == identifiant && em.Id == EmployeSelectionne!.Id)
                            {
                                identif++;
                            }
                            //Si l'identifiant ne provient pas de la même personne, il ne devrait jamais être lu une autre fois
                            else if (em.Identifiant == identifiant)
                            {
                                doublon = true;
                            }
                        }

                        if (identif > 1)
                        {
                            doublon = true;
                        }

                        if (doublon)
                        {
                            MessageBox.Show("Cet identifiant est déjà utilisé.", "Attention.", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                    //--------------------------------------------------------------------------------------------------------

                    if (!doublon)
                    {

                        //Ajouter un employé
                        if (Option == "Ajouter")
                        {
                            Employe employe = new Employe(nom, prenom, fonction, identifiant, motdepasse, dateNaissance, genre);
                            vM_Admin.AjouterEmploye(employe);
                        }

                        //Modifier un employé
                        else if (Option == "Modifier")
                        {
                            id = EmployeSelectionne!.Id;
                            Employe employe = new Employe(id, nom, prenom, fonction, identifiant, motdepasse, dateNaissance, genre);
                            vM_Admin.ModifierEmploye(employe);
                        }

                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Attention! Un ou plusieurs champs sont vides!", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
