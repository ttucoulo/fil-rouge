using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Vampire : Monstre
    {
        private float indiceLuminosite;

        public Vampire(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int affectation1,int cagnotte1,  float indiceLumi)
            :base(matricule, nom, prenom, sexe, fonction, affectation1, cagnotte1)
        {
            this.indiceLuminosite = indiceLumi;
        }
    }
}
