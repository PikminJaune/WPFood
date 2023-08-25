using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace WPFood.Modeles
{
    public class ItemClient : Item, INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }
        #endregion 

        public ItemClient(Item item)
        {
            this.Nom = item.Nom;
            this.Prix = item.Prix;
            Quantite = 1;
            
        }

        public ItemClient(Item item, int quantite)
        {
            Nom = item.Nom;
            Prix = item.Prix;
            Quantite = quantite;
        }

        public override string ToString()
        {
            return $"{Nom}, {Quantite}    {Note}";
        }

        private int _quantite { get; set; }
        public int Quantite
        {
            get { return _quantite; }
            set
            {
                if (value == null)
                    return;
                _quantite = value;
                OnPropertyChanged("Quantite");
            }
        }
    }
}
