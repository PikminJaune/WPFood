using System;
using System.Linq;
using WPFood.Modeles;
using WPFood.Outils;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ControlzEx.Standard;
using System.Diagnostics;

namespace WPFood.VuesModeles.VM_Administrateur
{
    public class VM_Admin_Stats
    {
        public VM_Admin_Stats()
        {
        }

        #region Requetes
        public int GetNombreClients(DateTime dateDebut, DateTime dateFin)
        {
            List<CommandeClient> lstCommandeClient = OutilsEF.WPFoodContext!.CommandesClients!
                .Include(lstCommandeClient => lstCommandeClient.Client)
                .Where(lstCommandeClient => lstCommandeClient.Date.Day >= dateDebut.Day)
                .Where(lstCommandeClient => lstCommandeClient.Date.Day <= dateFin.Day)
                .OrderBy(lstCommandeClient => lstCommandeClient.Client)
                .ToList();

            //Liste des commandes clients qui sont entre une date et une autre date slectionnée
            List<CommandeClient> listCommandesClients = new List<CommandeClient>();

            foreach (CommandeClient cc in lstCommandeClient)
            {
                if (cc.EstPaye)
                {
                    listCommandesClients.Add(cc);
                }
            }

            return listCommandesClients.DistinctBy(x => x.Client.Id).Count();

        }

        //--------------------------------------------------------------------------------------------

        public List<string> GetNomsItems(DateTime dateDebut, DateTime dateFin)
        {

            List<CommandeClientItem> lstCommandesClientItems = OutilsEF.WPFoodContext!.CommandesClientsItems!
                .Include(lstCommandesClientItems => lstCommandesClientItems.CommandeClient)
                .Include(lstCommandesClientItems => lstCommandesClientItems.item)
                .Where(lstCommandesClientItems => lstCommandesClientItems.CommandeClient.Date.Day >= dateDebut.Day)
                .Where(lstCommandesClientItems => lstCommandesClientItems.CommandeClient.Date.Day <= dateFin.Day)
                .ToList();

            //------------------------------------------------------------------------------------------

            List<string> lstNoms = new List<string>();

            foreach (CommandeClientItem cc in lstCommandesClientItems)
            {
                lstNoms.Add(cc.item.Nom);
            }

            //------------------------------------------------------------------------------------------

            List<string> lstNomsDistincts = new List<string>();

            foreach (string nom in lstNoms.Distinct().ToList())
            {
                lstNomsDistincts.Add(nom);
            }

            return lstNomsDistincts;

        }

        public int GetNbFoisCommande(string nomItem, DateTime dateDebut, DateTime dateFin) {

            List<CommandeClientItem> lstCommandesClientItems = OutilsEF.WPFoodContext!.CommandesClientsItems!
                .Include(lstCommandesClientItems => lstCommandesClientItems.CommandeClient)
                .Include(lstCommandesClientItems => lstCommandesClientItems.item)
                .Where(lstCommandesClientItems => lstCommandesClientItems.CommandeClient.Date.Day >= dateDebut.Day)
                .Where(lstCommandesClientItems => lstCommandesClientItems.CommandeClient.Date.Day <= dateFin.Day)
                .ToList();

            int nbFois = 0;

            foreach (CommandeClientItem cc in lstCommandesClientItems)
            {
                if (cc.item.Nom == nomItem)
                {
                    nbFois += cc.Quantite;
                }
            }

            return nbFois;
        }
        #endregion

    }
}
