using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFood.Outils
{
    public class OutilsEF
    {
        public static WPFoodContext? WPFoodContext;

        public OutilsEF()
        {
            try
            {
                WPFoodContext = new WPFoodContext();
            }catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'instanciation du context EF " + ex.Message);
            }
        }
    }
}
