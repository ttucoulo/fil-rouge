using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Fantome : Monstre
    {
        public Fantome(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte1 ,int affectation1) 
            : base(matricule, nom, prenom, sexe, fonction,affectation1, cagnotte1)
        {

        }
    }
}
