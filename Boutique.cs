using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Boutique : Attraction
    {
        private TypeBoutique type;

        public Boutique(bool besoinS, TimeSpan dureeMaintenance, List<Monstre> eq, int id, bool maint, string natureM, int nbMinMonstre, string nom,
            bool ouvert, string typeBesoin, TypeBoutique type) :base(besoinS,dureeMaintenance,eq,id,maint,natureM,nbMinMonstre,nom,ouvert,typeBesoin) 
        {
            this.type = type;
        }

        public Boutique(bool besoinS, int id, int nbMinMonstre, string nom, string typeBesoin, TypeBoutique typeBout) 
            :base (besoinS, id, nbMinMonstre, nom, typeBesoin)
        {
            this.type = typeBout;
        }

        public override string ToString()
        {
            return "Boutique : "+base.ToString() + " Type Boutique : "+this.type;
        }

        public TypeBoutique TypeBoutique
        {
            get { return this.type; }
        }
    }
}
