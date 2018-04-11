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
            Console.WriteLine("Bienvenue dans le logiciel de gestion administrative du parc Zombillenium");
            Console.WriteLine("Vous allez avoir le choix entre differentes actions.\nVeuillez saisir une action :\n");
            Console.WriteLine("Tappez 1. Si vous voulez ajouter au logiciel des membres du personnel et des attractions via un fichier csv");
            Console.WriteLine("Tappez 2. Si vous voulez ajouter de nouvelles attractions, de nouveaux membres du personnel");
            Console.WriteLine("Tappez 3. Si vous voulez « faire évoluer » les membres du personnel et les attractions");
            Console.WriteLine("Tappez 4. Si vous voulez sortir plusieurs éléments suivant des critères donnés en sortie console ou dans un fichier csv");
            Console.WriteLine("Tappez 5. Si vous voulez trier des éléments en fonctions d’un paramètre donné");
            Console.WriteLine("Tappez 6. Si vous voulez agir sur la cagnotte des monstres");
            Console.WriteLine("Tappez 0. Pour quitter le menu");
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
                            adm.Demo();
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
        #endregion
    }
}
