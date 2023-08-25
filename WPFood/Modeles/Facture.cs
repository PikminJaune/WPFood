using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    public class Facture
    {
        public Facture()
        {

        }
        public Facture(List<CommandeClient> commandesClients, DateTime datePaiement, double sousTotal, double montantTPS, double montantTVQ, double total)
        {
            CommandesClients = commandesClients;

            DatePaiement = datePaiement;
            SousTotal = sousTotal;
            MontantTPS = montantTPS;
            MontantTVQ = montantTVQ;
            Total = total;
        }

        public int Id { get; set; }
        public List<CommandeClient> CommandesClients { get; set; }

        public DateTime DatePaiement { get; set; }

        public double SousTotal { get; set; }

        public double MontantTPS { get; set; }
        public double MontantTVQ { get; set; }

        public double Total { get; set; }
    }
}
