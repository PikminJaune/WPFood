using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using WPFood.VuesModeles.VM_Connexion;
using WPFood.Outils;
using System.IO;

namespace WPFood.Vues.UC_Connexion
{
    /// <summary>
    /// Logique d'interaction pour UC_Connexion.xaml
    /// </summary>
    public partial class UC_Connexion : UserControl
    {
        VM_Connexion vmc;
        public static readonly string BaseUri = "pack://application:,,,/WPFood;component";
        public UC_Connexion()
        {
            DataContext = new VM_Connexion();
            InitializeComponent();
            vmc = new VM_Connexion();

        }
        // Bouton de connexion 
        private void btn_MainConnexion(object sender, RoutedEventArgs e)
        {
            // si on se connecte  , donc si la méthode retourne vrai on vide les champs pour quand l'utilisateur va se deconnecter 
            if(vmc.ValiderConnexion(txbUtilisateur.Text, pwbPassword.Password))
            {
                txbUtilisateur.Text = "";
                pwbPassword.Password = "";
            }
        }

       
    }
}
