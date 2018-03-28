using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class RollerCoaster : Attraction
    {
        private int ageMini;
        private TypeCategorie categorie;
        private float tailleMinimum;

        public RollerCoaster(bool besoinS, TimeSpan dureeMaintenance, List<Monstre> eq, int id, bool maint, string natureM, int nbMinMonstre, string nom,
            bool ouvert, string typeBesoin,int ageMinimum, TypeCategorie categ, float tailleMini) 
            : base(besoinS, dureeMaintenance, eq, id, maint, natureM, nbMinMonstre, nom, ouvert, typeBesoin)
        {
            this.ageMini = ageMinimum;
            this.categorie = categ;
            this.tailleMinimum = tailleMini;
        }

        public RollerCoaster(bool besoinS, int id, int nbMinMonstre, string nom, string typeBesoin,int ageMini,TypeCategorie categ, float tailleMini) 
            :base (besoinS, id, nbMinMonstre, nom, typeBesoin)
        {
            this.ageMini = ageMini;
            this.categorie = categ;
            this.tailleMinimum = tailleMini;
        }
    }
}
