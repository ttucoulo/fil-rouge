using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Darkride :Attraction
    {
        private TimeSpan duree;
        private bool vehicule;

        public Darkride(bool besoinS, TimeSpan dureeMaintenance, List<Monstre> eq, int id, bool maint, string natureM, int nbMinMonstre, string nom,
            bool ouvert, string typeBesoin, TimeSpan duree, bool vehicule) : base(besoinS, dureeMaintenance, eq, id, maint, natureM, nbMinMonstre, nom, ouvert, typeBesoin)
        {
            this.duree = duree;
            this.vehicule = vehicule;
        }

        public Darkride(bool besoinS, int id, int nbMinMonstre, string nom, string typeBesoin,TimeSpan duree, bool vehicule) 
            :base (besoinS, id, nbMinMonstre, nom, typeBesoin)
        {
            this.duree = duree;
            this.vehicule = vehicule;
        }
        public override string ToString()
        {
            return "Darkride  " +base.ToString();
        }
    }
}
