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
using WPFood.VuesModeles.VM_Administrateur;

namespace WPFood.Vues.UC_Admin.Menu_et_Items
{
    /// <summary>
    /// Logique d'interaction pour Modale_Modifier_Item.xaml
    /// </summary>
    public partial class Modale_Modifier_Item : Window
    {
        VM_Admin_MenuItem VMami;
        Item itemModif;
        public Modale_Modifier_Item(VM_Admin_MenuItem vmAdminMenuItem,Item itemAModifier)
        {
            InitializeComponent();
            VMami = vmAdminMenuItem;
            itemModif = itemAModifier;
            txbNomItem.Text = itemModif.Nom;
            cbxCategorieItem.Text = itemModif.Categorie;
            txbPrixItem.Text = itemModif.Prix.ToString();
            tbImageName.Text = itemModif.Asset.Split('/')[6]; //va chercher seulement le nom de l'image et non le path au complet.
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Modifier un menu";
        }

        private void btnClick_ModifierItem(object sender, RoutedEventArgs e)
        {

            VMami.ModifierUnItem(itemModif.Id, txbNomItem.Text, cbxCategorieItem.Text, txbPrixItem.Text);
            this.Close();
        }

        private void btnModifierImage_Click(object sender, RoutedEventArgs e)
        {
            VMami.ModifierItemImage(itemModif);
            tbImageName.Text = VMami.nomImageModifier;

        }
    }
}
