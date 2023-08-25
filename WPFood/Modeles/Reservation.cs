using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    [Table("Reservation")]
    public class Reservation
    {
        public int Id { get; set; }

        [MaxLength(75)]
        public string NomClient { get; set; }

        [MaxLength(10)]
        public string NumeroTelephone { get; set; }
        public int NbClientAttendu { get; set; }

        public Table Table { get; set; }

        //[Column(TypeName = "DateTime2")]
        [Column(TypeName = "datetime")]
        public DateTime DateReservation { get; set; }

        public Reservation()
        {

        }

        public Reservation(string nomClient, string numeroTelephone, int nbClientAttendu, Table table, DateTime dateReservation)
        {
            NomClient = nomClient;
            NumeroTelephone = numeroTelephone;
            NbClientAttendu = nbClientAttendu;
            Table = table;
            DateReservation = dateReservation;
        }
    }
}
