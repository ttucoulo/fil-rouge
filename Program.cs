using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilRouge
{
    enum TypeBoutique { souvenir, barbeAPapa, nourriture};
    enum Grade { novice, mega, giga, strata};
    enum TypeCategorie {assise, inversee, bobsleigh };
    enum TypeSexe { male, femelle, autre};
    enum CouleurZ { bleuatre, grisatre};

    class Program
    {
        static void Main(string[] args)
        {
            Administration adm = new Administration();
            MenuPrincipal(adm);
        }

        #region Méthodes statiques 
        public static void AffichageActions()
        {
            Console.WriteLine("Bienvenue dans le logiciel de gestion administrative du parc Zombillenium.");
            Console.WriteLine("Vous allez avoir le choix entre differentes actions.\nVeuillez saisir une action :\n");
            Console.WriteLine("Tappez 1. Si vous voulez lire un fichier csv contenant des membres du personnel et des attractions, et de les ajouter dans le logiciel.");
            Console.WriteLine("Tappez 2. Si vous voulez ajouter de nouvelles attractions, de nouveaux membres du personnel.");
            Console.WriteLine("Tappez 3. Si vous voulez « faire évoluer » les membres du personnel et les attractions.");
            Console.WriteLine("Tappez 4. Si vous voulez sortir plusieurs éléments suivant des critères donnés en sortie console, mais aussi dans un fichier csv.");
            Console.WriteLine("Tappez 5. Si vous voulez trier des éléments en fonctions d’un paramètre donné.");
            Console.WriteLine("Tappez 6. Si vous voulez agir sur la cagnotte des monstres.");
            Console.WriteLine("Tappez 0. Pour quitter le menu.");
        }
        public static void MenuPrincipal(Administration adm)
        {
            int numero;
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Tappez 1. Demo sans interaction?\nTappez 2. Menu avec interactions?");
                    numero = int.Parse(Console.ReadLine());
                    switch (numero)
                    {
                        case 1:
                            Demo(adm);
                            break;
                        case 2:
                            Menu(adm);
                            break;
                        default:
                            break;
                    }
                } while (numero != 1 && numero != 2);
            }
            catch
            {
                Console.WriteLine("Saisissez un entier!");
                Console.ReadKey();
            }
        }
        public static void Menu(Administration adm)
        {
            int numero;
            try
            {
                do
                {
                    Console.Clear();
                    AffichageActions();
                    numero = int.Parse(Console.ReadLine());
                    switch (numero)
                    {
                        case 1:
                            Console.WriteLine("Nous allons remplir la base de donnée à l'aide du fichier Listing.");
                            adm.AjoutMembresFromCSV("C:/temp/Listing.csv");
                            Console.WriteLine("Ajout fait");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("Vous avez décidé d'ajouter un nouveau membre ou une nouvelle attraction:");
                            adm.AjouterMembres();
                            Console.WriteLine("L'ajout a bien été effectué.");
                            Console.ReadKey();
                            break;
                        case 3:
                            adm.Change();
                            Console.ReadKey();
                            break;
                        case 4:
                            adm.SortieSelonCritere();
                            break;
                        case 5:
                            adm.Tri();
                            Console.ReadKey();
                            break;
                        case 6:
                            adm.Cagnotte();
                            break;
                        case 0:
                            //Pour quitter le menu
                            break;
                        default:
                            MessageErreur();
                            break;
                    }
                } while (numero != 0);
            }
            catch
            {
                Console.WriteLine("Vous n'avez pas saisi un nombre entier.");
                Console.ReadKey();
            }
        }
        public static void MessageErreur()
        {
            Console.WriteLine("Veuillez saisir une action existante svp.\nVeuillez saisir une touche pour revenir au menu.");
            Console.ReadKey();
        }
        public static void Demo(Administration adm)
        {
            Console.Clear();
            Console.WriteLine("Bienvenue dans le logiciel de gestion administrative du parc Zombillenium.");
            Console.WriteLine("Vous allez assister à une demo de notre logiciel. Pour passer à l'action suivante, vous presserez une touche.");
            Console.WriteLine("Pour commencer, veuillez appuyez sur une touche.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Tout d'abord, nous allons charger les membres du personnel et les attractions du fichier csv Listing.csv");
            adm.AjoutMembresFromCSV("C:/temp/Listing.csv");
            Console.WriteLine("Ca y est, tous les membres du personnel et attractions ont été ajoutés avec succès.");

            Console.WriteLine("Affichage de la liste de Personnel :\n");
            for(int i = 0; i < adm.ToutLePersonnel.Count(); i++)
            {
                Console.WriteLine(adm.ToutLePersonnel[i].Nom+ " "+adm.ToutLePersonnel[i].Prenom+ " "+ adm.ToutLePersonnel[i].Matricule );
            }
            Console.WriteLine();
            Console.WriteLine("Affichage de la liste d'attractions :\n");
            for (int i = 0; i < adm.Attractions.Count(); i++)
            {
                Console.WriteLine(adm.Attractions[i].Nom + " " + adm.Attractions[i].Id);
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Maintenant, je vais ajouter manuellement un membre du personnel avec les critères suivants :\n" +
                "Zombie, 66001, Dupont Bernard, Male , assistant , 645 , 5000 , 1.3 ");
            Vampire new_vampire = new Vampire(66001, "Dupont", "Bernard", TypeSexe.male, "assistant", 645, 5000, (float)1.3);
            adm.ToutLePersonnel.Add(new_vampire);
            adm.CheckAttraction(new_vampire);
            Console.WriteLine("Ajout effectué.\n");
            Console.WriteLine("Verification :\nAffichons le dernier élement de la liste de personnel : \n");
            Console.WriteLine(adm.ToutLePersonnel[adm.ToutLePersonnel.Count() - 1].Nom + " " + adm.ToutLePersonnel[adm.ToutLePersonnel.Count() - 1].Prenom + " "+ adm.ToutLePersonnel[adm.ToutLePersonnel.Count() - 1].Matricule);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Je vais ajouter manuellement une attraction sans maintenance avec les critères suivants :\n" +
                "RollerCoaster, pas de besoin specifique, 118, 1 monstre minimum, Falaises dangereuses, zombie, 11 ans minimum, Assise, 1.25 m minimum");
            RollerCoaster new_rollercoaster = new RollerCoaster(false,118,9,"Falaises dangereuses","zombie",11,TypeCategorie.assise,(float)1.25);
            adm.Attractions.Add(new_rollercoaster);
            adm.CheckMonstre(new_rollercoaster.Id);
            Console.WriteLine("Ajout effectué.\n");
            Console.WriteLine("Verification :\nAffichons le dernier élement de la liste d'attractions : \n");
            Console.WriteLine(adm.Attractions[adm.Attractions.Count() - 1].Nom + " " + adm.Attractions[adm.Attractions.Count() - 1].Id);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Et puis deux autres attractions en maintenance :  \nDarkride, pas de besoin specifique, 48h de maintenance, equipe :Bernard Dupont ajouté precedemment, " +
                "429, en maintenance,reparation, 1 monstre minmum, Balade montagneuse, fermée, vampire, 15min,en vehicule.\n\n" +
                "Boutique, pas de besoin specifique, 24h de maintenance, equipe : un monstre quelconque de la liste, 625, en maintenance,reparation,1 monstre minimum, Sensations fortes, fermée, monstre,souvenir\n\n");
            List<Monstre> liste = new List<Monstre>();
            liste.Add(new_vampire);
            Darkride new_darkride = new Darkride(false, new TimeSpan(48,0,0),liste,429,true,"reparation",1,"Balade montagneuse",false,"vampire",new TimeSpan(0,15,0),true);
            adm.Attractions.Add(new_darkride);
            adm.CheckMonstre(new_darkride.Id);
            List<Monstre> liste1 = new List<Monstre>();
            liste1.Add((Monstre)adm.ToutLePersonnel[3]);
            Boutique new_boutique = new Boutique(false, new TimeSpan(24, 0, 0), liste1, 625, true, "reperation", 1, "Tout pour 1 euro", false, "monstre", TypeBoutique.souvenir);
            adm.Attractions.Add(new_boutique);
            adm.CheckMonstre(new_boutique.Id);
            Console.WriteLine("Ajouts effectués\n\n");
            Console.WriteLine("Verification : \n\nReaffichons la liste d'attractions mise à jour.\n\n");
            for (int i = 0; i < adm.Attractions.Count(); i++)
            {
                Console.WriteLine(adm.Attractions[i].Nom + " " + adm.Attractions[i].Id);
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("On va maintenant faire evoluer les membres du personnel");
            Console.WriteLine("La directrice Communication va passer Directrice recrutement\n");
            for(int i = 0; i < adm.ToutLePersonnel.Count(); i++)
            {
                if(adm.ToutLePersonnel[i].Fonction=="directrice Communication")
                {
                    adm.ChangeFonction(adm.ToutLePersonnel[i], "directrice Recrutement");
                }
            }
            Console.WriteLine("Changement de fonction effectué\n");
            Console.WriteLine("Verification : \nAffichons la fonction de Deborah Malkiewicz, matricule : 66604 (ancienne directrice communication).\n");
            Console.WriteLine(adm.ToutLePersonnel[adm.ReturnIndexList(66604,true)].Fonction);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Changeons l'affectation du demon Aurelien Zahner, matricule 66987\n");
            ((Monstre)adm.ToutLePersonnel[adm.ReturnIndexList(66987,true)]).Affectation = 645;
            Console.WriteLine("Changement d'affectation effectué\n");
            Console.WriteLine("Verification : \nAffichons l'affectation du Aurelien Zahner après modification.\n"); 
            Console.WriteLine("Nouvelle affectation : "+((Monstre)adm.ToutLePersonnel[adm.ReturnIndexList(66987,true)]).Affectation);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Maintenant, on va sortir tous les Vampires de nos membres du personnel en sortie console et en même temps dans un fichier csv qui s'appelera write.csv.\n\n");
            string nomFichier = "C:/temp/write.csv";
            StreamWriter fichEcrire = new StreamWriter(nomFichier, true);
            for (int i = 0; i < adm.ToutLePersonnel.Count(); i++)
            {
                if (adm.ToutLePersonnel[i] is Vampire)
                {
                    adm.AfficherParPersonnel(adm.ToutLePersonnel[i], true, fichEcrire);
                    adm.AfficherParPersonnel(adm.ToutLePersonnel[i], false, fichEcrire);
                }
            }
            fichEcrire.Close();
            Console.WriteLine("\n");
            Console.WriteLine("Les Vampires ont été affichés en console et sont affichés dans le fichier csv.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Nous allons trier la liste des attractions par ordre croissant d'identifiants\n");
            adm.Attractions.Sort();
            foreach(Attraction a in adm.Attractions) Console.WriteLine(a.ToString());
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Nous allons trier la liste du personnel en commançant par les monstres par ordre croissant de cagnottes\n\n");
            adm.Tri_Cagnottes();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Nous allons maintenant trier par ordre croissant les demons par force\n\n");
            adm.Tri_Demon();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Sortons toutes les attractions en maintenance.\n");
            adm.AttractionEnMaintenance(true);    //Affichage console
            adm.AttractionEnMaintenance(false);   //Affichage csv
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Changeons la boutique \"Tout pour 1 euro\" du statut maintenance à ouvert.");
            adm.ChangeOuverture();
            Console.WriteLine("Ouverture de l'attraction effectuée.\n\n");
            Console.WriteLine("Verification :\n\n");
            Console.WriteLine("Affichons les attractions en maintenance :\n\n");
            foreach(Attraction a in adm.Attractions)
            {
                if (a.Maintenance) Console.WriteLine(a.ToString());
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Enlevons 80 de cagnotte au monstre Aton Noudjemet de matricule 66634 pour la faire tomber en dessous de 50.\n");
            Console.WriteLine("Tout d'abord, affichons sa cagnotte actuelle ainsi que son affectation :\n");
            Console.WriteLine("Cagnotte actuelle : "+((Monstre)adm.ToutLePersonnel[adm.ReturnIndexList(66634,true)]).Cagnotte+"\nAffectation actuelle : "+ ((Monstre)adm.ToutLePersonnel[adm.ReturnIndexList(66634, true)]).Affectation+"\n");
            for (int i=0; i < adm.ToutLePersonnel.Count(); i++)
            {
                if(adm.ToutLePersonnel[i] is Monstre)
                {
                    ((Monstre)adm.ToutLePersonnel[i]).ModifierCagnotte(((Monstre)adm.ToutLePersonnel[adm.ReturnIndexList(66634,true)]), -80);
                }
            }
            Console.WriteLine("Modification de cagnotte effectuée !\n\n\nAffichons sa nouvelle cagnotte :\nNouvelle cagnotte : "+ ((Monstre)adm.ToutLePersonnel[adm.ReturnIndexList(66634, true)]).Cagnotte + "\n\nOn va maintenant verifier si son affectation a bien été modifiée car sa cagnotte est descendu en dessous de 50.\nJe rappelle" +
              " qu'une affectation à 1000 correspond à une circulation dans le parc et qu'une affectation à 684 correspond à un stand à barbe a papa.\n");
            Console.WriteLine("Nouvelle affectation de Aton Noudjemet : "+((Monstre)adm.ToutLePersonnel[adm.ReturnIndexList(66634,true)]).Affectation);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("FIN DE LA DEMO");
            Console.ReadKey();
        }
        #endregion
    }
}
