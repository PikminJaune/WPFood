using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    public class commandeCuisinier
    {
        public int idTable { get; set; }
        public List<CommandeClientItem> CCItems { get; set; }
        public CommandeClient Commande { get; set; }
        public string Note { get; set; }

        public commandeCuisinier(int IdTable, List<CommandeClientItem> cCItems, CommandeClient commande, string note="")
        {

            idTable = IdTable;
            CCItems = cCItems;
            Commande = commande;
            Note = note;
        }


    }
}
