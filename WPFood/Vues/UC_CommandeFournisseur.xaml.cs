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
using WPFood.Vues.UC_Cuisinier;

namespace WPFood.Vues
{
    /// <summary>
    /// Logique d'interaction pour UC_CommandeFournisseur.xaml
    /// </summary>
    public partial class UC_CommandeFournisseur : UserControl
    {
        string stringPourBoutonRetour = "";

        public UC_CommandeFournisseur(string pageDeRetour)
        {
            InitializeComponent();
            stringPourBoutonRetour = pageDeRetour;
        }

        private void btn_ClickRetour(object sender, RoutedEventArgs e)
        {
            switch (stringPourBoutonRetour)
            {
                case "pageCuisinier":
                    GestionEcran.ChangerEcran(new UC_MainPageCuisinier());
                    break;
                case "pageAdmin":
                    GestionEcran.ChangerEcran(new UC_GestionStock());
                    break;
            }

        }

        private void btnClick_VoirHistoriqueCommandes(object sender, RoutedEventArgs e)
        {
            GestionEcran.ChangerEcran(new UC_HistoriqueCommandeFournisseur(stringPourBoutonRetour));
        }
    }
}
