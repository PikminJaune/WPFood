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
using WPFood.Vues.UC_Admin;

namespace WPFood.Vues
{
    /// <summary>
    /// Logique d'interaction pour UC_HistoriqueCommandeFournisseur.xaml
    /// </summary>
    public partial class UC_HistoriqueCommandeFournisseur : UserControl
    {
        string pageRetour = "";
        public UC_HistoriqueCommandeFournisseur(string pageDeRetour)
        {
            InitializeComponent();
            pageRetour = pageDeRetour;
        }

        private void btn_ClickRetour(object sender, RoutedEventArgs e)
        {
            switch (pageRetour)
            {
                case "pageCuisinier":
                    GestionEcran.ChangerEcran(new UC_CommandeFournisseur("pageCuisinier"));
                    break;
                case "pageAdmin":
                    GestionEcran.ChangerEcran(new UC_CommandeFournisseur("pageAdmin"));
                    break;
            }

            
            
        }
    }
}
