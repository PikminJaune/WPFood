using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFood.Modeles;

namespace WPFood.Outils
{
    public class WPFoodContext : DbContext
    {
        public DbSet<Client>? Clients { get; set; }
        public DbSet<CommandeClient>? CommandesClients{ get; set; }
        public DbSet<CommandeClientItem>? CommandesClientsItems { get; set; }
        public DbSet<CommandeFournisseur>? CommandesFournisseurs { get; set; }
        public DbSet<CommandeFournisseurItems>? CommandesFournisseursItems { get; set; }
        public DbSet<Commentaire>? Commentaires { get; set; }
        public DbSet<Employe>? Employes { get; set; }
        public DbSet<Facture>? Factures { get; set; }
        //public DbSet<Ingredient>? Ingredients { get; set; }
        //public DbSet<IngredientMet>? IngredientMets { get; set; }
        public DbSet<Menu>? Menus { get; set; }
        public DbSet<MenuItem>? MenusItems { get; set; }
        public DbSet<Item>? Items { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Table>? Tables { get; set; }

        private const string connexionString = "server=techinfo-cstj.ca;port=3306;user=wpfood;password=KccY99a79k;database=wpfood_v1;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            ServerVersion sv = MariaDbServerVersion.AutoDetect(connexionString);
            optionBuilder.UseMySql(connexionString, sv);
        }
    }
}
