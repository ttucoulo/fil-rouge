using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Monstre : Personnel
    {
        //private Attraction affectation;
        private int affectation;
        private int cagnotte;

        public Monstre(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int affectation1, int cagnotte1)
            : base(matricule, nom,prenom,sexe,fonction)
        {
            this.affectation = affectation1;
            this.cagnotte = cagnotte1;
        }

        public virtual void ModifierCagnotte(Monstre monstre, int cagnotte)
        {

        }

        public int Affectation
        {
            get { return this.affectation; }
            set { this.affectation = value; }
        }
        public int Cagnotte
        {
            get { return this.cagnotte; }
            set { this.cagnotte = value; }
        }
    }
}
