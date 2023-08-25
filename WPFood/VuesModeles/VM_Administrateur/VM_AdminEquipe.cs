using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFood.Modeles;
using WPFood.Outils;
using static WPFood.Outils.Evenements;

namespace WPFood.VuesModeles.VM_Administrateur
{
    public class VM_AdminEquipe : INotifyPropertyChanged
    {

        public VM_AdminEquipe()
        {
            InitGestionEquipes();
        }

        private void InitGestionEquipes()
        {
            LstEmployes = new ObservableCollection<Employe>();

            var employes = from employe in OutilsEF.WPFoodContext!.Employes select employe;

            foreach (Employe employe in employes)
            {
                LstEmployes!.Add(employe);
            }

            LstFonctions = new ObservableCollection<string>
            {
                "Hote",
                "Serveur",
                "Cuisinier",
                "Admin",
                "Client",
            };

            LstHeures = new ObservableCollection<string> {
                "06:00",
                "06:30",
                "07:00",
                "07:30",
                "08:00",
                "08:30",
                "09:00",
                "09:30",
                "10:00",
                "10:30",
                "11:00",
                "11:30",
                "12:00",
                "12:30",
                "13:00",
                "13:30",
                "14:00",
                "14:30",
                "15:00",
                "15:30",
                "16:00",
                "16:30",
                "17:00",
                "17:30",
                "18:00",
                "18:30",
                "19:00",
                "19:30",
                "20:00",
                "20:30"
            };
        }

        //---------------------------------------------------------------------------

        #region Props

        private ObservableCollection<Employe>? _lstEmployes;

        public ObservableCollection<Employe>? LstEmployes
        {
            get
            {
                return _lstEmployes;
            }
            set
            {
                _lstEmployes = value;
                if (_lstEmployes == null)
                    return;
                OnPropertyChanged("LstEmployes");
            }
        }

        //-------------------

        private ObservableCollection<string>? _lstFonctions;

        public ObservableCollection<string>? LstFonctions
        {
            get
            {
                return _lstFonctions;
            }
            set
            {
                _lstFonctions = value;
                if (_lstFonctions == null)
                    return;
                OnPropertyChanged("LstFonctions");
            }
        }

        //-------------------

        private ObservableCollection<string>? _lstHeures;

        public ObservableCollection<string>? LstHeures
        {
            get
            {
                return _lstHeures;
            }
            set
            {
                _lstHeures = value;
                if (_lstHeures == null)
                    return;
                OnPropertyChanged("LstHeures");
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

        public void SupprimerEmploye(Employe employe)
        {
            OutilsEF.WPFoodContext!.Employes!.Remove(employe);
            OutilsEF.WPFoodContext!.SaveChanges();
            InitGestionEquipes();
        }

        public void AjouterEmploye(Employe employe)
        {
            OutilsEF.WPFoodContext!.Employes!.Add(employe);
            OutilsEF.WPFoodContext!.SaveChanges();
            InitGestionEquipes();
        }

        public void ModifierEmploye(Employe employe)
        {
            Employe employeModifie = OutilsEF.WPFoodContext!.Employes!.Find(employe.Id)!;
            employeModifie.Nom = employe.Nom;
            employeModifie.Prenom = employe.Prenom;
            employeModifie.Fonction = employe.Fonction;
            employeModifie.Identifiant = employe.Identifiant;
            employeModifie.MotDePasse = employe.MotDePasse;
            employeModifie.DateNaissance = employe.DateNaissance;
            employeModifie.Genre = employe.Genre;

            OutilsEF.WPFoodContext!.SaveChanges();
            InitGestionEquipes();
        }

        #endregion


    }
}
