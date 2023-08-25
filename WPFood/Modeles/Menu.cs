using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    [Table("Menu")]
    public class Menu
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string Nom { get; set; }

        [MaxLength(25)]
        public string Categorie { get; set; }

        [MaxLength(25)]
        public string Saison { get; set; }

        public List<MenuItem>? MenusItems { get; set; }

        public Menu(string nomMenu,string categorieMenu,string saisonMenu)
        {
            Nom = nomMenu;
            Categorie = categorieMenu;
            Saison = saisonMenu;
        }

        public Menu()
        {

        }

    }
}
