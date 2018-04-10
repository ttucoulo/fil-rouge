using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Attraction
    {
        private bool besoinSpecifique;
        private TimeSpan dureeMaintenance;
        private List<Monstre> equipe;
        private int identifiant;
        private bool maintenance;
        private string natureMaintenance;
        private int nbMinMonstre;
        private string nom;
        private  bool ouvert;
        private string typeDeBesoin;

        public Attraction(bool besoinS, TimeSpan dureeMaintenance, List<Monstre> eq, int id, bool maint, string natureM, int nbMinMonstre, string nom,
            bool ouvert, string typeBesoin)
        {
            this.besoinSpecifique = besoinS;
            this.dureeMaintenance = dureeMaintenance;
            this.equipe = eq;
            this.identifiant = id;
            this.maintenance = maint;
            this.natureMaintenance = natureM;
            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;
            this.ouvert = ouvert;
            this.typeDeBesoin = typeBesoin;
        }

        public Attraction(bool besoinS, int id, int nbMinMonstre, string nom, string typeBesoin)
        {
            this.besoinSpecifique = besoinS;
            this.dureeMaintenance = new TimeSpan(0, 0, 0);
            this.equipe = new List<Monstre>();
            this.identifiant = id;
            this.maintenance = false;
            this.natureMaintenance = "";
            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;
            this.ouvert = true;
            this.typeDeBesoin = typeBesoin;
        }

        public override string ToString()
        {
            return " Nom : " + this.nom + " id : " + this.identifiant;
        }

        public bool BesoinSpecifique
        {
            get { return this.besoinSpecifique; }
        }
        public int Id
        {
            get { return this.identifiant; }
        }
        public int NbMinMonstre
        {
            get { return this.nbMinMonstre; }
        }
        public string Nom
        {
            get { return this.nom; }
        }
        public string TypeBesoin
        {
            get { return this.typeDeBesoin; }
        }
        public List<Monstre> Equipe
        {
            get { return this.equipe; }
            set { this.equipe = value; }
        }
        public bool Maintenance
        {
            get { return this.maintenance; }
            set { this.maintenance = value; }
        }
        public TimeSpan DureeMaintenance
        {
            get { return this.dureeMaintenance; }
            set { this.dureeMaintenance = value; }
        }
        public string NatureMaintenance
        {
            get { return this.natureMaintenance; }
            set { this.natureMaintenance = value; }
        }
        public bool Ouvert
        {
            get { return this.ouvert; }
            set { this.ouvert = value; }
        }
    }
}
