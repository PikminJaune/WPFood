using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    public class CommandeClient
    {
        public CommandeClient(Client client)
        {
            Client = client;
        }

        public CommandeClient()
        {

        }

        public int Id { get; set; }

        public Client Client { get; set; }
        public List<CommandeClientItem> CommandeClientItems { get; set; }

        public DateTime Date { get; set; }
        
        public bool EstTermine { get; set; }

        public bool EstPaye { get; set; }

        public override string ToString()
        {
            if (!this.EstPaye && !this.EstTermine)
            {
                return "Commande # " + Id.ToString() + " (En cours)";
            }

            if (this.EstTermine && !this.EstPaye)
            {
                return "Commande # " + Id.ToString() + " (Complétée)";
            }

            return "Commande # " + Id.ToString() + " (Payée)";
        }
    }
}
