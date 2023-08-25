using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WPFood.VuesModeles.VM_Serveur;
using WPFood.VuesModeles.VM_Hote;

namespace WPFood.Vues.UC_Serveur
{
    /// <summary>
    /// Logique d'interaction pour UC_ServeurPayer.xaml
    /// </summary>
    public partial class UC_ServeurPayer : UserControl
    { 
        VM_serveurPayer vM_ServeurPayer { get; set; }
        VM_Hote vm_hote { get; set; }
        public UC_ServeurPayer(Table table)
        {
            InitializeComponent();
            Table = table;
            vM_ServeurPayer = new VM_serveurPayer(Table);
            vm_hote = new VM_Hote();
            DataContext = vM_ServeurPayer;
            ServeurGlobale.IdsclientsSelectiones = new List<int>();

            SelectionnerPremierClient();

        }

        private void SelectionnerPremierClient()
        {
            if (vM_ServeurPayer != null && vM_ServeurPayer.Clients.Count > 0)
            {
                Client premierClient = vM_ServeurPayer.Clients[0];
                LVClients.SelectedItem = premierClient;
                     
                if (premierClient != null)
                {
                    ServeurGlobale.IdsclientsSelectiones.Add(premierClient.Id);
                    vM_ServeurPayer.AddItemClient(premierClient);
                }
            }
        }

        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //click ici = dire que je veux ajoute sa commande au paiement.
            ListViewItem? lvItem = sender as ListViewItem;

            if (lvItem != null)
            {
                Client? client = lvItem.DataContext as Client;
                if (lvItem.IsSelected)
                {
                    //Ajoute
                    ServeurGlobale.IdsclientsSelectiones.Add(client!.Id);
                    
                    vM_ServeurPayer.AddItemClient(client);
                }
                else
                {
                    //Si on click et que le lvItem n'est pas selected, on remove.
                    ServeurGlobale.IdsclientsSelectiones.Remove(client!.Id);
                    vM_ServeurPayer.RemoveItemClient(client);
                }

            }
        }


        public Table Table { get; set; }

        private void btn_retour_Click(object sender, RoutedEventArgs e)
        {
            UserControl serveurCommande = new UC_Serveur();
            GestionEcran.ChangerEcran(serveurCommande);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Server - paiement";
        }

        private void btn_payer_Click(object sender, RoutedEventArgs e)
        {
            vM_ServeurPayer.Paiement();
        }

        private void btn_demandeDeNettoyage_Click(object sender, RoutedEventArgs e)
        {
            vm_hote.ModifierTable(Table, "A Nettoyer", 0);
        }
    }
}
