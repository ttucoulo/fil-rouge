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
            Menu(adm);
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
                        adm.AjoutMembresFromCSV("C:/temp/Listing.csv");
                        break;
                    case 2:
                        adm.AjouterMembres();
                        break;
                    case 3:

                        break;
                    case 4:
                        adm.SortieSelonCritere();
                        break;
                    case 5:

                        break;
                    case 6:
                        //Pour effectuer des tests et verifier que tout est bon!
                        Console.WriteLine(adm.Attractions[adm.Attractions.Count() - 1].Equipe.Count());
                        Console.ReadKey();
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
    }
}
