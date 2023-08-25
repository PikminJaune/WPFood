using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    public class CommandeClientItem
    {
        public int Id { get; set; }

        public CommandeClient CommandeClient { get; set; }
        public Item item { get; set; }
        public int Quantite { get; set; }
        public string? Note { get; set; }


        public CommandeClientItem(Item monItem, CommandeClient commandeClient, int quantite,string note)
        {
            item = monItem;
            CommandeClient = commandeClient;
            Quantite = quantite;
            Note = note;

        }
        public CommandeClientItem()
        {

        }

        public override string ToString()
        {
            return $"{item.Nom}, {Quantite}";
        }


        public string ToNote()
        {
            if (Note == null)
            {
                return $"{item.Nom} x{Quantite}";
            }
            else
            {
                return $"{item.Nom}     x{Quantite}     , NOTE : {Note}";
            }
        }

    }
}
