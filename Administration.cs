using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilRouge
{
    class Administration
    {
        private List<Attraction> attractions;
        private List<Personnel> toutLePersonnel;

        public Administration()
        {
            this.toutLePersonnel = new List<Personnel>();
            this.attractions = new List<Attraction>();
        }

        #region FONCTION_LOGICIEL

        public void AjoutMembresFromCSV(string chemin)
        {
            StreamReader fichLect = new StreamReader(chemin);
            string line = "";
            string[] tab;
            while (line != null)
            {
                line = fichLect.ReadLine();
                if (line != null)
                {
                    tab = line.Split(';');
                    switch (tab[0].ToLower())
                    {
                        case "sorcier":
                            this.AddSorcier(tab);
                            break;
                        case "monstre":
                            this.AddMonstre(tab);
                            break;
                        case "demon":
                            this.AddDemon(tab);
                            break;
                        case "fantome":
                            this.AddFantome(tab);
                            break;
                        case "loupgarou":
                            this.AddLoupGarou(tab);
                            break;
                        case "vampire":
                            this.AddVampire(tab);
                            break;
                        case "zombie":
                            this.AddZombie(tab);
                            break;
                        case "boutique":
                            this.AddBoutique(tab);
                            break;
                        case "darkride":
                            this.AddDarkRide(tab);
                            break;
                        case "rollercoaster":
                            this.AddRollerCoaster(tab);
                            break;
                        case "spectacle":
                            this.AddSpectacle(tab);
                            break;
                    }
                }
            }
            fichLect.Close();
        }
        public void AjouterMembres()
        {
            int numero;
            do
            {
                Console.Clear();
                Console.WriteLine("Si vous etes ici, c'est que vous voulez ajouter soit un membre du Personnel, " +
                   "soit une attraction. \nMembre du Personnel, tappez 1.\nAttraction, tappez 2.");
                numero = int.Parse(Console.ReadLine());
                switch (numero)
                {
                    case 1:
                        this.Ajouter_MembreManuellement();
                        break;
                    case 2:

                        Console.WriteLine("Votre Attraction a été ajoutée au logiciel.");
                        break;
                    default:
                        break;
                }
            } while (numero!=1 && numero !=2);
        }

        #endregion

        #region ADD_MONSTRE FROM CSV

        public void AddSorcier(string [] tab)
        {
            this.toutLePersonnel.Add(new Sorcier(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]),Fonction_Personnel(tab[5]), CastToGrade(tab[6]), ConvertTabToListe(tab[7].Split('-'))));
        }
        public void AddMonstre( string [] tab)
        {
            this.toutLePersonnel.Add(new Monstre(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[7]), CastToInt(tab[6])));
            for (int i = 0; i < this.attractions.Count(); i++)
            {
                if (this.attractions[i].Id == CastToInt(tab[7]))
                {
                    this.attractions[i].Equipe.Add((Monstre)this.toutLePersonnel[this.toutLePersonnel.Count() - 1]);
                }
            }
        }
        public void AddDemon( string [] tab)
        {
            this.toutLePersonnel.Add(new Demon(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[6]), CastToInt(tab[7]), CastToInt(tab[8])));
            for (int i = 0; i < this.attractions.Count(); i++)
            {
                if (this.attractions[i].Id == CastToInt(tab[7]))
                {
                    this.attractions[i].Equipe.Add((Demon)this.toutLePersonnel[this.toutLePersonnel.Count() - 1]);
                }
            }
        }
        public void AddFantome(string [] tab)
        {
            this.toutLePersonnel.Add(new Fantome(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[6]), CastToInt(tab[7])));
            for (int i = 0; i < this.attractions.Count(); i++)
            {
                if (this.attractions[i].Id == CastToInt(tab[7]))
                {
                    this.attractions[i].Equipe.Add((Fantome)this.toutLePersonnel[this.toutLePersonnel.Count() - 1]);
                }
            }
        }
        public void AddLoupGarou(string [] tab)
        {
            this.toutLePersonnel.Add(new LoupGarou(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[6]), CastToInt(tab[7]), Convert.ToDouble(tab[8])));
            for (int i = 0; i < this.attractions.Count(); i++)
            {
                if (this.attractions[i].Id == CastToInt(tab[7]))
                {
                    this.attractions[i].Equipe.Add((LoupGarou)this.toutLePersonnel[this.toutLePersonnel.Count() - 1]);
                }
            }
        }
        public void AddVampire(string [] tab)
        {
            this.toutLePersonnel.Add(new Vampire(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[6]), CastToInt(tab[7]), (float)Convert.ToDouble(tab[8])));
            for (int i = 0; i < this.attractions.Count(); i++)
            {
                if (this.attractions[i].Id == CastToInt(tab[7]))
                {
                    this.attractions[i].Equipe.Add((Vampire)this.toutLePersonnel[this.toutLePersonnel.Count() - 1]);
                }
            }
        }
        public void AddZombie(string [] tab)
        {
            this.toutLePersonnel.Add(new Zombie(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[6]), CastToInt(tab[7]), CastToCouleurZ(tab[8]), CastToInt(tab[9])));
            for (int i = 0; i < this.attractions.Count(); i++)
            {
                if (this.attractions[i].Id == CastToInt(tab[7]))
                {
                    this.attractions[i].Equipe.Add((Zombie)this.toutLePersonnel[this.toutLePersonnel.Count() - 1]);
                }
            }
        }
        public void AddBoutique(string [] tab)
        {
            this.attractions.Add(new Boutique(bool.Parse(tab[4]), CastToInt(tab[1]), CastToInt(tab[3]), tab[2], tab[5], CastToTypeBoutique(tab[6])));
            this.AddMonstreToAttraction(tab);
        }
        public void AddDarkRide(string [] tab)
        {
            this.attractions.Add(new Darkride(bool.Parse(tab[4]), CastToInt(tab[1]), CastToInt(tab[3]), tab[2], tab[5], new TimeSpan(0, int.Parse(tab[6]), 0), bool.Parse(tab[7])));
            this.AddMonstreToAttraction(tab);
        }
        public void AddRollerCoaster(string [] tab)
        {
            this.attractions.Add(new RollerCoaster(bool.Parse(tab[4]), CastToInt(tab[1]), CastToInt(tab[3]), tab[2], tab[5], CastToInt(tab[7]), CastToCategorie(tab[6]), (float)Convert.ToDouble(tab[8])));
            this.AddMonstreToAttraction(tab);
        }
        public void AddSpectacle(string[] tab)
        {
            this.attractions.Add(new Spectacle(bool.Parse(tab[4]), CastToInt(tab[1]), CastToInt(tab[3]), tab[2], tab[5], ReturnListeDateTime(tab[8]), CastToInt(tab[7]), tab[6]));
            this.AddMonstreToAttraction(tab);
        }

        #endregion

        #region ADD MONSTRE MANUELLEMENT
        public void AjouterSorcierManu()
        {
            Console.WriteLine("Sorcier.");
            Console.WriteLine("Veuillez saisir un matricule.");
            int matricule = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un nom.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un prenom.");
            string prenom = Console.ReadLine();
            Console.WriteLine("Veuillez choisir un sexe parmi les trois cas suivants :\n1. Male.\n2. Femelle.\n3. Autre.");
            string sexe_string = Console.ReadLine();
            TypeSexe sexe = CastTypeSexe(sexe_string);
            Console.WriteLine("Veuillez saisir une fonction.");
            string fonction = Console.ReadLine();
            Console.WriteLine("Veuillez choisir un tatouage parmi les quatre cas suivants :\n1. Novice.\n2. Mega.\n3. Giga.\n4. Strata.");
            string tatouage_string = Console.ReadLine();
            Grade tatouage = CastToGrade(tatouage_string);
            int stop;
            List<string> liste_pouvoirs = new List<string>();
            Console.WriteLine("Veuillez saisir les pouvoirs de votre Sorcier, un par un.");
            do
            {
                Console.Clear();
                Console.WriteLine("Ajouter un pouvoirs. 1. (oui)\n2. (non)");
                stop = int.Parse(Console.ReadLine());
                switch (stop)
                {
                    case 1:
                        Console.WriteLine("Veuillez saisir le pouvoir.");
                        string pouvoir = Console.ReadLine();
                        liste_pouvoirs.Add(pouvoir);
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }

            } while (stop!=2);

            this.toutLePersonnel.Add(new Sorcier(matricule,nom,prenom,sexe,fonction,tatouage,liste_pouvoirs));
        }
        public void AjouterMonstreManu()
        {
            Console.WriteLine("Monstre.");
            Console.WriteLine("Veuillez saisir un matricule.");
            int matricule = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un nom.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un prenom.");
            string prenom = Console.ReadLine();
            Console.WriteLine("Veuillez choisir un sexe parmi les trois cas suivants :\n1. Male.\n2. Femelle.\n3. Autre.");
            string sexe_string = Console.ReadLine();
            TypeSexe sexe = CastTypeSexe(sexe_string);
            Console.WriteLine("Veuillez saisir une fonction.");
            string fonction = Console.ReadLine();
            Console.WriteLine("Veuillez choisir un tatouage parmi les quatre cas suivants :\n1. Novice.\n2. Mega.\n3. Giga.\n4. Strata.");
            string tatouage_string = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
            int affectation = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
            int cagnotte = int.Parse(Console.ReadLine());
            this.toutLePersonnel.Add(new Monstre(matricule, nom, prenom, sexe, fonction, affectation, cagnotte));
        }
        public void AjouterVampireManu()
        {

        }
        public void AjouterZombieManu()
        {

        }
        public void AjouterLoupGarouManu()
        {

        }
        public void AjouterFantomeManu()
        {

        }
        public void AjouterDemonManu()
        {

        }
        #endregion

        #region CAST

        public int CastToInt(string chaine)
        {
            if (chaine != "" && chaine!="neant" && chaine!="parc")
            {
                return int.Parse(chaine);
            }
            else return -1;
        }
        public TypeSexe CastTypeSexe(string chaine)
        {
            if (chaine == "male") return TypeSexe.male;
            else if (chaine == "femelle") return TypeSexe.femelle;
            else return TypeSexe.autre;
        }
        public CouleurZ CastToCouleurZ(string chaine)
        {
            if (chaine == "grisatre")
            {
                return CouleurZ.grisatre;
            }
            else return CouleurZ.bleuatre;
        }
        public TypeCategorie CastToCategorie(string chaine)
        {
            if (chaine == "assise")
            {
                return TypeCategorie.assise;
            }
            else if (chaine == "inversee")
            {
                return TypeCategorie.inversee;
            }
            else return TypeCategorie.bobsleigh;
        }
        public TypeBoutique CastToTypeBoutique(string chaine)
        {
            if (chaine == "barbeAPapa")
            {
                return TypeBoutique.barbeAPapa;
            }
            else if (chaine == "souvenir")
            {
                return TypeBoutique.souvenir;
            }
            else return TypeBoutique.nourriture;
        }
        public Grade CastToGrade(string chaine)
        {
            if (chaine == "novice") return Grade.novice;
            else if (chaine == "mega") return Grade.mega;
            else if (chaine == "giga") return Grade.giga;
            else return Grade.strata;
        }

        #endregion

        #region METHODES UTILISEES

        public string Fonction_Personnel(string fonction)
        {
            if (fonction == "neant")
            {
                return "Aucune fonction.";
            }
            else return fonction;
        }
        public void AddMonstreToAttraction(string[] tab)
        {
            for (int i = 0; i < this.toutLePersonnel.Count(); i++)
            {
                if (this.toutLePersonnel[i] is Monstre && ((Monstre)this.toutLePersonnel[i]).Affectation == int.Parse(tab[1]))
                {
                    if (this.toutLePersonnel[i] is Vampire) this.attractions[this.attractions.Count() - 1].Equipe.Add((Vampire)this.toutLePersonnel[i]);
                    else if (this.toutLePersonnel[i] is Demon) this.attractions[this.attractions.Count() - 1].Equipe.Add((Demon)this.toutLePersonnel[i]);
                    else if (this.toutLePersonnel[i] is Zombie) this.attractions[this.attractions.Count() - 1].Equipe.Add((Zombie)this.toutLePersonnel[i]);
                    else if (this.toutLePersonnel[i] is LoupGarou) this.attractions[this.attractions.Count() - 1].Equipe.Add((LoupGarou)this.toutLePersonnel[i]);
                    else if (this.toutLePersonnel[i] is Fantome) this.attractions[this.attractions.Count() - 1].Equipe.Add((Fantome)this.toutLePersonnel[i]);
                    else this.attractions[this.attractions.Count() - 1].Equipe.Add((Monstre)this.toutLePersonnel[i]);
                }
            }
        }
        public List<DateTime> ReturnListeDateTime(string chaine)
        {
            string[] tab = chaine.Split(' ');
            List<DateTime> liste = new List<DateTime>();
            for(int i = 0; i < tab.Length; i++)
            {
                string[] tab_int = tab[i].Split(':');
                int premier_num = int.Parse(tab_int[0]);
                int deuxieme_num = int.Parse(tab_int[1]);
                liste.Add(new DateTime(1,1,1,premier_num,deuxieme_num,0));
            }
            return liste;
        }
        public List<string> ConvertTabToListe(string[] tab)
        {
            List<string> newListe = new List<string>();
            for (int i = 0; i < tab.Length; i++)
            {
                newListe.Add(tab[i]);
            }
            return newListe;
        }
        public void Ajouter_MembreManuellement()
        {
            int numero;
            do
            {
                Console.Clear();
                Console.WriteLine("Tappez 1. Si vous voulez ajouter un Sorcier.\nTappez 2. Si vous voulez ajouter un Monstre.\n" +
                "Tappez 3. Si vous voulez ajouter un Demon.\nTappez 4. Si vous voulez ajouter un Fantome.\nTappez 5. Si vous voulez ajouter un Vampire.\n" +
                "Tappez 6. Si vous voulez ajouter un Loup Garou.\nTappez 7. Si vous voulez ajouter un Zombie.");
                numero = int.Parse(Console.ReadLine());
                switch (numero)
                {
                    case 1:
                        this.AjouterSorcierManu();
                        break;
                    case 2:
                        this.AjouterMonstreManu();
                        break;
                    case 3:
                        this.AjouterDemonManu();
                        break;
                    case 4:
                        this.AjouterFantomeManu();
                        break;
                    case 5:
                        this.AjouterVampireManu();
                        break;
                    case 6:
                        this.AjouterLoupGarouManu();
                        break;
                    case 7:
                        this.AjouterZombieManu();
                        break;
                    default:
                        break;
                }
            } while (numero != 1 && numero != 2 && numero != 3 && numero != 4 && numero != 5 && numero != 6 && numero != 7);
            Console.WriteLine("Votre membre du Personnel a été ajouté au logiciel.");
        }

        #endregion

        #region ACCESSEURS

        public List<Personnel> ToutLePersonnel
        {
            get { return this.toutLePersonnel; }
        }
        public List<Attraction> Attractions
        {
            get { return this.attractions; }
        }

        #endregion
    }
}
