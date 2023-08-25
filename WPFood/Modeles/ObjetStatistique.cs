using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    public class ObjetStatistique
    {
        public ObjetStatistique(string nom, int nbFoisCommande)
        {
            Nom = nom;
            NbFoisCommande = nbFoisCommande;
        }

        public string Nom { get; set; }

        public int NbFoisCommande { get; set; }
    }
}
