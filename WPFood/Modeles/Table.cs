using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFood.Outils;

namespace WPFood.Modeles
{
    public class Table
    {
        public int Id { get; set; }

        public List<Service> Services { get; set; }

        public int NbClients { get; set; }

        public string Etat { get; set; }

        public int NbPlacesMax { get; set; }

        public Table(int id, List<Service> services, int nbClients, string etat, int nbPlacesMax)
        {
            Id = id;
            Services = services;
            NbClients = nbClients;
            Etat = etat;
            NbPlacesMax = nbPlacesMax;
        }

        /// <summary>
        /// Lors de sa construction par un admin. La table n'a pas encore de clients ou de services et est toujours libre. On peut choisir le id dans ce cas.
        /// </summary>
        /// <param name="id">Le id de la table</param>
        /// <param name="nbPlacesMax">Le nombre de place maximum</param>
        public Table(int id, int nbPlacesMax)
        {
            Id = id;
            Services = new List<Service>();
            NbClients = 0;
            Etat = "Libre";
            NbPlacesMax = nbPlacesMax;
        }

        /// <summary>
        /// Lors de sa construction par un admin. La table n'a pas encore de clients ou de services et est toujours libre.
        /// </summary>
        /// <param name="id">Le id de la table</param>
        /// <param name="nbPlacesMax">Le nombre de place maximum</param>
        public Table(int nbPlacesMax)
        {
            Services = new List<Service>();
            NbClients = 0;
            Etat = "Libre";
            NbPlacesMax = nbPlacesMax;
        }

        public Table()
        {

        }

        public override string ToString()
        {
            return "Table #" + Id.ToString();
        }

    }
}
