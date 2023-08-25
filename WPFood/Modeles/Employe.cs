using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    public class Employe
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nom { get; set; }

        [MaxLength(20)]
        public string Prenom { get; set; }

        [MaxLength(15)]
        public string Fonction { get; set; }

        [MaxLength(15)]
        public string Identifiant { get; set; }

        [MaxLength(15)]
        public string MotDePasse { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateNaissance { get; set; }

        [MaxLength(10)]
        public string Genre { get; set; }

        public List<Service> Services { get; set; }

        //Constructeur
        public Employe(int id, string nom, string prenom, string fonction, string identifiant, string motdepasse, DateTime dateNaissance, string genre)
        {
            Id = id;
            Nom = nom; 
            Prenom = prenom;
            Fonction = fonction;
            Identifiant = identifiant;
            MotDePasse = motdepasse;
            DateNaissance = dateNaissance;
            Genre = genre;
        }

        public Employe(string nom, string prenom, string fonction, string identifiant, string motdepasse, DateTime dateNaissance, string genre)
        {
            Nom = nom;
            Prenom = prenom;
            Fonction = fonction;
            Identifiant = identifiant;
            MotDePasse = motdepasse;
            DateNaissance = dateNaissance;
            Genre = genre;
        }

        public Employe()
        {

        }
    }
}
