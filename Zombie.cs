using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Zombie : Monstre
    {
        private CouleurZ teint;
        private int degreDecomposition;

        public Zombie(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte1, int affectation1, CouleurZ teint, int degreDecomp)
            : base(matricule, nom, prenom, sexe, fonction, affectation1, cagnotte1)
        {
            this.teint = teint;
            this.degreDecomposition = degreDecomp;
        }
    }
}
