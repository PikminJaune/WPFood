using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WPFood.Outils;
using System.ComponentModel;
using WPFood.Modeles;
using System.Windows.Input;
using System.Net.Http.Headers;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using WPFood.Vues.UC_Client;

namespace WPFood.VuesModeles
{
    public class VM_Commentaires : INotifyPropertyChanged
    {
        public ICommand cmdInsererCommentaire { get; set; }
       

        public VM_Commentaires()
        {

            InitServeurs();
            InitCommentaire();
            cmdInsererCommentaire = new Commande(CmdAddCommentaire);
            
            EstRecommande = true; // egale a true a l'initialisation, mais la valeur va changer lors de l'appuie sur les boutons

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }


        #region CMD

        private void CmdAddCommentaire(object sender)
        {
         
            Commentaire newCommentaire = new Commentaire();
            newCommentaire.EstRecommende = EstRecommande;
            newCommentaire.CommentaireClient = ContenuCommentaire;
            newCommentaire.NomClient = NomClient;
            
            newCommentaire.NomServeur = NomServeurSelectionne!;
            newCommentaire.DateCommentaire = DateTime.Now;
            if (EstCommentaireVerifier(newCommentaire))
            {
                try
                {
                    //ajouter le commentaire a droite
                    Commentaires.Add(newCommentaire);

                    //ajouter le commentaire en BD
                    OutilsEF.WPFoodContext?.Commentaires?.Add(newCommentaire);
                    OutilsEF.WPFoodContext?.SaveChanges();

                    //rafrachit la liste des commentaires.
                    InitCommentaire();
                    ClearFormCommentaire();
                    GenererCommentaires(monUC_Commentaire);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        #endregion

        //Fonction permettant d'initialiser les commentaires.
        public void InitCommentaire()
        {
            Commentaires = new ObservableCollection<Commentaire>();

            var requete = from commentaire in OutilsEF.WPFoodContext!.Commentaires select commentaire;
            requete = requete.OrderByDescending(x => x.DateCommentaire);
            foreach (var comment in requete)
            {
                Commentaires.Add(comment);
            }
        }

        //Fonction permettant d'initialiser les serveurs.
        public void InitServeurs()
        {
            NomsServeurs = new ObservableCollection<string>();

            var requete = from serveur in OutilsEF.WPFoodContext!.Employes where serveur.Fonction == "Serveur" select serveur.Prenom;

            foreach (string nom in requete)
                NomsServeurs.Add(nom);
        }

        //Fonction permettant de vider les champs du formulaire de commentaire
        private void ClearFormCommentaire()
        {
            EstRecommande = true;
            ContenuCommentaire = "";
            NomClient = "";
            DateCommentaire = DateTime.Now;
        }

        //Vérification du commentaire entré
        public bool EstCommentaireVerifier(Commentaire commentaire)
        {
            if (commentaire.CommentaireClient == null || commentaire.CommentaireClient.ToLower().Trim().Length == 0 )
            {
                MessageBox.Show("Vous devez entrer un message avant d'envoyer le commentaire", "Erreur: contenu du message vide", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (commentaire.NomServeur == null || commentaire.NomServeur.ToLower().Trim().Length == 0)
            {

                string nomServeur = OutilsEF.WPFoodContext.Employes.Where(x => x.Fonction == "Serveur").Where(x => x.Nom == "Non spécifié").FirstOrDefault().Nom;
                commentaire.NomServeur = nomServeur;
            }

            if (commentaire.NomClient == null ||  commentaire.NomClient.ToLower().Trim().Length == 0 )
            {
                commentaire.NomClient = "Incognito";
            }
            return true;
        }


        public UserControl creationCommentaire(Commentaire commentaire)
        {
            UserControl uc_commentaire = new UC_CommentaireTemplate(
                commentaire.CommentaireClient, 
                commentaire.NomClient, 
                commentaire.EstRecommende, 
                commentaire.NomServeur,
                commentaire.DateCommentaire);

            return uc_commentaire;
        }


        public void GenererCommentaires(UC_ClientCommentaire uc_ClientCommentaire)
        {
            if(uc_ClientCommentaire != null)
                uc_ClientCommentaire.wp_Commentaires.Children.Clear();

            if (Commentaires!.Count > 0)
            {
                List<Commentaire> Lst_Commentaires = Commentaires.OrderByDescending(x => x.DateCommentaire).ToList();
                foreach (Commentaire commentaire in Lst_Commentaires)
                {
                    uc_ClientCommentaire.wp_Commentaires.Children.Add(creationCommentaire(commentaire));
                }
            }
            monUC_Commentaire = uc_ClientCommentaire;
        }


        #region propriétés
        private ObservableCollection<Commentaire>? _commentaires;
        public ObservableCollection<Commentaire>? Commentaires
        {
            get
            {
                return _commentaires;
            }
            set
            {
                _commentaires = value;
                if (_commentaires == null)
                    return;
                OnPropertyChanged("Commentaires");
            }
        }

        private ObservableCollection<string>? _nomsServeurs;
        public ObservableCollection<string>? NomsServeurs
        {
            get
            {
                return _nomsServeurs;
            }
            set
            {
                _nomsServeurs = value;
                if (_nomsServeurs == null)
                    return;
                OnPropertyChanged("NomsServeurs");
            }
        }

        private string? _nomServeurSelectionne;
        public string? NomServeurSelectionne
        {
            get
            {
                return _nomServeurSelectionne;
            }
            set
            {
                _nomServeurSelectionne = value;
                if (_nomServeurSelectionne == null)
                    return;
                OnPropertyChanged("NomServeurSelectionne");
            }
        }

        private string _nomClient;
        public string NomClient
        {
            get
            {
                return _nomClient;
            }
            set
            {
                _nomClient = value;
                if (_nomClient == null)
                    return;
                OnPropertyChanged("NomClient");
            }
        }



        private string _contenuCommentaire;
        public string ContenuCommentaire
        {
            get
            {
                return _contenuCommentaire;
            }
            set
            {
                _contenuCommentaire = value;
                if (_contenuCommentaire == null)
                    return;
                OnPropertyChanged("ContenuCommentaire");
            }
        }

        

        public DateTime _dateCommentaire = DateTime.Now;
        public DateTime DateCommentaire
        {
            get
            {
                return _dateCommentaire;
            }
            set
            {
                _dateCommentaire = value;
                if (_dateCommentaire == DateTime.Now)
                    return;
                OnPropertyChanged("DateCommentaire");
            }
        }


        private bool _estRecommande;
        public bool EstRecommande 
        {
            get
            {
                return _estRecommande;
            }
            set
            {
                _estRecommande = value;
                OnPropertyChanged("EstRecommande");
            }
        }

        
       


        public UC_ClientCommentaire monUC_Commentaire { get; set; }




        #endregion
    }
}
