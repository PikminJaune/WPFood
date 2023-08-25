using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    public class CommandeFournisseur
    {
        public int Id { get; set; }

        //public List<Ingredient> Ingredients { get; set; }

        public List<CommandeFournisseurItems> CommandesFournisseursItems { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCommande { get; set; }
        public float PrixTotal { get; set; }


    }
}
