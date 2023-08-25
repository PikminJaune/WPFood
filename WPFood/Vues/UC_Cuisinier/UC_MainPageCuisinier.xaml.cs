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
using WPFood.Modeles;
using WPFood.Outils;
using WPFood.VuesModeles.VM_Cuisinier;

namespace WPFood.Vues.UC_Cuisinier
{
    /// <summary>
    /// Logique d'interaction pour UC_MainPageCuisinier.xaml
    /// </summary>
    public partial class UC_MainPageCuisinier : UserControl
    {
        VM_Cusinier VMcui;
        public UC_MainPageCuisinier()
        {
            InitializeComponent();           
            VMcui = new VM_Cusinier();
            DataContext = VMcui;

            VMcui.GenererCommandeCuisinier(this);

            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            txbtempsActuel.Text = DateTime.Now.ToString("HH:mm:ss");
            VMcui.GenererCommandeCuisinier(this);
            CommandManager.InvalidateRequerySuggested();
        }

        private void btn_ClickCommandeFournisseur(object sender, RoutedEventArgs e)
        {
            UC_CommandeFournisseur ucCF = new UC_CommandeFournisseur("pageCuisinier");
            GestionEcran.ChangerEcran(ucCF);
        }
    }
}
