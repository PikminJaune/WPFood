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
using WPFood.Outils;

using LiveCharts;
using LiveCharts.Wpf;
using WPFood.VuesModeles.VM_Administrateur;
using System.ComponentModel;
using System.Collections.ObjectModel;
using LiveCharts.Defaults;
using System.Diagnostics;
using WPFood.Modeles;
using WPFood.VuesModeles.VM_Hote;
using Table = WPFood.Modeles.Table;
using Microsoft.EntityFrameworkCore;

namespace WPFood.Vues.UC_Admin
{
    /// <summary>
    /// Logique d'interaction pour UC_AfficherStatistiques.xaml
    /// </summary>
    public partial class UC_AfficherStatistiques : UserControl, INotifyPropertyChanged
    {
        UC_MainPageAdmin mainPageAdmin;
        VM_AdminEquipe vM_Admin;
        VM_Admin_Stats admin_Stats;

        public UC_AfficherStatistiques()
        {
            InitializeComponent();
            vM_Admin = new VM_AdminEquipe();
            admin_Stats = new VM_Admin_Stats();

            //---------------------------------------------------------------------------------

            #region Employes

            NbHote = vM_Admin.LstEmployes.Where(e => e.Fonction == "Hote").Count();
            NbServeur = vM_Admin.LstEmployes.Where(e => e.Fonction == "Serveur").Count();
            NbCuisinier = vM_Admin.LstEmployes.Where(e => e.Fonction == "Cuisinier").Count();
            NbAdmin = vM_Admin.LstEmployes.Where(e => e.Fonction == "Admin").Count();

            PieHote.Values.Add(NbHote);
            PieServeur.Values.Add(NbServeur);
            PieCuisinier.Values.Add(NbCuisinier);
            PieAdmin.Values.Add(NbAdmin);


            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            tbEmployes.Text = "Nombre total d'employés: " + vM_Admin.LstEmployes.Count();
            #endregion

            //---------------------------------------------------------------------------------

            #region Clients
            cbHeuresDebut.ItemsSource = vM_Admin.LstHeures;
            cbHeuresFin.ItemsSource = vM_Admin.LstHeures;
            txtClients.Text = "";

            #endregion

            //---------------------------------------------------------------------------------

            #region Affaire           
            LstObjets = new ObservableCollection<ObjetStatistique>();

            #endregion

            //---------------------------------------------------------------------------------

            DataContext = this;
        }

        #region SeriesCollection
        public Func<ChartPoint, string> PointLabel { get; set; }
        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Props
        private double _nbHote;

        public double NbHote
        {
            get { return _nbHote; }
            set
            {
                _nbHote = value;
                OnPropertyChanged("NbHote"); // Called OnPropertyChanged()
            }
        }
        //---------------------------------------------------------------
        private double _nbServeur;

        public double NbServeur
        {
            get { return _nbServeur; }
            set
            {
                _nbServeur = value;
                OnPropertyChanged("NbServeur"); // Called OnPropertyChanged()
            }
        }
        //---------------------------------------------------------------
        private double _nbCuisinier;

        public double NbCuisinier
        {
            get { return _nbCuisinier; }
            set
            {
                _nbCuisinier = value;
                OnPropertyChanged("NbCuisinier"); // Called OnPropertyChanged()
            }
        }
        //---------------------------------------------------------------

        private double _nbAdmin;

        public double NbAdmin
        {
            get { return _nbAdmin; }
            set
            {
                _nbAdmin = value;
                OnPropertyChanged("NbAdmin"); // Called OnPropertyChanged()
            }
        }

        //---------------------------------------------------------------
        private double _nbClient;

        public double NbClient
        {
            get { return _nbClient; }
            set
            {
                _nbClient = value;
                OnPropertyChanged("NbClient"); // Called OnPropertyChanged()
            }
        }

        //---------------------------------------------------------------

        private ObservableCollection<ObjetStatistique>? _lstObjets;

        public ObservableCollection<ObjetStatistique>? LstObjets
        {
            get
            {
                return _lstObjets;
            }
            set
            {
                _lstObjets = value;
                if (_lstObjets == null)
                    return;
                OnPropertyChanged("LstObjets");
            }
        }
        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Autres
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Afficher les statistiques";
        }

        private void RetourMenuAdmin_Click(object sender, RoutedEventArgs e)
        {
            mainPageAdmin = new UC_MainPageAdmin();
            GestionEcran.ChangerEcran(mainPageAdmin);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            //Raise PropertyChanged event
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        /// <summary>
        /// Lors d'un changement dans les zones de Nombre de clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateHeure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateDebut = Convert.ToDateTime(dpDateClientDebut.SelectedDate);
            DateTime dateFin = Convert.ToDateTime(dpDateClientFin.SelectedDate);
            string heureDebut = "";
            string heureFin = "";

            if (cbHeuresDebut.SelectedValue != null)
            {
                heureDebut = cbHeuresDebut.SelectedValue.ToString()!;
            }

            if (cbHeuresFin.SelectedValue != null)
            {
                heureFin = cbHeuresFin.SelectedValue.ToString()!;
            }

            //----------------------------------------------------------------------------------------

            if (heureDebut != "" && heureFin != "" && dateDebut.ToString() != "0001-01-01 00:00:00" && dateFin.ToString() != "0001-01-01 00:00:00")
            {
                string dateD = dateDebut.Year.ToString() + "-" + dateDebut.Month.ToString() + "-" + dateDebut.Day.ToString() + " " + heureDebut;
                DateTime dateDebutPrecis = Convert.ToDateTime(dateD);

                string dateF = dateFin.Year.ToString() + "-" + dateFin.Month.ToString() + "-" + dateFin.Day.ToString() + " " + heureFin;
                DateTime dateFinPrecis = Convert.ToDateTime(dateF);


                int nbClient = admin_Stats.GetNombreClients(dateDebutPrecis, dateFinPrecis);



                txtClients.Text = nbClient.ToString();
                txtClients.Text = txtClients.Text + " clients";
            }
        }

        /// <summary>
        /// Click du bouton de lancement de recherche de Popularité
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLancerRecherche_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateDebut = Convert.ToDateTime(dpDateAffairesDebut.SelectedDate);
            DateTime dateFin = Convert.ToDateTime(dpDateAffairesFin.SelectedDate);

            if (dateDebut.ToString() != "0001-01-01 00:00:00" && dateFin.ToString() != "0001-01-01 00:00:00")
            {
                //TODO
                LstObjets = new ObservableCollection<ObjetStatistique>();
                //LstObjets.Add(new ObjetStatistique(commandeClientItem.item.ToString(), commandeClientItem.Quantite));

                List<string> lstNomsItems = admin_Stats.GetNomsItems(dateDebut, dateFin);

                foreach (string nomItem in lstNomsItems)
                {
                    LstObjets.Add(new ObjetStatistique(nomItem, admin_Stats.GetNbFoisCommande(nomItem, dateDebut, dateFin)));
                }

            }
            else
            {
                MessageBox.Show("Attention! Les entrées ne sont pas correctes", "Attention!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
    }
}
