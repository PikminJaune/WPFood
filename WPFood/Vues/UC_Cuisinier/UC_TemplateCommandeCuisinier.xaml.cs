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
using WPFood.VuesModeles.VM_Cuisinier;

namespace WPFood.Vues.UC_Cuisinier
{
    /// <summary>
    /// Logique d'interaction pour UC_TemplateCommandeCuisinier.xaml
    /// </summary>
    public partial class UC_TemplateCommandeCuisinier : UserControl
    {
        VM_Cusinier VMcui;
        public int idTableSelect;
        CommandeClient ccSelect;
        public UC_TemplateCommandeCuisinier(commandeCuisinier laCommandeCuisinier)
        {
            InitializeComponent();
            VMcui = new VM_Cusinier();
            numeroTable.Content = "#" + laCommandeCuisinier.idTable;
            ccSelect = laCommandeCuisinier.Commande;

            heureCommander.Text = laCommandeCuisinier.Commande.Date.ToString("HH:mm");

            foreach (var item in laCommandeCuisinier.CCItems)
            {
                lbCommandeCuisinier.Items.Add(item.ToNote());              
            }
        }

        private void btn_ClickTerminer(object sender, RoutedEventArgs e)
        {           
           VMcui.TerminerUneCommande(ccSelect);    
           MessageBox.Show("La commande à la table #" + ccSelect.Client.IdTable + " est terminée");
        }
    }
}
