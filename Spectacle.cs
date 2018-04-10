using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Spectacle : Attraction
    {
        private List<DateTime> horaire;
        private int nombrePlace;
        private string nomSalle;

        public Spectacle(bool besoinS, TimeSpan dureeMaintenance, List<Monstre> eq, int id, bool maint, string natureM, int nbMinMonstre, string nom,
            bool ouvert, string typeBesoin, List<DateTime> horaire, int nbPlace, string nmSalle) : base(besoinS, dureeMaintenance, eq, id, maint, natureM, nbMinMonstre, nom, ouvert, typeBesoin)
        {
            this.horaire = horaire;
            this.nombrePlace = nbPlace;
            this.nomSalle = nmSalle;
        }

        public Spectacle(bool besoinS, int id, int nbMinMonstre, string nom, string typeBesoin, List<DateTime> horaire, int nbPlace, string nmSalle) 
            :base (besoinS, id, nbMinMonstre, nom, typeBesoin)
        {
            this.horaire = horaire;
            this.nombrePlace = nbPlace;
            this.nomSalle = nmSalle;
        }

        public override string ToString()
        {
            return "Spectacle  Nom de la salle : "+this.nomSalle +base.ToString()+ " nombrePlaces : "+this.nombrePlace;
        }
    }
}
