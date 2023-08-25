using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFood.Modeles;

namespace WPFood.Outils
{
    internal class ServeurGlobale
    {
        public static int IdTableSelectionnee;
        public static int IdClientSelectionne;

        public static List<int> IdsclientsSelectiones = new List<int>();
    }

    public struct Taxes
    {
        public const double TVQ = 0.09975;
        public const double TPS = 0.05;
    }
}
