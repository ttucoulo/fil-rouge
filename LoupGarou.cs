using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class LoupGarou : Monstre,IComparable<LoupGarou>
    {
        private double indiceCruaute;

        public LoupGarou(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int affectation1,int cagnotte1,double indicecruaute) 
            : base(matricule, nom, prenom, sexe, fonction, affectation1, cagnotte1)
        {
            this.indiceCruaute = indicecruaute;
        }
        public override void ModifierCagnotte(Monstre monstre, int cagnotte)
        {

        }
        public override string ToString()
        {
            return (base.ToString() +
                "indice cruauté : " + this.indiceCruaute);
        }
        public int CompareTo(LoupGarou lg)
        {
            return this.indiceCruaute.CompareTo(lg.indiceCruaute);
        }

        public double IndiceCruaute
        {
            get { return this.indiceCruaute; }
            set { this.indiceCruaute = value; }
        }
    }
}
