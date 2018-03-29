using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Demon : Monstre
    {
        private int force;

        public Demon(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int affectation1, int cagnotte1,  int force1) 
            : base(matricule,nom,prenom,sexe, fonction,affectation1,cagnotte1)
        {
            this.force = force1;
        }
    }
}
