using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPFood.Modeles;
using WPFood.Outils;
using WPFood.VuesModeles.VM_Serveur;

namespace WPFood.Vues.UC_Serveur
{
    /// <summary>
    /// Logique d'interaction pour UC_Serveur.xaml
    /// </summary>
    public partial class UC_Serveur : UserControl
    {
        private VM_Serveur Vm_serveur { get; set; }
        private DispatcherTimer dispatcherTimer { get; set; } = new DispatcherTimer();
        public UC_Serveur()
        {
            Vm_serveur = new VM_Serveur();
            InitializeComponent();
            DataContext = Vm_serveur;

            //  DispatcherTimer setup
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick); // à chaque tick de mon interval, appel la fonctione dans le evenhandler
            dispatcherTimer.Interval = new TimeSpan(0, 0, 15); // setup l'interval
            dispatcherTimer.Start(); //Part le timer
          
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Vm_serveur.InitCommandesDuClient();
            //Vm_serveur.InitTable(); //todo

            CommandManager.InvalidateRequerySuggested();
        }

        //listview du MENU
        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListViewItem? lvItem = sender as ListViewItem;

            if (lvItem != null && lvItem.IsSelected)
            {
                Item? item = lvItem.DataContext as Item;
                string NomItemClient = item!.Nom;
                if (Vm_serveur.ClientSelectionne != null)
                    Vm_serveur.AddItemClient(NomItemClient);
            }
        }

        //Listview des itemsClients
        private void LVItemsClient_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //ListViewItem? lvItem = sender as ListViewItem;
            //if (lvItem != null && lvItem.IsSelected)
            //{
            //    ItemClient? itemClient = lvItem.DataContext as ItemClient;
            //    Vm_serveur.RemoveItemClient(itemClient!);
            //}
        }

        //Changement de Sélection dans le combobox des tables
        private void cb_table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem? item = sender as ComboBoxItem;

            if (item != null && item.IsSelected)
            {
                Table? table = item.DataContext as Table;

                ServeurGlobale.IdTableSelectionnee = table!.Id;
                Vm_serveur.TableSelectionnee = table!;
            }
        }

        //lvClients_MouseLeftButtonUp
        private void lvClients_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListViewItem? lvItem = sender as ListViewItem;
            if (lvItem != null && lvItem.IsSelected)
            {
                Client? client = lvItem.DataContext as Client;
                Vm_serveur.ClientSelectionne = client!;
            }


        }

        //List view table click
        private void lvTables_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //ListViewItem LVItem = e.Source as ListViewItem;
            ListViewItem? lvItem = sender as ListViewItem;
            if (lvItem != null && lvItem.IsSelected)
            {
                Table? table = lvItem.DataContext as Table;
                Vm_serveur.TableSelectionnee = table!;
            }
        }
        
        private void btn_fairePayer_Click(object sender, RoutedEventArgs e)
        {
            //veut payer, changement de UI
            if (lvTables.SelectedItem != null)
            {
                Table table = lvTables.SelectedItem as Table;
                GestionEcran.ChangerEcran(new UC_ServeurPayer(table));
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Serveur - commandes";
        }

        private void TreeViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem? tvItem = sender as TreeViewItem;
            if (tvItem != null && tvItem.IsSelected)
            {
                //Si on click sur le treeviewItem contenant la commande et non les commandeclientitem
                if (tvItem.Header.ToString().Contains("Commande")) return;

                CommandeClientItem? CCItem = tvItem.DataContext as CommandeClientItem;

                if (CCItem == null)
                {
                    Debug.WriteLine("Commande Client Item Null");
                    return;
                }

                //Si la commande n'est pas modifiable
                if (CCItem.CommandeClient.EstTermine || CCItem.CommandeClient.EstPaye)
                {
                    MessageBox.Show("Vous pouvez seulement modifier une commande en cours (non terminé et non payé)", "Commande non modifiable", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Vm_serveur.RemoveCommandeClientItem(CCItem);
            }
        }

        private void btn_Rafraichir_Click(object sender, RoutedEventArgs e)
        {
            Vm_serveur.refreshTreeView();
            Vm_serveur.refreshItems();
        }

        private void btnClick_AjouterNote(object sender, RoutedEventArgs e)
        {
            ItemClient itemAjouterNote = LVItemsClient.SelectedItem as ItemClient;
            if (itemAjouterNote == null ) return;

            Modale_Note_Serveur MDS = new Modale_Note_Serveur(Vm_serveur,itemAjouterNote.Nom);
            MDS.ShowDialog();
        }

        private void btnClick_SupprimerItem(object sender, RoutedEventArgs e)
        {
                     
            if(LVItemsClient.SelectedItem != null)
            {
                ItemClient itemASupprimer = LVItemsClient.SelectedItem as ItemClient;
                Vm_serveur.RemoveItemClient(itemASupprimer!);
            }
        }
    }
}
