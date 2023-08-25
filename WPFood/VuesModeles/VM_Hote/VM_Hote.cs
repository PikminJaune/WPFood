using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using WPFood.Modeles;
using WPFood.Outils;

namespace WPFood.VuesModeles.VM_Hote
{
    public class VM_Hote : INotifyPropertyChanged
    {
        public VM_Hote()
        {
            InitHoteTables();
            InitHoteReservations();
        }

        private void InitHoteTables()
        {
            LstTables = new ObservableCollection<Table>();

            if (HoteGlobale.Option == "Libre")
            {
                LstTables = GetTablesFiltre(HoteGlobale.Option);
            }
            else if (HoteGlobale.Option == "A Nettoyer")
            {
                LstTables = GetTablesFiltre(HoteGlobale.Option);
            }
            else
            {
                LstTables = GetAllTables();
            }
        }

        private void InitHoteReservations()
        {
            LstReservations = new ObservableCollection<Reservation>();
            LstReservations = GetReservations();
        }

        //---------------------------------------------------------------------------

        #region Props
        private ObservableCollection<Table>? _lstTables;

        public ObservableCollection<Table>? LstTables
        {
            get { return _lstTables; }
            set
            {
                _lstTables = value;
                if (_lstTables == null)
                    return;
                OnPropertyChanged("LstTables");
            }
        }

        //----------------------------

        private ObservableCollection<Reservation>? _lstReservations;

