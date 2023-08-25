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
using WPFood.Outils;
using WPFood.VuesModeles.VM_Serveur;

namespace WPFood.Vues.UC_Serveur
{
    /// <summary>
    /// Logique d'interaction pour Modale_Note_Serveur.xaml
    /// </summary>
    public partial class Modale_Note_Serveur : Window
    {
        VM_Serveur _instanceServeur;
        string _nomItem;
        public Modale_Note_Serveur(VM_Serveur vmserv,string nomItem)
        {
            InitializeComponent();
            _instanceServeur = vmserv;
            _nomItem = nomItem;
            
        }

        private void BtnClick_AjouterNote(object sender, RoutedEventArgs e)
        {
            _instanceServeur.AddNoteToItem(_nomItem, txbNote.Text);
            this.Close();
        }

        public string Note { get { return txbNote.Text; } }

    }
}
