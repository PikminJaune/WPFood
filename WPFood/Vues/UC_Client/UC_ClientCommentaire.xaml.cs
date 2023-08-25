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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFood.Vues;
using WPFood.VuesModeles;

namespace WPFood.Vues.UC_Client
{
    /// <summary>
    /// Logique d'interaction pour UC_ClientCommentaire.xaml
    /// </summary>
    public partial class UC_ClientCommentaire : UserControl
    {
        VM_Commentaires vmCommentaires;
        public UC_ClientCommentaire()
        {
            InitializeComponent();
            vmCommentaires = new VM_Commentaires();
            DataContext = vmCommentaires;

            vmCommentaires.GenererCommentaires(this); // genere les commentaires a l'initialisation

            //  DispatcherTimer setup
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lbl_currentDate.Text = DateTime.Now.ToString();

            CommandManager.InvalidateRequerySuggested();
        }

        private void btn_ClearFormulaire_Click(object sender, RoutedEventArgs e)
        {
            tbox_nomClient.Text = "";
            tb_CommentaireClient.Text = "";
            cb_serveurs.SelectedItem = null;
            
        }

        private void rbRecommande_Checked(object sender, RoutedEventArgs e)
        {
            if (vmCommentaires != null)
            {
                vmCommentaires.EstRecommande = true;

            }
        }

        private void rbNonRecommande_Checked(object sender, RoutedEventArgs e)
        {   
            if (vmCommentaires != null)
            {
               vmCommentaires.EstRecommande = false;

            }
        }
    }
}
