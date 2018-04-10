using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Demon : Monstre,IComparable<Demon>
    {
        private int force;

        public Demon(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int affectation1, int cagnotte1,  int force1) 
            : base(matricule,nom,prenom,sexe, fonction,affectation1,cagnotte1)
        {
            this.force = force1;
        }

        public override void ModifierCagnotte(Monstre monstre, int cagnotte)
        {

        }

        public override string ToString()
        {
            return (base.ToString() +
                "force : "+this.force);
        }
        public int CompareTo(Demon demon)
        {
            return this.force.CompareTo(demon.force);
        }

        public int Force
        {
            get { return this.force; }
        }
    }
}
