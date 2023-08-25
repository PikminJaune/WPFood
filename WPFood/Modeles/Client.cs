using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    public class Client
    {
        public int Id { get; set; }

        public List<CommandeClient> CommandesClients { get; set; } //foreign key 

        public int IdTable { get; set;}

        public int NumTable { get; set; }

        public bool EstPasse { get; set; }

        //Quand on crée un client, le client à besoin de sa table. Par defaut, le client n'a pas encore passée une commande, alors elle est a false.
        public Client(int idTable)
        {
            IdTable = idTable;
            EstPasse = false;
        }
        
        public override string ToString()
        {
            return "Client #" + NumTable.ToString();
        }
    }
}
