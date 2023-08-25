using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    public class Service
    {
        public int Id { get; set; }
        public Employe Employe { get; set; }
        public Table Table { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateDebut { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateFin { get; set; }


        public Service(int id, Employe employe, Table table, DateTime dateDebut, DateTime dateFin)
        {
            Id = id;
            Employe = employe;
            Table = table;
            DateDebut = dateDebut;
            DateFin = dateFin;
        }

        public Service()
        {

        }
    }


}
