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
                        this.Ajouter_AttractionManuellement();
                        break;
                    default:
                        break;
                }
            } while (numero!=1 && numero !=2);
        }
        public void ChangeFonction(Personnel personnel, string new_fonction)
        {
            personnel.Fonction = new_fonction;
        }
        public void ChangeAffectation(Monstre monstre, int new_affectation)
        {
            monstre.Affectation = new_affectation;
        }
        public void SortieSelonCritere()
        {
            int sortie;
            do
            {
                Console.Clear();
                Console.WriteLine("Mode de sortie ?\nTappez 1. Console.\nTappez 2. CSV.");
                sortie = int.Parse(Console.ReadLine());
                switch (sortie)
                {
                    case 1:
                        this.Sortie_Critere(true);
                        break;
                    case 2:
                        this.Sortie_Critere(false);
                        break;
                    default:
                        Program.MessageErreur();
                    break;
                  
                }
            } while (sortie != 1 && sortie != 2);
        }

        #endregion

        #region ADD_MONSTRE/ATTRACTION FROM CSV

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

        #region ADD MONSTRE/ATTRACTION MANUELLEMENT
        public void AjouterSorcierManu()
        {
            Console.WriteLine("Sorcier.");
            Console.WriteLine("Veuillez saisir un matricule.");
            int matricule = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un nom.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un prenom.");
            string prenom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un sexe parmi les trois cas suivants :\nMale.\nFemelle.\nAutre.");
            string sexe_string = Console.ReadLine();
            TypeSexe sexe = CastTypeSexe(sexe_string);
            Console.WriteLine("Veuillez saisir une fonction.");
            string fonction = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un tatouage parmi les quatre cas suivants :\nNovice.\nMega.\nGiga.\nStrata.");
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
            Console.WriteLine("Veuillez saisir un sexe parmi les trois cas suivants :\nMale.\nFemelle.\nAutre.");
            string sexe_string = Console.ReadLine();
            TypeSexe sexe = CastTypeSexe(sexe_string);
            Console.WriteLine("Veuillez saisir une fonction.");
            string fonction = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
            int affectation = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
            int cagnotte = int.Parse(Console.ReadLine());
            this.toutLePersonnel.Add(new Monstre(matricule, nom, prenom, sexe, fonction, affectation, cagnotte));
        }
        public void AjouterVampireManu()
        {
            Console.WriteLine("Vampire.");
            Console.WriteLine("Veuillez saisir un matricule.");
            int matricule = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un nom.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un prenom.");
            string prenom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un sexe parmi les trois cas suivants :\nMale.\nFemelle.\nAutre.");
            string sexe_string = Console.ReadLine();
            TypeSexe sexe = CastTypeSexe(sexe_string);
            Console.WriteLine("Veuillez saisir une fonction.");
            string fonction = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
            int affectation = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
            int cagnotte = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un indice de luminosite.");
            float luminosite = (float)Convert.ToDouble(Console.ReadLine());
            this.toutLePersonnel.Add(new Vampire(matricule, nom, prenom, sexe, fonction, affectation, cagnotte,luminosite));
        }
        public void AjouterZombieManu()
        {
            Console.WriteLine("Zombie.");
            Console.WriteLine("Veuillez saisir un matricule.");
            int matricule = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un nom.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un prenom.");
            string prenom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un sexe parmi les trois cas suivants :\nMale.\nFemelle.\nAutre.");
            string sexe_string = Console.ReadLine();
            TypeSexe sexe = CastTypeSexe(sexe_string);
            Console.WriteLine("Veuillez saisir une fonction.");
            string fonction = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
            int affectation = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
            int cagnotte = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un teint parmi les deux cas suivants :\nBleuatre.\nGrisatre.");
            string teint_string = Console.ReadLine();
            CouleurZ teint = CastToCouleurZ(teint_string);
            Console.WriteLine("Veuillez saisir un degre de decomposition.");
            int decomposition = int.Parse(Console.ReadLine());
            this.toutLePersonnel.Add(new Zombie(matricule, nom, prenom, sexe, fonction, affectation, cagnotte,teint,decomposition));
        }
        public void AjouterLoupGarouManu()
        {
            Console.WriteLine("Loup Garou.");
            Console.WriteLine("Veuillez saisir un matricule.");
            int matricule = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un nom.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un prenom.");
            string prenom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un sexe parmi les trois cas suivants :\nMale.\nFemelle.\nAutre.");
            string sexe_string = Console.ReadLine();
            TypeSexe sexe = CastTypeSexe(sexe_string);
            Console.WriteLine("Veuillez saisir une fonction.");
            string fonction = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
            int affectation = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
            int cagnotte = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un indice de cruaute.");
            int cruaute = int.Parse(Console.ReadLine());
            this.toutLePersonnel.Add(new LoupGarou(matricule, nom, prenom, sexe, fonction, affectation, cagnotte,cruaute ));
        }
        public void AjouterFantomeManu()
        {
            Console.WriteLine("Fantome.");
            Console.WriteLine("Veuillez saisir un matricule.");
            int matricule = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un nom.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un prenom.");
            string prenom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un sexe parmi les trois cas suivants :\nMale.\nFemelle.\nAutre.");
            string sexe_string = Console.ReadLine();
            TypeSexe sexe = CastTypeSexe(sexe_string);
            Console.WriteLine("Veuillez saisir une fonction.");
            string fonction = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
            int affectation = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
            int cagnotte = int.Parse(Console.ReadLine());
            this.toutLePersonnel.Add(new Fantome(matricule, nom, prenom, sexe, fonction, affectation, cagnotte));
        }
        public void AjouterDemonManu()
        {
            Console.WriteLine("Demon.");
            Console.WriteLine("Veuillez saisir un matricule.");
            int matricule = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un nom.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un prenom.");
            string prenom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un sexe parmi les trois cas suivants :\nMale.\nFemelle.\nAutre.");
            string sexe_string = Console.ReadLine();
            TypeSexe sexe = CastTypeSexe(sexe_string);
            Console.WriteLine("Veuillez saisir une fonction.");
            string fonction = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
            int affectation = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
            int cagnotte = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir une force pour le demon.");
            int force = int.Parse(Console.ReadLine());
            this.toutLePersonnel.Add(new Demon(matricule, nom, prenom, sexe, fonction, affectation, cagnotte,force));
        }
        public void AjouterBoutiqueManu()
        {
            Console.WriteLine("Boutique.");
            Console.WriteLine("Besoin specifique ?\nTappez 1. Oui\nTappez 2. Non.");
            int numero = int.Parse(Console.ReadLine());
            bool besoinSpecifique = false;
            do
            {
                switch (numero)
                {
                    case 1:
                        besoinSpecifique = true;
                        break;
                    case 2:
                        besoinSpecifique = false;
                        break;
                    default:
                        break;
                }
            } while (numero!=1 && numero!=2);
            Console.WriteLine("Veuillez saisir l'id de l'attraction.");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nombre minmum de monstres.");
            int nombreMinimumMonstre = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nom de l'attraction.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le type de besoin.");
            string typeBesoin = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un type de Boutique parmi les trois cas suivants :\nSouvenir.\nBarbeAPapa.\nNourriture.");
            string typeBoutique_string = Console.ReadLine();
            TypeBoutique typeBoutique = CastToTypeBoutique(typeBoutique_string);
            this.attractions.Add(new Boutique(besoinSpecifique, id,nombreMinimumMonstre,nom,typeBesoin,typeBoutique));
        }
        public void AjouterDarkRideManu()
        {
            Console.WriteLine("DarkRide.");
            Console.WriteLine("Besoin specifique ?\nTappez 1. Oui\nTappez 2. Non.");
            int numero = int.Parse(Console.ReadLine());
            bool besoinSpecifique = false;
            do
            {
                switch (numero)
                {
                    case 1:
                        besoinSpecifique = true;
                        break;
                    case 2:
                        besoinSpecifique = false;
                        break;
                    default:
                        break;
                }
            } while (numero != 1 && numero != 2);
            Console.WriteLine("Veuillez saisir l'id de l'attraction.");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nombre minmum de monstres.");
            int nombreMinimumMonstre = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nom de l'attraction.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le type de besoin.");
            string typeBesoin = Console.ReadLine();
            Console.WriteLine("Veuillez saisir une durée d'attraction en minutes et en secondes.\nEn minute ?");
            int duree_minute = int.Parse(Console.ReadLine());
            Console.WriteLine("En seconde ?");
            int duree_seconde = int.Parse(Console.ReadLine());
            TimeSpan duree = new TimeSpan(0, duree_minute, duree_seconde);
            Console.WriteLine("Attraction avec vehicule ?\nTappez 1. Oui\nTappez 2. Non.");
            int numero2 = int.Parse(Console.ReadLine());
            bool vehicule = false;
            do
            {
                switch (numero2)
                {
                    case 1:
                        vehicule = true;
                        break;
                    case 2:
                        vehicule = false;
                        break;
                    default:
                        break;
                }
            } while (numero != 1 && numero != 2);
            this.attractions.Add(new Darkride(besoinSpecifique, id, nombreMinimumMonstre, nom, typeBesoin,duree,vehicule));
        }
        public void AjouterRollerCoasterManu()
        {
            Console.WriteLine("RollerCoaster.");
            Console.WriteLine("Besoin specifique ?\nTappez 1. Oui\nTappez 2. Non.");
            int numero = int.Parse(Console.ReadLine());
            bool besoinSpecifique = false;
            do
            {
                switch (numero)
                {
                    case 1:
                        besoinSpecifique = true;
                        break;
                    case 2:
                        besoinSpecifique = false;
                        break;
                    default:
                        break;
                }
            } while (numero != 1 && numero != 2);
            Console.WriteLine("Veuillez saisir l'id de l'attraction.");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nombre minmum de monstres.");
            int nombreMinimumMonstre = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nom de l'attraction.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le type de besoin.");
            string typeBesoin = Console.ReadLine();
            Console.WriteLine("Veuillez saisir un age minimum.");
            int ageMini = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un type de Categorie de votre Attraction parmi les trois cas suivants :\nAssise.\nInversee.\nBobsleigh.");
            string categorie_string = Console.ReadLine();
            TypeCategorie categorie = CastToCategorie(categorie_string);
            Console.WriteLine("Veuillez saisir une taille minimum.");
            float tailleMinimum = (float)Convert.ToDouble(Console.ReadLine());
            this.attractions.Add(new RollerCoaster(besoinSpecifique, id, nombreMinimumMonstre, nom, typeBesoin,ageMini,categorie,tailleMinimum));
        }
        public void AjouterSpectacleManu()
        {
            Console.WriteLine("Spectacle.");
            Console.WriteLine("Besoin specifique ?\nTappez 1. Oui\nTappez 2. Non.");
            int numero = int.Parse(Console.ReadLine());
            bool besoinSpecifique = false;
            do
            {
                switch (numero)
                {
                    case 1:
                        besoinSpecifique = true;
                        break;
                    case 2:
                        besoinSpecifique = false;
                        break;
                    default:
                        break;
                }
            } while (numero != 1 && numero != 2);
            Console.WriteLine("Veuillez saisir l'id de l'attraction.");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nombre minmum de monstres.");
            int nombreMinimumMonstre = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nom de l'attraction.");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le type de besoin.");
            string typeBesoin = Console.ReadLine();

            Console.WriteLine("Veuillez saisir le nombre de places pour le spectacle.");
            int nbPlaces = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nom de la salle.");
            string nomSalle = Console.ReadLine();
            Console.WriteLine("Veuillez saisir les horaires du spectacle.");
            int stop;
            List<DateTime> liste_horaires = new List<DateTime>();
            do
            {
                Console.Clear();
                Console.WriteLine("Ajouter une horaire ?. 1. (oui)\n2. (non)");
                stop = int.Parse(Console.ReadLine());
                switch (stop)
                {
                    case 1:
                        Console.WriteLine("Veuillez saisir l'heure de debut de seance.");
                        int horaire_debut_heure = int.Parse(Console.ReadLine());
                        Console.WriteLine("Veuillez saisir la minute du debut de seance.");
                        int horaire_debut_minute = int.Parse(Console.ReadLine());
                        liste_horaires.Add(new DateTime(1,1,1,horaire_debut_heure,horaire_debut_minute,0));
                        Console.WriteLine("Veuillez saisir l'heure de fin de seance.");
                        int horaire_fin_heure = int.Parse(Console.ReadLine());
                        Console.WriteLine("Veuillez saisir la minute de fin de seance.");
                        int horaire_fin_minute = int.Parse(Console.ReadLine());
                        liste_horaires.Add(new DateTime(1, 1, 1, horaire_fin_heure, horaire_fin_minute, 0));
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }

            } while (stop != 2);
            this.attractions.Add(new Spectacle(besoinSpecifique, id, nombreMinimumMonstre, nom, typeBesoin,liste_horaires,nbPlaces,nomSalle));
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
            if (chaine.ToLower() == "male") return TypeSexe.male;
            else if (chaine.ToLower() == "femelle") return TypeSexe.femelle;
            else return TypeSexe.autre;
        }
        public CouleurZ CastToCouleurZ(string chaine)
        {
            if (chaine.ToLower() == "grisatre")
            {
                return CouleurZ.grisatre;
            }
            else return CouleurZ.bleuatre;
        }
        public TypeCategorie CastToCategorie(string chaine)
        {
            if (chaine.ToLower() == "assise")
            {
                return TypeCategorie.assise;
            }
            else if (chaine.ToLower() == "inversee")
            {
                return TypeCategorie.inversee;
            }
            else return TypeCategorie.bobsleigh;
        }
        public TypeBoutique CastToTypeBoutique(string chaine)
        {
            if (chaine.ToLower() == "barbeAPapa")
            {
                return TypeBoutique.barbeAPapa;
            }
            else if (chaine.ToLower() == "souvenir")
            {
                return TypeBoutique.souvenir;
            }
            else return TypeBoutique.nourriture;
        }
        public Grade CastToGrade(string chaine)
        {
            if (chaine.ToLower() == "novice") return Grade.novice;
            else if (chaine.ToLower() == "mega") return Grade.mega;
            else if (chaine.ToLower() == "giga") return Grade.giga;
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
        public void Ajouter_AttractionManuellement()
        {
            int numero;
            do
            {
                Console.Clear();
                Console.WriteLine("Tappez 1. Si vous voulez ajouter une Boutique.\nTappez 2. Si vous voulez ajouter un Darkride.\n" +
                "Tappez 3. Si vous voulez ajouter un RollerCoaster.\nTappez 4. Si vous voulez ajouter un Spectacle.");
                numero = int.Parse(Console.ReadLine());
                switch (numero)
                {
                    case 1:
                        this.AjouterBoutiqueManu();
                        break;
                    case 2:
                        this.AjouterDarkRideManu();
                        break;
                    case 3:
                        this.AjouterRollerCoasterManu();
                        break;
                    case 4:
                        this.AjouterSpectacleManu();
                        break;
                    default:
                        break;
                }
            } while (numero != 1 && numero != 2 && numero != 3 && numero != 4);
            Console.WriteLine("Votre Attraction a été ajoutée au logiciel.");
        }
        public void Sortie_Critere(bool console)
        {
            int critere;
            do
            {
                Console.Clear();
                if(console) Console.WriteLine("En mode Console.");
                else Console.WriteLine("Ecriture dans un CSV.");
                Console.WriteLine("Veuillez saisir un critère parmi les propositions suivantes.\nTappez 1. Si vous voulez afficher afficher la liste du personnel par categorie.\n" +
                    "Tappez 2. Si vous voulez afficher la liste des attractions en maintenance.");
                critere = int.Parse(Console.ReadLine());
                switch (critere)
                {
                    case 1:
                        this.AfficherSelonCategorie(console);
                        break;
                    case 2:

                        break;
                    default:
                        Program.MessageErreur();
                        break;
                    
                }
            } while (critere !=1 && critere!=2);
        }
        public void AfficherSelonCategorie(bool console)
        {
            int numero_personnel;
            do
            {
                Console.Clear();
                Console.WriteLine("Liste du personnel par catégorie.");
                Console.WriteLine("Tappez 1. Par Sorcier.\nTappez 2. Par Monstre.\nTappez 3. Par Demon.\nTappez 4. Par Vampire.\nTappez 5. Par Loup Garou.\n" +
                    "Tappez 6. Par Zombie.\nTappez 7. Par Fantome.");
                numero_personnel = int.Parse(Console.ReadLine());
                switch (numero_personnel)
                {
                    case 1:
                        if (console)
                        {
                            Console.Clear();
                            int c = 1;
                            Console.WriteLine("Liste des Sorciers :");
                            for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                            {
                                if (this.toutLePersonnel[i] is Sorcier)
                                {
                                    Console.Write(c + ". ");
                                    this.AfficherParPersonnel((Sorcier)this.toutLePersonnel[i]);
                                    c++;
                                }
                            }
                            Console.ReadKey();
                        }
                        else
                        {

                        }
                        break;
                    case 2:
                        Console.Clear();
                        int b = 1;
                        Console.WriteLine("Liste des Monstres :");
                        for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                        {
                            if (this.toutLePersonnel[i] is Monstre && !(this.toutLePersonnel[i] is Demon)
                                && !(this.toutLePersonnel[i] is Zombie) && !(this.toutLePersonnel[i] is Vampire)
                                && !(this.toutLePersonnel[i] is Fantome) && !(this.toutLePersonnel[i] is LoupGarou))
                            {
                                Console.Write(b + ". ");
                                this.AfficherParPersonnel((Monstre)this.toutLePersonnel[i]);
                                b++;
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Liste des Demons :");
                        int a = 1;
                        for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                        {
                            if (this.toutLePersonnel[i] is Demon)
                            {
                                Console.Write(a + ". ");
                                this.AfficherParPersonnel((Demon)this.toutLePersonnel[i]);
                                a++;
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        int x = 1;
                        Console.WriteLine("Liste des Vampires :");
                        for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                        {
                            if (this.toutLePersonnel[i] is Vampire)
                            {
                                Console.Write(x + ". ");
                                this.AfficherParPersonnel((Vampire)this.toutLePersonnel[i]);
                                x++;
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Liste des Loup-Garous :");
                        int l = 1;
                        for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                        {
                            if (this.toutLePersonnel[i] is LoupGarou)
                            {
                                Console.Write(l + ". ");
                                this.AfficherParPersonnel((LoupGarou)this.toutLePersonnel[i]);
                                l++;
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        int j = 1;
                        Console.WriteLine("Liste des Zombies :");
                        for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                        {
                            if (this.toutLePersonnel[i] is Zombie)
                            {
                                Console.Write(j + ". ");
                                this.AfficherParPersonnel((Zombie)this.toutLePersonnel[i]);
                                j++;
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Liste des Fantomes :");
                        int k = 1;
                        for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                        {
                            if (this.toutLePersonnel[i] is Fantome)
                            {
                                Console.Write(k + ". ");
                                this.AfficherParPersonnel((Fantome)this.toutLePersonnel[i]);
                                k++;
                            }
                        }
                        Console.ReadKey();
                        break;
                    default:
                        Program.MessageErreur();
                        break;
                }
            } while (numero_personnel != 1 && numero_personnel != 2 && numero_personnel != 3 && numero_personnel != 4 
            && numero_personnel != 5 && numero_personnel != 6 && numero_personnel != 7);
        }
        public void AfficherParPersonnel(Personnel personnel)
        {
             if (personnel is Sorcier) Console.WriteLine(personnel.Prenom+" " + personnel.Nom);
             else if (personnel is Demon) Console.WriteLine(personnel.Prenom + " " + personnel.Nom);
             else if (personnel is Vampire) Console.WriteLine(personnel.Prenom + " " + personnel.Nom);
             else if (personnel is LoupGarou) Console.WriteLine(personnel.Prenom + " " + personnel.Nom);
             else if (personnel is Fantome) Console.WriteLine(personnel.Prenom + " " + personnel.Nom);
             else if (personnel is Zombie) Console.WriteLine(personnel.Prenom + " " + personnel.Nom);
             else Console.WriteLine(personnel.Prenom + " " + personnel.Nom);
        }


        public void Sortie_Critere_CSV()
        {
            int critere;
            do
            {
                Console.Clear();
                Console.WriteLine("Dans un fichier CSV situé à l'emplacement C:/temp/write.csv");
                Console.WriteLine("Veuillez saisir un critère parmi les propositions suivantes.\nTappez 1. Si vous voulez afficher afficher la liste du personnel par categorie.\n" +
                    "Tappez 2. Si vous voulez afficher la liste des attractions en maintenance.");
                critere = int.Parse(Console.ReadLine());
                switch (critere)
                {
                    case 1:
                        this.AfficherSelonCategorie();
                        break;
                    case 2:

                        break;
                    default:
                        Program.MessageErreur();
                        break;

                }
            } while (critere != 1 && critere != 2);
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