        public ObservableCollection<Reservation>? LstReservations
        {
            get { return _lstReservations; }
            set
            {
                _lstReservations = value;
                if (_lstReservations == null)
                    return;
                OnPropertyChanged("LstReservations");
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

        #region Requêtes BD
        //Table
        public void ModifierTable(Table table, string etat, int nbClients)
        {
            Table tableModifie = OutilsEF.WPFoodContext!.Tables!.Find(table.Id)!;
            tableModifie.Etat = etat;
            tableModifie.NbClients = nbClients;

            OutilsEF.WPFoodContext!.SaveChanges();
            InitHoteTables();
        }

        public ObservableCollection<Table> GetAllTables(int? nbPlaces = null)
        {
            ObservableCollection<Table> tables = new ObservableCollection<Table>();

            if (nbPlaces == null)
            {
                var req = from table in OutilsEF.WPFoodContext!.Tables select table;

                foreach (var tb in req)
                {
                    tables.Add(tb);
                }

                return tables;
            }
            else
            {
                var req = from table in OutilsEF.WPFoodContext!.Tables
                          where table.NbPlacesMax >= nbPlaces
                          select table;

                foreach (var tb in req)
                {
                    tables.Add(tb);
                }

                return tables;
            }

        }

        public ObservableCollection<Table> GetTablesFiltre(string filtre, int? nbPlaces = null)
        {
            ObservableCollection<Table> tablesLibres = new ObservableCollection<Table>();
            ObservableCollection<Table> toutesLesTables = GetAllTables();

            if (nbPlaces == null)
            {

                var tables = from table in toutesLesTables
                             where table.Etat == filtre
                             select table;

                foreach (var tb in tables)
                {
                    tablesLibres.Add(tb);
                }

                return tablesLibres;
            }
            else
            {
                var tables = from table in toutesLesTables
                             where table.Etat == filtre
                             where table.NbPlacesMax >= nbPlaces
                             select table;

                foreach (var tb in tables)
                {
                    tablesLibres.Add(tb);
                }

                return tablesLibres;
            }

        }

        public Table GetTable(int id)
        {
            Table table = OutilsEF.WPFoodContext!.Tables!.Find(id)!;
            return table;
        }

        public ObservableCollection<Table> GetTablesNbPlaces(int nbPlaces)
        {
            ObservableCollection<Table> tablesLibres = new ObservableCollection<Table>();
            ObservableCollection<Table> toutesLesTables = GetAllTables();

            string filtre = HoteGlobale.Option;

            if (filtre == null)
            {
                var tables = from table in toutesLesTables
                             where table.NbPlacesMax >= nbPlaces
                             select table;

                foreach (var tb in tables)
                {
                    tablesLibres.Add(tb);
                }

                return tablesLibres;
            }
            else
            {
                var tables = from table in toutesLesTables
                             where table.NbPlacesMax >= nbPlaces
                             where table.Etat == filtre
                             select table;

                foreach (var tb in tables)
                {
                    tablesLibres.Add(tb);
                }

                return tablesLibres;
            }


        }

        /// <summary>
        /// Retourne des tables qui sont valides selon la date voulue, l'heure voulue et le nombre de places voulues
        /// </summary>
        /// <param name="nbPlaces"></param>
        /// <param name="dateVoulue"></param>
        /// <param name="heureVoulue"></param>
        /// <returns></returns>
        public ObservableCollection<Table> GetTablesReservations(int nbPlaces, DateTime dateVoulue, string heureVoulue, Reservation reservationActuelle = null)
        {
            try
            {
                string annee = dateVoulue.Year.ToString();
                string mois = dateVoulue.Month.ToString();
                string jour = dateVoulue.Day.ToString();
                string dateConstruction = annee + "-" + mois + "-" + jour + " " + heureVoulue;

                DateTime dateHeureVoulue = DateTime.Parse(dateConstruction);

                //-----------------------------------------------------------------------------

                //Les tables qui sont valides pour le nombre de client
                ObservableCollection<Table> toutesLesTables = GetAllTables();

                var tables = from table in toutesLesTables
                             where table.NbPlacesMax >= nbPlaces
                             select table;

                ObservableCollection<Table> tablesReservations = new ObservableCollection<Table>();

                foreach (var item in tables)
                {
                    tablesReservations.Add(item);
                }

                //-----------------------------------------------------------------------------
                ObservableCollection<Reservation> reservations = GetReservations();
                List<Table> tablesARetirer = new List<Table>();

                //Pour chaque table
                foreach (Table tbRes in tablesReservations)
                {
                    //On regarde chaque réservation
                    foreach (Reservation res in reservations)
                    {
                        //Si cette table a une réservation à la même table
                        if (tbRes == res.Table)
                        {
                            //Regarder si il y a conflit d'horaire à la même date
                            if (res.DateReservation.Date == dateHeureVoulue.Date)
                            {
                                //30 minutes avant
                                DateTime dtpre30 = res.DateReservation.AddMinutes(-30);
                                //60 minutes avant
                                DateTime dtpre60 = res.DateReservation.AddMinutes(-60);

                                //30 minutes apres
                                DateTime dtpost30 = res.DateReservation.AddMinutes(30);
                                //60 minutes apres
                                DateTime dtpost60 = res.DateReservation.AddMinutes(60);

                                //Modifier une réservation
                                if (reservationActuelle != null)
                                {
                                    if ((dateHeureVoulue == res.DateReservation ||
                                    dateHeureVoulue == dtpre30 ||
                                    dateHeureVoulue == dtpre60 ||
                                    dateHeureVoulue == dtpost30 ||
                                    dateHeureVoulue == dtpost60) &&
                                    res.Id != reservationActuelle.Id
                                    )
                                    {
                                        tablesARetirer.Add(tbRes);
                                        tablesARetirer = tablesARetirer.Distinct().ToList();
                                    }
                                }
                                //Ajouter une réservation
                                else if (dateHeureVoulue == res.DateReservation ||
                                    dateHeureVoulue == dtpre30 ||
                                    dateHeureVoulue == dtpre60 ||
                                    dateHeureVoulue == dtpost30 ||
                                    dateHeureVoulue == dtpost60)
                                {
                                    tablesARetirer.Add(tbRes);
                                    tablesARetirer = tablesARetirer.Distinct().ToList();
                                }

                            }

                        }
                    }
                }

                //-----------------------------------------------------------------------------

                //On fait une comparaison des 2 listes et on retourne uniquement les tables uniques, qui sont valides
                ObservableCollection<Table> tablesValides = new ObservableCollection<Table>();

                var differences = tablesReservations.Except(tablesARetirer);

                foreach (var difference in differences)
                {
                    tablesValides.Add(difference);
                }

                //-----------------------------------------------------------------------------

                return tablesValides;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return new ObservableCollection<Table>();
            }

        }

        // -------------------------------------------------
        //Client
        public void AjoutClients(List<Client> clients)
        {
            foreach (var client in clients)
            {
                OutilsEF.WPFoodContext.Clients.Add(client);
            }

            OutilsEF.WPFoodContext!.SaveChanges();
        }

        public void RetirerClients(int table)
        {
            var clientsTable = from client in OutilsEF.WPFoodContext.Clients where client.IdTable == table select client;

            foreach (var client in clientsTable)
            {
                OutilsEF.WPFoodContext.Clients.Remove(client);
            }

            OutilsEF.WPFoodContext!.SaveChanges();
        }

        public void ClientsEstPasse(Table table)
        {

            var clients = from client in OutilsEF.WPFoodContext.Clients where client.IdTable == table.Id select client;

            foreach (var c in clients)
            {
                c.EstPasse = true;
            }

            OutilsEF.WPFoodContext!.SaveChanges();
        }

        // -------------------------------------------------
        //Réservations
        public void AjouterReservation(Reservation reservation)
        {
            OutilsEF.WPFoodContext!.Reservations!.Add(reservation);
            OutilsEF.WPFoodContext!.SaveChanges();
            InitHoteReservations();
        }

        public void ModifierReservation(Reservation nouvelleReservation, Reservation reservationActuelle)
        {
            Reservation reservationModifie = OutilsEF.WPFoodContext!.Reservations!.Find(reservationActuelle.Id)!;
            reservationModifie.NomClient = nouvelleReservation.NomClient;
            reservationModifie.NumeroTelephone = nouvelleReservation.NumeroTelephone;
            reservationModifie.NbClientAttendu = nouvelleReservation.NbClientAttendu;
            reservationModifie.Table = nouvelleReservation.Table;
            reservationModifie.DateReservation = nouvelleReservation.DateReservation;

            OutilsEF.WPFoodContext!.SaveChanges();
            InitHoteReservations();
        }

        public void RetirerReservation(Reservation reservation)
        {
            var reservations = from rese in OutilsEF.WPFoodContext.Reservations where rese.Id == reservation.Id select rese;

            foreach (var laReservation in reservations)
            {
                OutilsEF.WPFoodContext.Reservations!.Remove(laReservation);
            }

            OutilsEF.WPFoodContext!.SaveChanges();
            InitHoteReservations();
        }

        public ObservableCollection<Reservation> GetReservations()
        {
            var req = from reservation in OutilsEF.WPFoodContext!.Reservations select reservation;

            ObservableCollection<Reservation> reservations = new ObservableCollection<Reservation>();

            foreach (var res in req)
            {
                reservations.Add(res);
            }

            return reservations;
        }
        #endregion

    }
}
