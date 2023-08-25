using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WPFood.Modeles;
using WPFood.Outils;
using Menu = WPFood.Modeles.Menu;
using MenuItem = WPFood.Modeles.MenuItem;

namespace WPFood.VuesModeles.VM_Administrateur
{
    public class VM_Admin_MenuItem : INotifyPropertyChanged
    {
        public bool itemExiste = false;
        Menu menSelect;
        public VM_Admin_MenuItem(Menu menu)
        {
            ListeItems = new ObservableCollection<Item>();
            ListeItemsComplet = new ObservableCollection<Item>();
            menSelect = menu;
            InitMenuItem(menu);
            InitToutLesItems();
        }

        public VM_Admin_MenuItem()
        {

        }

        private void InitToutLesItems()
        {
            ListeItemsComplet = new ObservableCollection<Item>();

            var micRequete =
                from toutitem 
                in OutilsEF.WPFoodContext.Items 
                orderby toutitem.Categorie
                select toutitem;
            foreach (Item itemcomplet in micRequete)
            {
                ListeItemsComplet.Add(itemcomplet);
            }

           
        }

        private void InitMenuItem(Menu menuSelect)
        {
            ListeItems = new ObservableCollection<Item>();

            var miRequete = 
                from menuitem 
                in OutilsEF.WPFoodContext.MenusItems.Include("Item") 
                where menuitem.Menu.Id == menuSelect.Id
                orderby menuitem.Item.Categorie
                select menuitem;
            foreach (MenuItem menIt in miRequete)
            {
                ListeItems.Add(menIt.Item);
            }
        }

        public void ResetAffichage()
        {           
            InitToutLesItems();  
            InitMenuItem(menSelect);
        }

        public void ModifierUnItem(int idItem,string nomItem,string categorieItem,string prixItem)
        {
            Item iModifier = OutilsEF.WPFoodContext.Items.Find(idItem);
            if (nomItem.Length > 0 && categorieItem.Length > 0 && prixItem.Length > 0)
            {
                iModifier.Nom = nomItem;
                iModifier.Categorie = categorieItem;
                //Gerer le probleme des points et des virgules
                iModifier.Prix = TransformerPrix(prixItem);
                MessageBox.Show("L'item a bien été modifié");
                OutilsEF.WPFoodContext.SaveChanges();
                ResetAffichage();

            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout de l'item.Assurez-vous que les champs soit bien remplis.","Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ModifierItemImage(Item item)
        {
            string nomFichier;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                nomFichier = openFileDialog.FileName;

                BitmapImage bmi = new BitmapImage();
                bmi.BeginInit();
                bmi.UriSource = new Uri(nomFichier);
                bmi.EndInit();

                string nomFichierDestination = $"Item{item.Id}.png";
                ImageGlobale.TeleverserFichier(bmi.UriSource.LocalPath, nomFichierDestination);
                item.Asset = $"{ImageGlobale.PATH_ASSET}{nomFichierDestination}";
                nomImageModifier = nomFichierDestination;
            }
        }

        public void AjoutItemAuMenu(List<Item> lstItemAAjouter)
        {
            foreach (Item item in lstItemAAjouter)
            {
                if (!(ListeItems.Contains(item)))
                {
                    ListeItems.Add(item);
                }
                
            }
        }

        public void SupprimerItemMenu(Item itemASupprimer)
        {
            ListeItems.Remove(itemASupprimer);

        }

        public void SupprimerItemDispo(List<Item> lstItemDispoASupprimer)
        {
            foreach (Item item in lstItemDispoASupprimer)
            {
                ListeItemsComplet.Remove(item);
                OutilsEF.WPFoodContext.Items.Remove(item);
            }
            OutilsEF.WPFoodContext.SaveChanges();
        }

        //fait une requete sur le serveur ftp et regarde si a la création de l'item un image avec son ID existe.
        //Sinon, lui assigne une image par défault.
        private void CheckImageExists(Item item)
        {
            var request = (FtpWebRequest)WebRequest.Create(ImageGlobale.FTP_ITEM_IMAGE + "Item" + item.Id + ".png");
            request.Credentials = new NetworkCredential(ImageGlobale.UTILISATEUR, ImageGlobale.MDP);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                item.Asset = ImageGlobale.PATH_ASSET + "Item" + item.Id + ".png";
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    //Si l'image n'existe pas 
                    //lui assigne une image par défaut
                    item.Asset = ImageGlobale.PATH_ASSET + "default.png";
                }
            }
        }

        public bool CrerUnItemMenu(string nomItem,string categorieItem,string prixItem)
        {
            // Mettre le nom avec la premiere lettre en majuscule
            string nomItemEnMajuscule = nomItem.First().ToString().ToUpper() + nomItem.Substring(1);

            if (nomItem.Length > 0 && categorieItem.Length > 0 && prixItem.Length > 0)
            {
                foreach (var item in ListeItemsComplet)
                {
                    if(nomItemEnMajuscule == item.Nom)
                    {
                        itemExiste = true;
                    }
                }
                if (!itemExiste)
                {
                    ListeItemsComplet = new ObservableCollection<Item>();

                    Item i = new Item();
                    i.Nom = nomItemEnMajuscule;
                    i.Categorie = categorieItem;                   
                    i.Prix = TransformerPrix(prixItem);
                    i.Note = "";

                    ListeItemsComplet.Add(i);

                    OutilsEF.WPFoodContext.Items.Add(i);
                    OutilsEF.WPFoodContext.SaveChanges();                    

                    CheckImageExists(i);
                    



                    InitToutLesItems();
                    return true;
                }
                else
                {
                    return false;
                }               
            }
            else
            {
                return false;
            }           
        }

        private double TransformerPrix(string prixItem)
        {
            string prixATransformer = prixItem.Replace(',', '.');
            double prixTransformer = Convert.ToDouble(prixATransformer);
            return prixTransformer;
        }

        private ObservableCollection<Item> _listeItems;
        public ObservableCollection<Item> ListeItems
        {
            get { return _listeItems; }
            set
            {
                _listeItems = value;
                if (_listeItems == null)
                    return;
                OnPropertyChanged("ListeItems");
            }
        }

        private ObservableCollection<Item> _listeItemsComplet;
        public ObservableCollection<Item> ListeItemsComplet
        {
            get { return _listeItemsComplet; }
            set
            {
                _listeItemsComplet = value;
                if (_listeItemsComplet == null)
                    return;
                OnPropertyChanged("ListeItemsComplet");
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }

        public string nomImageModifier;
    }


}
