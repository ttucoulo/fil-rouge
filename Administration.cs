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
                        case "spectacles":
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
            try
            {
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
            catch
            {
                Console.WriteLine("Vous n'avez pas saisi un nombre entier.");
                Console.ReadKey();
            }
        } 
        public void ChangeOuverture()
        {
            for (int i = 0; i < this.attractions.Count(); i++)
            {
                if (this.attractions[i].Nom == "Tout pour 1 euro")
                {
                    this.attractions[i].Ouvert = true;
                    this.attractions[i].Maintenance = false;
                    this.attractions[i].DureeMaintenance = new TimeSpan(0, 0, 0);
                    this.attractions[i].NatureMaintenance = "";
                }
            }
        }
        public void ChangeOuverture2(Attraction a,string maintenance)
        {
                    a.Ouvert = true;
                    a.Maintenance = false;
                    a.DureeMaintenance = new TimeSpan(0, 0, 0);
                    a.NatureMaintenance = maintenance;
        }
        public void AttractionEnMaintenance(bool console)
        {
            string nomFich = "C:/Users/thiba/OneDrive/Documents/Visual Studio 2017/Projects/fil_rouge_git/POOI_GRP_TUCOULOU_FEURGARD/bin/Debug/writeMaintenance.csv";
            StreamWriter fichEcr = new StreamWriter(nomFich, true);
            for (int i = 0; i < this.attractions.Count(); i++)
            {
                if (this.attractions[i].Maintenance)
                {
                    if (console) Console.WriteLine(this.attractions[i].ToString());
                    else fichEcr.WriteLine(this.attractions[i].ToString());
                }
            }
            fichEcr.Close();
        }
        public void Demo()
        {
            Console.Clear();
            Console.WriteLine("Bienvenue dans le logiciel de gestion administrative du parc Zombillenium.");
            Console.WriteLine("Vous allez assister à une demo de notre logiciel. Pour passer à l'action suivante, vous presserez une touche.");
            Console.WriteLine("Pour commencer, veuillez appuyez sur une touche.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Tout d'abord, nous allons charger les membres du personnel et les attractions du fichier csv Listing.csv");
            this.AjoutMembresFromCSV("C:/Users/thiba/OneDrive/Documents/Visual Studio 2017/Projects/fil_rouge_git/POOI_GRP_TUCOULOU_FEURGARD/bin/Debug/Listing.csv");
            Console.WriteLine("Ca y est, tous les membres du personnel et attractions ont été ajoutés avec succès.");

            Console.WriteLine("Affichage de la liste de Personnel :\n");
            for (int i = 0; i < this.ToutLePersonnel.Count(); i++)
            {
                Console.WriteLine(this.toutLePersonnel[i].Nom + " " + this.ToutLePersonnel[i].Prenom + " " + this.ToutLePersonnel[i].Matricule);
            }
            Console.WriteLine();
            Console.WriteLine("Affichage de la liste d'attractions :\n");
            for (int i = 0; i < this.Attractions.Count(); i++)
            {
                Console.WriteLine(this.Attractions[i].Nom + " " + this.Attractions[i].Id);
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Maintenant, je vais ajouter manuellement un membre du personnel avec les critères suivants :\n" +
                "Zombie, 66001, Dupont Bernard, Male , assistant , 645 , 5000 , 1.3 ");
            Vampire new_vampire = new Vampire(66001, "Dupont", "Bernard", TypeSexe.male, "assistant", 645, 5000, (float)1.3);
            this.ToutLePersonnel.Add(new_vampire);
            this.CheckAttraction(new_vampire);
            Console.WriteLine("Ajout effectué.\n");
            Console.WriteLine("Verification :\nAffichons le dernier élement de la liste de personnel : \n");
            Console.WriteLine(this.ToutLePersonnel[this.ToutLePersonnel.Count() - 1].Nom + " " + this.ToutLePersonnel[this.ToutLePersonnel.Count() - 1].Prenom + " " + this.ToutLePersonnel[this.ToutLePersonnel.Count() - 1].Matricule);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Je vais ajouter manuellement une attraction sans maintenance avec les critères suivants :\n" +
                "RollerCoaster, pas de besoin specifique, 118, 1 monstre minimum, Falaises dangereuses, zombie, 11 ans minimum, Assise, 1.25 m minimum");
            RollerCoaster new_rollercoaster = new RollerCoaster(false, 118, 9, "Falaises dangereuses", "zombie", 11, TypeCategorie.assise, (float)1.25);
            this.Attractions.Add(new_rollercoaster);
            this.CheckMonstre(new_rollercoaster.Id);
            Console.WriteLine("Ajout effectué.\n");
            Console.WriteLine("Verification :\nAffichons le dernier élement de la liste d'attractions : \n");
            Console.WriteLine(this.Attractions[this.Attractions.Count() - 1].Nom + " " + this.Attractions[this.Attractions.Count() - 1].Id);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Et puis deux autres attractions en maintenance :  \nDarkride, pas de besoin specifique, 48h de maintenance, equipe :Bernard Dupont ajouté precedemment, " +
                "429, en maintenance,reparation, 1 monstre minmum, Balade montagneuse, fermée, vampire, 15min,en vehicule.\n\n" +
                "Boutique, pas de besoin specifique, 24h de maintenance, equipe : un monstre quelconque de la liste, 625, en maintenance,reparation,1 monstre minimum, Sensations fortes, fermée, monstre,souvenir\n\n");
            List<Monstre> liste = new List<Monstre>();
            liste.Add(new_vampire);
            Darkride new_darkride = new Darkride(false, new TimeSpan(48, 0, 0), liste, 429, true, "reparation", 1, "Balade montagneuse", false, "vampire", new TimeSpan(0, 15, 0), true);
            this.Attractions.Add(new_darkride);
            this.CheckMonstre(new_darkride.Id);
            List<Monstre> liste1 = new List<Monstre>();
            liste1.Add((Monstre)this.ToutLePersonnel[3]);
            Boutique new_boutique = new Boutique(false, new TimeSpan(24, 0, 0), liste1, 625, true, "reperation", 1, "Tout pour 1 euro", false, "monstre", TypeBoutique.souvenir);
            this.Attractions.Add(new_boutique);
            this.CheckMonstre(new_boutique.Id);
            Console.WriteLine("Ajouts effectués\n\n");
            Console.WriteLine("Verification : \n\nReaffichons la liste d'attractions mise à jour.\n\n");
            for (int i = 0; i < this.Attractions.Count(); i++)
            {
                Console.WriteLine(this.Attractions[i].Nom + " " + this.Attractions[i].Id);
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("On va maintenant faire evoluer les membres du personnel");
            Console.WriteLine("La directrice Communication va passer Directrice recrutement\n");
            for (int i = 0; i < this.ToutLePersonnel.Count(); i++)
            {
                if (this.ToutLePersonnel[i].Fonction == "directrice Communication")
                {
                    this.ChangeFonction(this.ToutLePersonnel[i], "directrice Recrutement");
                }
            }
            Console.WriteLine("Changement de fonction effectué\n");
            Console.WriteLine("Verification : \nAffichons la fonction de Deborah Malkiewicz, matricule : 66604 (ancienne directrice communication).\n");
            Console.WriteLine(this.ToutLePersonnel[this.ReturnIndexList(66604, true)].Fonction);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Changeons l'affectation du demon Aurelien Zahner, matricule 66987\n");
            ((Monstre)this.ToutLePersonnel[this.ReturnIndexList(66987, true)]).Affectation = 645;
            Console.WriteLine("Changement d'affectation effectué\n");
            Console.WriteLine("Verification : \nAffichons l'affectation du Aurelien Zahner après modification.\n");
            Console.WriteLine("Nouvelle affectation : " + ((Monstre)this.ToutLePersonnel[this.ReturnIndexList(66987, true)]).Affectation);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Maintenant, on va sortir tous les Vampires de nos membres du personnel en sortie console et en même temps dans un fichier csv qui s'appelera write.csv.\n\n");
            string nomFichier = "C:/Users/thiba/OneDrive/Documents/Visual Studio 2017/Projects/fil_rouge_git/POOI_GRP_TUCOULOU_FEURGARD/bin/Debug/write.csv";
            StreamWriter fichEcrire = new StreamWriter(nomFichier, true);
            for (int i = 0; i < this.ToutLePersonnel.Count(); i++)
            {
                if (this.ToutLePersonnel[i] is Vampire)
                {
                    this.AfficherParPersonnel(this.ToutLePersonnel[i], true, fichEcrire);
                    this.AfficherParPersonnel(this.ToutLePersonnel[i], false, fichEcrire);
                }
            }
            fichEcrire.Close();
            Console.WriteLine("\n");
            Console.WriteLine("Les Vampires ont été affichés en console et sont affichés dans le fichier csv.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Nous allons trier la liste des attractions par ordre croissant d'identifiants\n");
            this.Attractions.Sort();
            foreach (Attraction a in this.Attractions) Console.WriteLine(a.ToString());
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Nous allons trier la liste du personnel en commançant par les monstres par ordre croissant de cagnottes\n\n");
            this.Tri_Cagnottes();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Nous allons maintenant trier par ordre croissant les demons par force\n\n");
            this.Tri_Demon();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Sortons toutes les attractions en maintenance.\n");
            this.AttractionEnMaintenance(true);    //Affichage console
            this.AttractionEnMaintenance(false);   //Affichage csv
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Changeons la boutique \"Tout pour 1 euro\" du statut maintenance à ouvert.");
            this.ChangeOuverture();
            Console.WriteLine("Ouverture de l'attraction effectuée.\n\n");
            Console.WriteLine("Verification :\n\n");
            Console.WriteLine("Affichons les attractions en maintenance :\n\n");
            foreach (Attraction a in this.Attractions)
            {
                if (a.Maintenance) Console.WriteLine(a.ToString());
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Enlevons 80 de cagnotte au monstre Aton Noudjemet de matricule 66634 pour la faire tomber en dessous de 50.\n");
            Console.WriteLine("Tout d'abord, affichons sa cagnotte actuelle ainsi que son affectation :\n");
            Console.WriteLine("Cagnotte actuelle : " + ((Monstre)this.ToutLePersonnel[this.ReturnIndexList(66634, true)]).Cagnotte + "\nAffectation actuelle : " + ((Monstre)this.ToutLePersonnel[this.ReturnIndexList(66634, true)]).Affectation + "\n");
            for (int i = 0; i < this.ToutLePersonnel.Count(); i++)
            {
                if (this.ToutLePersonnel[i] is Monstre)
                {
                    ((Monstre)this.ToutLePersonnel[i]).ModifierCagnotte(((Monstre)this.ToutLePersonnel[this.ReturnIndexList(66634, true)]), -80);
                }
            }
            Console.WriteLine("Modification de cagnotte effectuée !\n\n\nAffichons sa nouvelle cagnotte :\nNouvelle cagnotte : " + ((Monstre)this.ToutLePersonnel[this.ReturnIndexList(66634, true)]).Cagnotte + "\n\nOn va maintenant verifier si son affectation a bien été modifiée car sa cagnotte est descendu en dessous de 50.\nJe rappelle" +
              " qu'une affectation à 1000 correspond à une circulation dans le parc et qu'une affectation à 684 correspond à un stand à barbe a papa.\n");
            Console.WriteLine("Nouvelle affectation de Aton Noudjemet : " + ((Monstre)this.ToutLePersonnel[this.ReturnIndexList(66634, true)]).Affectation);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("FIN DE LA DEMO");
            Console.ReadKey();
        }
        #endregion

        #region ADD_MONSTRE/ATTRACTION FROM CSV

        public void AddSorcier(string [] tab)
        {
            this.toutLePersonnel.Add(new Sorcier(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]),Fonction_Personnel(tab[5]), CastToGrade(tab[6]), ConvertTabToListe(tab[7].Split('-'))));
        }
        public void AddMonstre( string [] tab)
        {
            Monstre new_monstre = new Monstre(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[7]), CastToInt(tab[6]));
            this.toutLePersonnel.Add(new_monstre);
            CheckAttraction(new_monstre);
        }
        public void AddDemon( string [] tab)
        {
            Demon new_demon = new Demon(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[7]), CastToInt(tab[6]), CastToInt(tab[8]));
            this.toutLePersonnel.Add(new_demon);
            CheckAttraction(new_demon);
        }
        public void AddFantome(string [] tab)
        {
            Fantome new_fantome = new Fantome(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[7]), CastToInt(tab[6]));
            this.toutLePersonnel.Add(new_fantome);
            CheckAttraction(new_fantome);
        }
        public void AddLoupGarou(string [] tab)
        {
            LoupGarou new_loupGarou = new LoupGarou(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[7]), CastToInt(tab[6]), Convert.ToDouble(tab[8]));
            this.toutLePersonnel.Add(new_loupGarou);
            CheckAttraction(new_loupGarou);
        }
        public void AddVampire(string [] tab)
        {
            Vampire new_vampire = new Vampire(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[7]), CastToInt(tab[6]), (float)Convert.ToDouble(tab[8]));
            this.toutLePersonnel.Add(new_vampire);
            CheckAttraction(new_vampire);
        }
        public void AddZombie(string [] tab)
        {
            Zombie new_zombie = new Zombie(CastToInt(tab[1]), tab[2], tab[3], CastTypeSexe(tab[4]), Fonction_Personnel(tab[5]), CastToInt(tab[7]), CastToInt(tab[6]), CastToCouleurZ(tab[8]), CastToInt(tab[9]));
            this.toutLePersonnel.Add(new_zombie);
            CheckAttraction(new_zombie);
        }
        public void AddBoutique(string [] tab)
        {
            this.attractions.Add(new Boutique(bool.Parse(tab[4]), CastToInt(tab[1]), CastToInt(tab[3]), tab[2], tab[5], CastToTypeBoutique(tab[6])));
            this.CheckMonstre(int.Parse(tab[1]));
        }
        public void AddDarkRide(string [] tab)
        {
            this.attractions.Add(new Darkride(bool.Parse(tab[4]), CastToInt(tab[1]), CastToInt(tab[3]), tab[2], tab[5], new TimeSpan(0, int.Parse(tab[6]), 0), bool.Parse(tab[7])));
            this.CheckMonstre(int.Parse(tab[1]));
        }
        public void AddRollerCoaster(string [] tab)
        {
            this.attractions.Add(new RollerCoaster(bool.Parse(tab[4]), CastToInt(tab[1]), CastToInt(tab[3]), tab[2], tab[5], CastToInt(tab[7]), CastToCategorie(tab[6]), (float)Convert.ToDouble(tab[8])));
            this.CheckMonstre(int.Parse(tab[1]));
        }
        public void AddSpectacle(string[] tab)
        {
            this.attractions.Add(new Spectacle(bool.Parse(tab[4]), CastToInt(tab[1]), CastToInt(tab[3]), tab[2], tab[5], ReturnListeDateTime(tab[8]), CastToInt(tab[7]), tab[6]));
            this.CheckMonstre(int.Parse(tab[1]));
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
            int affectation;
            do
            {
                Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
                affectation = int.Parse(Console.ReadLine());

            } while (!this.Check_Affectation(affectation));
            int cagnotte;
            do
            {
                Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
                cagnotte = int.Parse(Console.ReadLine());
            } while (!this.Check_Cagnotte(cagnotte));
            Monstre new_monstre = new Monstre(matricule, nom, prenom, sexe, fonction, affectation, cagnotte);
            this.toutLePersonnel.Add(new_monstre);
            this.CheckAttraction(new_monstre);
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
            int affectation;
            do
            {
                Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
                affectation = int.Parse(Console.ReadLine());

            } while (!this.Check_Affectation(affectation));
            int cagnotte;
            do
            {
                Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
                cagnotte = int.Parse(Console.ReadLine());
            } while (!this.Check_Cagnotte(cagnotte));
            Console.WriteLine("Veuillez saisir un indice de luminosite.");
            float luminosite = (float)Convert.ToDouble(Console.ReadLine());
            Vampire new_vampire = new Vampire(matricule, nom, prenom, sexe, fonction, affectation, cagnotte, luminosite);
            this.toutLePersonnel.Add(new_vampire);
            this.CheckAttraction(new_vampire);
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
            int affectation;
            do
            {
                Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
                affectation = int.Parse(Console.ReadLine());

            } while (!this.Check_Affectation(affectation));
            int cagnotte;
            do
            {
                Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
                cagnotte = int.Parse(Console.ReadLine());
            } while (!this.Check_Cagnotte(cagnotte));
            Console.WriteLine("Veuillez saisir un teint parmi les deux cas suivants :\nBleuatre.\nGrisatre.");
            string teint_string = Console.ReadLine();
            CouleurZ teint = CastToCouleurZ(teint_string);
            Console.WriteLine("Veuillez saisir un degre de decomposition.");
            int decomposition = int.Parse(Console.ReadLine());
            Zombie new_zombie = new Zombie(matricule, nom, prenom, sexe, fonction, affectation, cagnotte, teint, decomposition);
            this.toutLePersonnel.Add(new_zombie);
            this.CheckAttraction(new_zombie);
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
            int affectation;
            do
            {
                Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
                affectation = int.Parse(Console.ReadLine());

            } while (!this.Check_Affectation(affectation));
            int cagnotte;
            do
            {
                Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
                cagnotte = int.Parse(Console.ReadLine());
            } while (!this.Check_Cagnotte(cagnotte));
            Console.WriteLine("Veuillez saisir un indice de cruaute.");
            int cruaute = int.Parse(Console.ReadLine());
            LoupGarou new_loupGarou = new LoupGarou(matricule, nom, prenom, sexe, fonction, affectation, cagnotte, cruaute);
            this.toutLePersonnel.Add(new_loupGarou);
            this.CheckAttraction(new_loupGarou);
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
            int affectation;
            do
            {
                Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
                affectation = int.Parse(Console.ReadLine());

            } while (!this.Check_Affectation(affectation));
            int cagnotte;
            do
            {
                Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
                cagnotte = int.Parse(Console.ReadLine());
            } while (!this.Check_Cagnotte(cagnotte));
            Fantome new_fantome = new Fantome(matricule, nom, prenom, sexe, fonction, affectation, cagnotte);
            this.toutLePersonnel.Add(new_fantome);
            this.CheckAttraction(new_fantome);
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
            int affectation;
            do
            {
                Console.WriteLine("Veuillez saisir un numero d'affectation à une attraction.");
                affectation = int.Parse(Console.ReadLine());

            } while (!this.Check_Affectation(affectation));
            int cagnotte;
            do
            {
                Console.WriteLine("Veuillez saisir la cagnotte du monstre.");
                cagnotte = int.Parse(Console.ReadLine());
            } while (!this.Check_Cagnotte(cagnotte));
            Console.WriteLine("Veuillez saisir une force pour le demon.");
            int force = int.Parse(Console.ReadLine());
            Demon new_demon = new Demon(matricule, nom, prenom, sexe, fonction, affectation, cagnotte, force);
            this.toutLePersonnel.Add(new_demon);
            this.CheckAttraction(new_demon);
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
            Console.WriteLine("Maintenance ?\nTappez 1. Oui\nTappez 2. Non.");
            int numerobis = int.Parse(Console.ReadLine());
            bool maintenance = false;
            do
            {
                switch (numerobis)
                {
                    case 1:
                        maintenance = true;
                        break;
                    case 2:
                        maintenance = false;
                        break;
                    default:
                        break;
                }
            } while (numerobis != 1 && numerobis != 2);
            Console.WriteLine("Veuillez saisir un type de Boutique parmi les trois cas suivants :\nSouvenir.\nBarbeAPapa.\nNourriture.");
            string typeBoutique_string = Console.ReadLine();
            TypeBoutique typeBoutique = CastToTypeBoutique(typeBoutique_string);
            if (maintenance)
            {
                Console.WriteLine("Veuillez saisir la durée de la maintenance.\nD'abord,combien d'heures ?");
                int heures = int.Parse(Console.ReadLine());
                Console.WriteLine("Minutes ?");
                int minutes = int.Parse(Console.ReadLine());
                Console.WriteLine("Nature de la maintenance ?");
                string natureM = Console.ReadLine();
                this.attractions.Add(new Boutique(besoinSpecifique, new TimeSpan(heures, minutes, 0),new List<Monstre>(),id,maintenance,natureM,nombreMinimumMonstre,nom,false,typeBesoin,typeBoutique));
            }
            else
            {
                this.attractions.Add(new Boutique(besoinSpecifique, id, nombreMinimumMonstre, nom, typeBesoin, typeBoutique));
            }
            this.CheckMonstre(id);
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
            Console.WriteLine("Maintenance ?\nTappez 1. Oui\nTappez 2. Non.");
            int numerobis = int.Parse(Console.ReadLine());
            bool maintenance = false;
            do
            {
                switch (numerobis)
                {
                    case 1:
                        maintenance = true;
                        break;
                    case 2:
                        maintenance = false;
                        break;
                    default:
                        break;
                }
            } while (numerobis != 1 && numerobis != 2);
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
            if (maintenance)
            {
                Console.WriteLine("Veuillez saisir la durée de la maintenance.\nD'abord,combien d'heures ?");
                int heures = int.Parse(Console.ReadLine());
                Console.WriteLine("Minutes ?");
                int minutes = int.Parse(Console.ReadLine());
                Console.WriteLine("Nature de la maintenance ?");
                string natureM = Console.ReadLine();
                this.attractions.Add(new Darkride(besoinSpecifique, new TimeSpan(heures, minutes, 0), new List<Monstre>(), id, maintenance, natureM, nombreMinimumMonstre, nom, false, typeBesoin, duree,vehicule));
            }
            else
            {
                this.attractions.Add(new Darkride(besoinSpecifique, id, nombreMinimumMonstre, nom, typeBesoin, duree, vehicule));
            }
            this.CheckMonstre(id);
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
            Console.WriteLine("Maintenance ?\nTappez 1. Oui\nTappez 2. Non.");
            int numerobis = int.Parse(Console.ReadLine());
            bool maintenance = false;
            do
            {
                switch (numerobis)
                {
                    case 1:
                        maintenance = true;
                        break;
                    case 2:
                        maintenance = false;
                        break;
                    default:
                        break;
                }
            } while (numerobis != 1 && numerobis != 2);
            Console.WriteLine("Veuillez saisir un age minimum.");
            int ageMini = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir un type de Categorie de votre Attraction parmi les trois cas suivants :\nAssise.\nInversee.\nBobsleigh.");
            string categorie_string = Console.ReadLine();
            TypeCategorie categorie = CastToCategorie(categorie_string);
            Console.WriteLine("Veuillez saisir une taille minimum.");
            float tailleMinimum = (float)Convert.ToDouble(Console.ReadLine());
            if (maintenance)
            {
                Console.WriteLine("Veuillez saisir la durée de la maintenance.\nD'abord,combien d'heures ?");
                int heures = int.Parse(Console.ReadLine());
                Console.WriteLine("Minutes ?");
                int minutes = int.Parse(Console.ReadLine());
                Console.WriteLine("Nature de la maintenance ?");
                string natureM = Console.ReadLine();
                this.attractions.Add(new RollerCoaster(besoinSpecifique, new TimeSpan(heures, minutes, 0), new List<Monstre>(), id, maintenance, natureM, nombreMinimumMonstre, nom, false, typeBesoin,ageMini,categorie,tailleMinimum));
            }
            else
            {
                this.attractions.Add(new RollerCoaster(besoinSpecifique, id, nombreMinimumMonstre, nom, typeBesoin, ageMini, categorie, tailleMinimum));
            }
            this.CheckMonstre(id);
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
            Console.WriteLine("Maintenance ?\nTappez 1. Oui\nTappez 2. Non.");
            int numerobis = int.Parse(Console.ReadLine());
            bool maintenance = false;
            do
            {
                switch (numerobis)
                {
                    case 1:
                        maintenance = true;
                        break;
                    case 2:
                        maintenance = false;
                        break;
                    default:
                        break;
                }
            } while (numerobis != 1 && numerobis != 2);
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
            if (maintenance)
            {
                Console.WriteLine("Veuillez saisir la durée de la maintenance.\nD'abord,combien d'heures ?");
                int heures = int.Parse(Console.ReadLine());
                Console.WriteLine("Minutes ?");
                int minutes = int.Parse(Console.ReadLine());
                Console.WriteLine("Nature de la maintenance ?");
                string natureM = Console.ReadLine();
                this.attractions.Add(new Spectacle(besoinSpecifique, new TimeSpan(heures, minutes, 0), new List<Monstre>(), id, maintenance, natureM, nombreMinimumMonstre, nom, false, typeBesoin, liste_horaires,nbPlaces,nomSalle));
            }
            else
            {
                this.attractions.Add(new Spectacle(besoinSpecifique, id, nombreMinimumMonstre, nom, typeBesoin, liste_horaires, nbPlaces, nomSalle));
            }
            this.CheckMonstre(id);
        }
        #endregion

        #region CAST

        public int CastToInt(string chaine)
        {
            if (chaine != "")
            {
                if (chaine == "neant")
                {
                    return -1;
                }
                else if (chaine == "parc")
                {
                    return 1000;                      //Affectation à 1000 correspond à un monstre circulant dans le parc
                }
                else return int.Parse(chaine);
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
        public void CheckMonstre(int idAttraction)
        {
            for (int i = 0; i < this.toutLePersonnel.Count(); i++)
            {
                if (this.toutLePersonnel[i] is Monstre && ((Monstre)this.toutLePersonnel[i]).Affectation == idAttraction)
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
        public void CheckAttraction(Monstre monstre)
        {
            for (int i = 0; i < this.attractions.Count(); i++)
            {
                if (this.attractions[i].Id == monstre.Affectation)
                {
                    this.attractions[i].Equipe.Add(monstre);
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
                        this.AttractionEnMaintenance(console);
                        Console.ReadKey();
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
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Liste du personnel par catégorie.");
                    Console.WriteLine("Tappez 1. Par Sorcier.\nTappez 2. Par Monstre.\nTappez 3. Par Demon.\nTappez 4. Par Vampire.\nTappez 5. Par Loup Garou.\n" +
                        "Tappez 6. Par Zombie.\nTappez 7. Par Fantome.");
                    numero_personnel = int.Parse(Console.ReadLine());
                    string nomFich = "C:/Users/thiba/OneDrive/Documents/Visual Studio 2017/Projects/fil_rouge_git/POOI_GRP_TUCOULOU_FEURGARD/bin/Debug/write.csv";
                    StreamWriter fichEcr = new StreamWriter(nomFich, true);
                    switch (numero_personnel)
                    {
                        case 1:
                            if (console) Console.Clear();
                            int c = 1;
                            if (console) Console.WriteLine("Liste des Sorciers :");
                            else fichEcr.WriteLine("Liste des Sorciers :");
                            for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                            {
                                if (this.toutLePersonnel[i] is Sorcier)
                                {
                                    if (console) Console.Write(c + ". ");
                                    else fichEcr.Write(c + ". ");
                                    this.AfficherParPersonnel((Sorcier)this.toutLePersonnel[i], console, fichEcr);
                                    c++;
                                }
                            }
                            fichEcr.Close();
                            if (!console) Console.WriteLine("Ecriture dans CSV effectuée.");
                            Console.ReadKey();
                            break;
                        case 2:
                            if (console) Console.Clear();
                            int b = 1;
                            if (console) Console.WriteLine("Liste des Monstres :");
                            else fichEcr.WriteLine("Liste des Monstres :");
                            for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                            {
                                if (this.toutLePersonnel[i] is Monstre && !(this.toutLePersonnel[i] is Demon)
                                    && !(this.toutLePersonnel[i] is Zombie) && !(this.toutLePersonnel[i] is Vampire)
                                    && !(this.toutLePersonnel[i] is Fantome) && !(this.toutLePersonnel[i] is LoupGarou))
                                {
                                    if (console) Console.Write(b + ". ");
                                    else fichEcr.Write(b + ". ");
                                    this.AfficherParPersonnel((Monstre)this.toutLePersonnel[i], console, fichEcr);
                                    b++;
                                }
                            }
                            fichEcr.Close();
                            if (!console) Console.WriteLine("Ecriture dans CSV effectuée.");
                            Console.ReadKey();
                            break;
                        case 3:
                            if(console) Console.Clear();
                            if (console) Console.WriteLine("Liste des Demons :");
                            else fichEcr.WriteLine("Liste des Demons :");
                            int a = 1;
                            for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                            {
                                if (this.toutLePersonnel[i] is Demon)
                                {
                                    if (console) Console.Write(a + ". ");
                                    else fichEcr.Write(a + ". ");
                                    this.AfficherParPersonnel((Demon)this.toutLePersonnel[i], console, fichEcr);
                                    a++;
                                }
                            }
                            fichEcr.Close();
                            if (!console) Console.WriteLine("Ecriture dans CSV effectuée.");
                            Console.ReadKey();
                            break;
                        case 4:
                            if (console) Console.Clear();
                            int x = 1;
                            if (console) Console.WriteLine("Liste des Vampires :");
                            else fichEcr.WriteLine("Liste des Vampires :");
                            for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                            {
                                if (this.toutLePersonnel[i] is Vampire)
                                {
                                    if (console) Console.Write(x + ". ");
                                    else fichEcr.Write(x + ". ");
                                    this.AfficherParPersonnel((Vampire)this.toutLePersonnel[i], console, fichEcr);
                                    x++;
                                }
                            }
                            fichEcr.Close();
                            if (!console) Console.WriteLine("Ecriture dans CSV effectuée.");
                            Console.ReadKey();
                            break;
                        case 5:
                            if (console) Console.Clear();
                            if (console) Console.WriteLine("Liste des Loup-Garous :");
                            else fichEcr.WriteLine("Liste des Loup-Garous :");
                            int l = 1;
                            for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                            {
                                if (this.toutLePersonnel[i] is LoupGarou)
                                {
                                    if (console) Console.Write(l + ". ");
                                    else fichEcr.Write(l + ". ");
                                    this.AfficherParPersonnel((LoupGarou)this.toutLePersonnel[i], console, fichEcr);
                                    l++;
                                }
                            }
                            fichEcr.Close();
                            if (!console) Console.WriteLine("Ecriture dans CSV effectuée.");
                            Console.ReadKey();
                            break;
                        case 6:
                            if (console) Console.Clear();
                            int j = 1;
                            if (console) Console.WriteLine("Liste des Zombies :");
                            else fichEcr.WriteLine("Liste des Zombies :");
                            for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                            {
                                if (this.toutLePersonnel[i] is Zombie)
                                {
                                    if (console) Console.Write(j + ". ");
                                    else fichEcr.Write(j + ". ");
                                    this.AfficherParPersonnel((Zombie)this.toutLePersonnel[i], console, fichEcr);
                                    j++;
                                }
                            }
                            fichEcr.Close();
                            if (!console) Console.WriteLine("Ecriture dans CSV effectuée.");
                            Console.ReadKey();
                            break;
                        case 7:
                            if (console) Console.Clear();
                            if (console) Console.WriteLine("Liste des Fantomes :");
                            else fichEcr.WriteLine("Liste des Fantomes :");
                            int k = 1;
                            for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                            {
                                if (this.toutLePersonnel[i] is Fantome)
                                {
                                    if (console) Console.Write(k + ". ");
                                    else fichEcr.Write(k + ". ");
                                    this.AfficherParPersonnel((Fantome)this.toutLePersonnel[i], console, fichEcr);
                                    k++;
                                }
                            }
                            fichEcr.Close();
                            if (!console) Console.WriteLine("Ecriture dans CSV effectuée.");
                            Console.ReadKey();
                            break;
                        default:
                            Program.MessageErreur();
                            fichEcr.Close();
                            break;
                    }
                } while (numero_personnel != 1 && numero_personnel != 2 && numero_personnel != 3 && numero_personnel != 4
            && numero_personnel != 5 && numero_personnel != 6 && numero_personnel != 7);
            }
            catch
            {
                Console.WriteLine("Vous n'avez pas saisi un nombre entier.");
                Console.ReadKey();
            }
        }
        public void AfficherParPersonnel(Personnel personnel, bool console, StreamWriter fichEcr)
        {
             if (personnel is Sorcier && console) Console.WriteLine(personnel.ToString());
             else if (personnel is Sorcier && !console) fichEcr.WriteLine(personnel.ToString());
             else if (personnel is Demon && console) Console.WriteLine(personnel.ToString());
             else if (personnel is Demon && !console) fichEcr.WriteLine(personnel.ToString());
             else if (personnel is Vampire && console) Console.WriteLine(personnel.ToString());
             else if (personnel is Vampire && !console) fichEcr.WriteLine(personnel.ToString());
             else if (personnel is LoupGarou && console) Console.WriteLine(personnel.ToString());
             else if (personnel is LoupGarou && !console) fichEcr.WriteLine(personnel.ToString());
             else if (personnel is Fantome && console) Console.WriteLine(personnel.ToString());
             else if (personnel is Fantome && !console) fichEcr.WriteLine(personnel.ToString());
             else if (personnel is Zombie && console) Console.WriteLine(personnel.ToString());
             else if (personnel is Zombie && !console) fichEcr.WriteLine(personnel.ToString());
             else if(personnel is Monstre && console) Console.WriteLine(personnel.ToString());
             else fichEcr.WriteLine(personnel.ToString());
        }
        public int ReturnIndexList(int matricule, bool PersonnelOuAttraction)
        {
            if (PersonnelOuAttraction)
            {
                for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                {
                    if (this.toutLePersonnel[i] is Monstre && this.toutLePersonnel[i].Matricule == matricule)
                    {
                        return i;
                    }
                }
                return 100;
            }
            else
            {
                for (int i = 0; i < this.attractions.Count(); i++)
                {
                    if ( this.attractions[i].Id == matricule)
                    {
                        return i;
                    }
                }
                return 100;
            }
        }
        public void Cagnotte()
        {
            Console.WriteLine("Veuillez saisir le matricule du monstre auquel vous voulez augmenter ou décrementer la cagnotte");
            int matricule = int.Parse(Console.ReadLine());
            int index_monstre = this.ReturnIndexList(matricule, true);
            if (index_monstre == 100) Console.WriteLine("Matricule non existant.");
            else
            {
                Console.WriteLine("De combien voulez-vous augmenter ou décrementer ? (décrementer -- nombre negatif).");
                int nombreCagnotte = int.Parse(Console.ReadLine());
                for (int i = 0; i < this.ToutLePersonnel.Count(); i++)
                {
                    if (this.ToutLePersonnel[i] is Monstre)
                    {
                        ((Monstre)this.ToutLePersonnel[i]).ModifierCagnotte(((Monstre)this.ToutLePersonnel[index_monstre]), nombreCagnotte);
                    }
                }
                Console.WriteLine("Modification de cagnotte effectuée");
            }

            Console.ReadKey();
        }
        public void Tri_Demon()
        {
            List<Demon> liste_demon = new List<Demon>();
            for (int i = 0; i < this.ToutLePersonnel.Count(); i++)
            {
                if (this.ToutLePersonnel[i] is Demon) liste_demon.Add((Demon)this.ToutLePersonnel[i]);
            }
            liste_demon.Sort();
            foreach (Demon d in liste_demon)
            {
                Console.WriteLine(d.ToString());
            }
        }
        public void Tri_Cagnottes()
        {
            List<Monstre> liste_monstre = new List<Monstre>();
            for (int i = 0; i < this.ToutLePersonnel.Count(); i++)
            {
                if (this.ToutLePersonnel[i] is Monstre) liste_monstre.Add((Monstre)this.ToutLePersonnel[i]);
            }
            liste_monstre.Sort();
            foreach (Monstre a in liste_monstre)
            {
                Console.WriteLine(a.ToString());
            }
        }
        public void Tri()
        {
            Console.WriteLine("Trier par quel critère ?");
            Console.WriteLine("Tappez 1. Par cagnotte\nTappez 2. Par force\nTappez 3. Par cruaute\nTappez 4. Par luminosite");
            int numero = int.Parse(Console.ReadLine());
            do
            {
                switch (numero)
                {
                    case 1:
                        Console.WriteLine("Trions les cagnottes des monstres par ordre croissant");
                        this.Tri_Cagnottes();
                        break;
                    case 2:
                        Console.WriteLine("Trions les forces des Demons par ordre croissant");
                        this.Tri_Demon();
                        break;
                    case 3:
                        Console.WriteLine("Trions les indices de cruauté des Loup-Garous");
                        List<LoupGarou> liste_loup_garou = new List<LoupGarou>();
                        for (int i = 0; i < this.ToutLePersonnel.Count(); i++)
                        {
                            if (this.ToutLePersonnel[i] is LoupGarou) liste_loup_garou.Add((LoupGarou)this.ToutLePersonnel[i]);
                        }
                        liste_loup_garou.Sort();
                        foreach (LoupGarou lp in liste_loup_garou)
                        {
                            Console.WriteLine(lp.ToString());
                        }
                        break;
                    case 4:
                        Console.WriteLine("Trions les indices de luminosité des Vampires");
                        List<Vampire> liste_vampire = new List<Vampire>();
                        for (int i = 0; i < this.ToutLePersonnel.Count(); i++)
                        {
                            if (this.ToutLePersonnel[i] is Vampire) liste_vampire.Add((Vampire)this.ToutLePersonnel[i]);
                        }
                        liste_vampire.Sort();
                        foreach (Vampire v in liste_vampire)
                        {
                            Console.WriteLine(v.ToString());
                        }
                        break;
                    default:
                        break;
                }
            } while (numero != 1 && numero != 2 && numero != 3 && numero != 4);
        }
        public void Change()
        {
            try
            {

                int reponse;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Vous avez décidé de faire évoluer un membre du personnel ou une attraction:");
                    Console.WriteLine("Tapez 1. Si vous souhaitez changer la fonction d'un membre du personnel.");
                    Console.WriteLine("Tapez 2. Si vous souhaitez changer l'affection d'un monstre.");
                    Console.WriteLine("Tapez 3. Si vous souhaitez changer la maintenance d'une attraction.");
                    reponse = int.Parse(Console.ReadLine());
                    switch (reponse)
                    {
                        case 1:
                            Console.WriteLine("Vous avez décidé de modifier la fonction d'un membre du personnel");
                            Console.WriteLine("Veuillez entrer le matricule du personnel dont vous voulez modifer la fonction");
                            int mat = int.Parse(Console.ReadLine());
                            int index_monstre = this.ReturnIndexList(mat, true);
                            if (index_monstre == 100) Console.WriteLine("Le matricule n'est pas valide");
                            else
                            {
                                Console.WriteLine("Quelle fonction voulez vous affecter?");
                                string rep = Console.ReadLine();
                                for (int i = 0; i < this.toutLePersonnel.Count(); i++)
                                {
                                    if (this.toutLePersonnel[i].Matricule == mat)
                                    {
                                        this.ChangeFonction(this.toutLePersonnel[i], rep);
                                        Console.WriteLine("Changement fait");
                                    }
                                }
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Vous avez décidé de modifier l'affectation d'un monstre");
                            Console.WriteLine("Veuillez entrer le matricule du personnel dont vous voulez modifer l'affectation");
                            int mat2 = int.Parse(Console.ReadLine());
                            int index_monstre1 = this.ReturnIndexList(mat2, true);
                            if (index_monstre1 == 100) Console.WriteLine("Le matricule n'est pas valide");
                            else
                            {
                                Console.WriteLine("Quelle affection voulez vous assigner?");
                                int rep2 = int.Parse(Console.ReadLine());
                                bool valide = false;
                                for (int i = 0; i < this.attractions.Count(); i++)
                                {
                                    if (rep2 == this.attractions[i].Id) valide = true;
                                }
                                if (valide)
                                {
                                    this.ChangeAffectation((Monstre)this.toutLePersonnel[index_monstre1], rep2);
                                    Console.WriteLine("Changement effectué");
                                }
                                else Console.WriteLine("Affectation non valide");
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Vous avez décidé de modifier la maintenance d'une attraction");
                            Console.WriteLine("Veuillez entrer l'identifiant de l'attraction dont vous voulez modifer la maintenance");
                            int ID = int.Parse(Console.ReadLine());
                            int index_attraction = this.ReturnIndexList(ID, false);
                            if (index_attraction == 100) Console.WriteLine("ID non valide");
                            else
                            {
                                Console.WriteLine("Quelle est la nature de la maintenance?");
                                string maintenance = Console.ReadLine();
                                for (int i = 0; i < this.attractions.Count(); i++)
                                {
                                    if (this.attractions[i].Id == ID)
                                    {
                                        this.ChangeOuverture2(this.attractions[i], maintenance);
                                        Console.WriteLine("changement effectué");
                                    }
                                }
                            }
                            break;
                        default:

                            break;
                    }
                } while (reponse != 1 && reponse != 2 && reponse != 3);
            }
            catch
            {
                Console.WriteLine("Vous n'avez pas entré un nombre entier.");
            }
        }
        public bool Check_Affectation(int affectation)
        {
            if (affectation == -1 || affectation == 1000) return true;
            else
            {
                for (int i = 0; i < this.attractions.Count(); i++)
                {
                    if (this.attractions[i].Id == affectation)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public bool Check_Cagnotte(int cagnotte)
        {
            if (cagnotte >= 50 && cagnotte <= 500) return true;
            else return false;
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
