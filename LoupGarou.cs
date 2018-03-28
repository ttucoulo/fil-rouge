using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class LoupGarou : Monstre
    {
        private double indiceCruaute;

        public LoupGarou(int matricule, string nom, string prenom, TypeSexe sexe, string fonction,int cagnotte1, int affectation1,  double indicecruaute) 
            : base(matricule, nom, prenom, sexe, fonction, affectation1, cagnotte1)
        {
            this.indiceCruaute = indicecruaute;
        }
    }
}
