using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    public class CommandeFournisseurItems
    {
        public int Id { get; set; }
        public CommandeFournisseur CommandeFournisseur { get; set; }
        //public Ingredient Ingredient { get; set; }
        public int QuantiteItem { get; set; }
    }
}
