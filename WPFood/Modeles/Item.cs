using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFood.Outils;

namespace WPFood.Modeles
{
    public class Item
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }

        public List<CommandeClientItem>? CommandeClientsItem { get; set; }
        public string Categorie { get; set; }
        public string? Note { get; set; }
        public string? Asset { get; set; }

        public Item()
        {
            Asset = ImageGlobale.PATH_ASSET + "Item" + Id + ".png";
        }

        public Item(string nomItem)
        {
            Nom = nomItem;
            Asset = ImageGlobale.PATH_ASSET + "Item" + Id + ".png";
        }

        public override string ToString()
        {
            return this.Nom;
        }

    }
}
