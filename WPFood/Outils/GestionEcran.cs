using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFood.VuesModeles.VM_Connexion;

namespace WPFood.Outils
{
    internal class GestionEcran
    {
        public GestionEcran()
        {

        }
        /// <summary>
        /// Pour avoir accés aux écrans facilements
        /// </summary>
        /// <param name="userControl"></param>
        /// <param name="MainGrid"></param>
        /// <param name="Ecran"></param>
        public static void ChangerEcran(UserControl userControl)
        {
            //Accès au MainGrid du MainWindow
            MainWindow mainWindow = Window.GetWindow(App.Current.MainWindow) as MainWindow;
            Grid mainGrid = mainWindow.MainGrid;
            UserControl ecran = mainWindow.Ecran;
     
            mainGrid.Children.Clear();
            ecran = userControl;
            Grid.SetRow(ecran, 0);
            Grid.SetColumn(ecran, 0);
            mainGrid.Children.Add(ecran);
        }  
    }
}
