using MaterialDesignThemes.Wpf;
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

namespace WPFood.Vues.UC_Client
{
    /// <summary>
    /// Logique d'interaction pour UC_CommentaireTemplate.xaml
    /// </summary>
    public partial class UC_CommentaireTemplate : UserControl
    {
        public UC_CommentaireTemplate(string contenuMessage, string nomClient, bool estRecommander, string nomServeur, DateTime dateMessage)
        {
            InitializeComponent();
            DataContext = this;

            ContenuMessage = contenuMessage;
            NomClient = nomClient;
            formatEstRecommande(estRecommander);
            NomServeur = nomServeur;
            DateMessage = dateMessage;
        }
        
        public void formatEstRecommande(bool estRecommander)
        {
            if (estRecommander)
            {
                EstRecommande = "Recommandé";
                TextRecommandation = $"{NomClient} nous recommande !";
                Icon = PackIconKind.ThumbsUpOutline.ToString();
                MyPackIcon.Foreground = new SolidColorBrush(Colors.GreenYellow);
            }
            else
            {
                EstRecommande = "Non Recommandé";
                TextRecommandation = $"{NomClient} ne nous recommande pas";
                Icon = PackIconKind.ThumbsDownOutline.ToString();
                MyPackIcon.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        public string ContenuMessage { get; set; }
        public string NomClient { get; set; }
        public string  EstRecommande { get; set; }
        public string NomServeur { get; set; }
        public DateTime DateMessage { get; set; }
        public string Icon { get; set; }
        public string TextRecommandation { get; set; }

    }
}
