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
            int numero;
            do
            {
                Console.Clear();
                Console.WriteLine("Tappez 1. Demo ?\nTappez 2. Menu pour verifier chaque action individuellement.");
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
        public static void Menu(Administration adm)
        {
            int numero;
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
                        Change(adm);
                        Console.ReadKey();
                        break;
                    case 4:
                        adm.SortieSelonCritere();
                        break;
                    case 5:
                        Tri(adm);
                        Console.ReadKey();
                        break;
                    case 6:
                        Cagnotte(adm);
                        break;
                    case 0:
                        //Pour quitter le menu
                        break;
                    default:
                        MessageErreur();
                        break;
                }
            } while (numero !=0);
        }
        public static void MessageErreur()
        {
            Console.WriteLine("Veuillez saisir une action existante svp.\nVeuillez saisir une touche pour revenir au menu.");
            Console.ReadKey();
        }
        public static void Cagnotte(Administration adm)
        {
            Console.WriteLine("Veuillez saisir le matricule du monstre auquel vous voulez augmenter ou décrementer la cagnotte");
            int matricule = int.Parse(Console.ReadLine());
            int index_monstre = adm.ReturnIndexList(matricule,true);
            if (index_monstre == 100) Console.WriteLine("Matricule non existant.");
            else
            {
                Console.WriteLine("De combien voulez-vous augmenter ou décrementer ? (décrementer -- nombre negatif).");
                int nombreCagnotte = int.Parse(Console.ReadLine());
                for (int i = 0; i < adm.ToutLePersonnel.Count(); i++)
                {
                    if (adm.ToutLePersonnel[i] is Monstre)
                    {
                        ((Monstre)adm.ToutLePersonnel[i]).ModifierCagnotte(((Monstre)adm.ToutLePersonnel[index_monstre]), nombreCagnotte);
                    }
                }
                Console.WriteLine("Modification de cagnotte effectuée");
            }

            Console.ReadKey();
        }
        public static void Tri(Administration adm)
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
                        List<Monstre> liste_monstre = new List<Monstre>();
                        for (int i = 0; i < adm.ToutLePersonnel.Count(); i++)
                        {
                            if (adm.ToutLePersonnel[i] is Monstre) liste_monstre.Add((Monstre)adm.ToutLePersonnel[i]);
                        }
                        liste_monstre.Sort();
                        foreach (Monstre a in liste_monstre)
                        {
                            a.ToString();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Trions les forces des Demons par ordre croissant");
                        List<Demon> liste_demon = new List<Demon>();
                        for (int i = 0; i < adm.ToutLePersonnel.Count(); i++)
                        {
                            if (adm.ToutLePersonnel[i] is Demon) liste_demon.Add((Demon)adm.ToutLePersonnel[i]);
                        }
                        liste_demon.Sort();
                        foreach (Demon d in liste_demon)
                        {
                            d.ToString();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Trions les indices de cruauté des Loup-Garous");
                        List<LoupGarou> liste_loup_garou = new List<LoupGarou>();
                        for (int i = 0; i < adm.ToutLePersonnel.Count(); i++)
                        {
                            if (adm.ToutLePersonnel[i] is LoupGarou) liste_loup_garou.Add((LoupGarou)adm.ToutLePersonnel[i]);
                        }
                        liste_loup_garou.Sort();
                        foreach (LoupGarou lp in liste_loup_garou)
                        {
                            lp.ToString();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Trions les indices de luminosité des Vampires");
                        List<Vampire> liste_vampire = new List<Vampire>();
                        for (int i = 0; i < adm.ToutLePersonnel.Count(); i++)
                        {
                            if (adm.ToutLePersonnel[i] is Vampire) liste_vampire.Add((Vampire)adm.ToutLePersonnel[i]);
                        }
                        liste_vampire.Sort();
                        foreach (Vampire v in liste_vampire)
                        {
                            v.ToString();
                        }
                        break;
                    default:
                        break;
                }
            } while (numero !=1 && numero !=2 && numero !=3 && numero !=4);
        }
        public static void Change(Administration adm)
        {
            Console.Clear();
            Console.WriteLine("Vous avez décidé de faire évoluer un membre du personnel ou une attraction:");
            Console.WriteLine("Tapez 1. Si vous souhaitez changer la fonction d'un membre du personnel.");
            Console.WriteLine("Tapez 2. Si vous souhaitez changer l'affection d'un monstre.");
            Console.WriteLine("Tapez 3. Si vous souhaitez changer la maintenance d'une attraction.");
            int reponse = int.Parse(Console.ReadLine());
            switch (reponse)
            {
                case 1:
                    Console.WriteLine("Vous avez décidé de modifier la fonction d'un membre du personnel");
                    Console.WriteLine("Veuillez entrer le matricule du personnel dont vous voulez modifer la fonction");
                    int mat = int.Parse(Console.ReadLine());
                    int index_monstre = adm.ReturnIndexList(mat, true);
                    if (index_monstre == 100) Console.WriteLine("Le matricule n'est pas valide");
                    else
                    {
                        Console.WriteLine("Quelle fonction voulez vous affecter?");
                        string rep = Console.ReadLine();
                        for (int i = 0; i < adm.ToutLePersonnel.Count(); i++)
                        {
                            if (adm.ToutLePersonnel[i].Matricule == mat)
                            {
                                adm.ChangeFonction(adm.ToutLePersonnel[i], rep);
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
                    int index_monstre1 = adm.ReturnIndexList(mat2, true);
                    if (index_monstre1 == 100) Console.WriteLine("Le matricule n'est pas valide");
                    else
                    {
                        Console.WriteLine("Quelle affection voulez vous assigner?");
                        int rep2 = int.Parse(Console.ReadLine());
                        bool valide = false;
                        for (int i = 0; i < adm.Attractions.Count(); i++)
                        {
                            if (rep2 == adm.Attractions[i].Id) valide = true;
                        }
                        if (valide)
                        {
                            adm.ChangeAffectation((Monstre)adm.ToutLePersonnel[index_monstre1], rep2);
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
                    int index_attraction = adm.ReturnIndexList(ID, false);
                    if (index_attraction == 100) Console.WriteLine("ID non valide");
                    else
                    {
                        Console.WriteLine("Quelle est la nature de la maintenance?");
                        string maintenance = Console.ReadLine();
                        for (int i = 0; i < adm.Attractions.Count(); i++)
                        {
                            if (adm.Attractions[i].Id == ID)
                            {
                                adm.ChangeOuverture2(adm.Attractions[i], maintenance);
                                Console.WriteLine("changement effectué");
                            }
                        }
                    }
                    break;
            }
        }
        public static void Demo(Administration adm)
        {
            Console.Clear();
            Console.WriteLine("Bienvenue dans le logiciel de gestion administrative du parc Zombillenium.");
            Console.WriteLine("Vous allez assister à une demo de notre logiciel. Pour passer à l'action suivante, vous presserez une touche.");
            Console.WriteLine("Pour commencer, veuillez appuyez sur une touche.");
            Console.ReadKey();
            Console.WriteLine("Tout d'abord, nous allons charger les membres du personnel et les attractions du fichier csv Listing.csv");
            adm.AjoutMembresFromCSV("C:/temp/Listing.csv");
            Console.WriteLine("Ca y est, tous les membres du personnel et attractions ont été ajoutés avec succès.");
            Console.ReadKey();
            Console.WriteLine("Maintenant, je vais ajouter manuellement un membre du personnel avec les critères suivants :\n" +
                "Zombie, 66001, Dupont Bernard, Male , assistant , 645 , 5000 , 1.3 ");
            Vampire new_vampire = new Vampire(66001, "Dupont", "Bernard", TypeSexe.male, "assistant", 645, 5000, (float)1.3);
            adm.ToutLePersonnel.Add(new_vampire);
            adm.CheckAttraction(new_vampire);
            Console.WriteLine("Ajout effectué.");
            Console.WriteLine("Je vais ajouter manuellement une attraction sans maintenance avec les critères suivants :\n" +
                "RollerCoaster, pas de besoin specifique, 118, 1 monstre minimum, Falaises dangereuses, zombie, 11 ans minimum, Assise, 1.25 m minimum");
            RollerCoaster new_rollercoaster = new RollerCoaster(false,118,9,"Falaises dangereuses","zombie",11,TypeCategorie.assise,(float)1.25);
            adm.Attractions.Add(new_rollercoaster);
            adm.CheckMonstre(new_rollercoaster.Id);
            Console.WriteLine("Ajout effectué.");
            Console.WriteLine("Et puis deux autres attractions en maintenance. \nDarkride, pas de besoin specifique, 48h de maintenance, equipe :Bernard Dupont ajouté precedemment, " +
                "429, en maintenance,reparation, 1 monstre minmum, Balade montagneuse, fermée, vampire, 15min,en vehicule.\n" +
                "Boutique, pas de besoin specifique, 24h de maintenance, equipe : un monstre quelconque de la liste, 625, en maintenance,reparation,1 monstre minimum, Sensations fortes, fermée, monstre,souvenir");
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
            Console.ReadKey();
            Console.WriteLine("On va maintenant faire evoluer les membres du personnel");
            Console.WriteLine("La directrice Communication va passer Directrice recrutement");
            for(int i = 0; i < adm.ToutLePersonnel.Count(); i++)
            {
                if(adm.ToutLePersonnel[i].Fonction=="directrice Communication")
                {
                    adm.ChangeFonction(adm.ToutLePersonnel[i], "directrice Recrutement");
                }
            }
            Console.WriteLine("Changement de fonction effectué");
            Console.ReadKey();
            Console.WriteLine("Changeons l'affectation du demon Aurelien Zahner");
            for (int i = 0; i < adm.ToutLePersonnel.Count(); i++)
            {
                if (adm.ToutLePersonnel[i] is Monstre && adm.ToutLePersonnel[i].Nom == "Zahner" && adm.ToutLePersonnel[i].Prenom=="Aurelien" )
                {
                    adm.ChangeAffectation((Monstre)adm.ToutLePersonnel[i], 645);
                }
            }
            Console.WriteLine("Changement d'affectation effectué");
            Console.ReadKey();
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
            Console.WriteLine("Les Vampires ont été affichés en console et sont affichés dans le fichier csv.");
            Console.ReadKey();
            Console.WriteLine("Nous allons trier la liste des attractions par ordre croissant d'identifiants");
            adm.Tri_attractions();
            Console.WriteLine("Tri fait avec succès");
            Console.ReadKey();
            Console.WriteLine("Nous allons trier la liste du personnel en commançant par les monstres par ordre croissant de cagnottes");
            adm.Tri_Monstres();
            Console.WriteLine("Tri fait avec succès");
            Console.ReadKey();
            Console.WriteLine("Nous allons maintenant trier par ordre croissant les demons par force");
            adm.Tri_Demons();
            Console.WriteLine("Tri fait avec succès");
            Console.ReadKey();
            Console.WriteLine("Changeons la boutique Tout pour 1 euro du statut maintenance à ouvert.");
            adm.ChangeOuverture();
            Console.WriteLine("Ouverture de l'attraction effectuée.");
            Console.ReadKey();
            Console.WriteLine("Sortons toutes les attractions en maintenance.");
            adm.AttractionEnMaintenance(true);    //Affichage console
            adm.AttractionEnMaintenance(false);   //Affichage csv
            Console.ReadKey();
            Console.WriteLine("Enlevons 50 de cagnotte au démon Luc Cypher de matricule 66754pour le faire tomber en dessous de 50.");
            for (int i=0; i < adm.ToutLePersonnel.Count(); i++)
            {
                if(adm.ToutLePersonnel[i] is Monstre)
                {
                    ((Monstre)adm.ToutLePersonnel[i]).ModifierCagnotte(((Monstre)adm.ToutLePersonnel[adm.ReturnIndexList(66754,true)]), -50);
                }
            }
            Console.WriteLine("On va maintenant verifier si son affectation a bien été modifiée car sa cagnotte est descendu en dessous de 50. Je rappelle" +
              " qu'une affectation à 1000 correspond à une circulation dans le parc et qu'une affectation à 684 correspond à un stand à barbe a papa.");
            Console.WriteLine("Nouvelle affectation de Luc Cypher : "+((Monstre)adm.ToutLePersonnel[adm.ReturnIndexList(66754,true)]).Affectation);
            Console.ReadKey();
        }
    }
}
