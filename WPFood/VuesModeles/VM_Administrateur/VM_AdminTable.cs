using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFood.Modeles;
using WPFood.Outils;
using static WPFood.Outils.Evenements;

namespace WPFood.VuesModeles.VM_Administrateur
{
    public class VM_AdminTable : INotifyPropertyChanged
    {
        public VM_AdminTable()
        {
            InitGestionTable();          
        }

        private void InitGestionTable()
        {
            LstTables = new ObservableCollection<Table>();

            var tables = from table in OutilsEF.WPFoodContext!.Tables select table;

            foreach (Table table in tables)
            {
                LstTables!.Add(table);
            }
        }

        //---------------------------------------------------------------------------

        #region Props

        private ObservableCollection<Table>? _lstTables;

        public ObservableCollection<Table>? LstTables
        {
            get
            {
                return _lstTables;
            }
            set
            {
                _lstTables = value;
                if (_lstTables == null)
                    return;
                OnPropertyChanged("LstTables");
            }
        }

        #endregion

        //---------------------------------------------------------------------------

        #region PropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }

        #endregion

        //---------------------------------------------------------------------------

        #region Requetes

        public void AjouterTable(Table table)
        {
            OutilsEF.WPFoodContext!.Tables!.Add(table);
            OutilsEF.WPFoodContext!.SaveChanges();
            InitGestionTable();
        }

        /// <summary>
        /// Un admin ne peut que modifier le nombres de places
        /// </summary>
        /// <param name="table">La table à modifier</param>
        public void ModifierTable(Table table)
        {
            Table tableModifie = OutilsEF.WPFoodContext!.Tables!.Find(table.Id)!;
            tableModifie.NbPlacesMax = table.NbPlacesMax;

            OutilsEF.WPFoodContext!.SaveChanges();
            InitGestionTable();
        }

        public void SupprimerTable(Table table)
        {
            OutilsEF.WPFoodContext!.Tables!.Remove(table);
            OutilsEF.WPFoodContext!.SaveChanges();
            InitGestionTable();
        }

        #endregion

    }
}
