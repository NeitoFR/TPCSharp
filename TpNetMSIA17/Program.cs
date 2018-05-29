using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpNetMSIA17
{
    class Program
    {
        static void Main(string[] args)
        {
            Entrepot ent = new Entrepot();

            Caisse caisse = new Caisse(1000);
            ConsoleKeyInfo reponse;
            do
            {
                reponse = displayMenu();

                switch (reponse.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Solde " + caisse.Solde);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine(ent.AllArticles());
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        int nbArticle;
                        do
                        {
                            Console.WriteLine("\nEntrer un nombre d'article : ");
                            Int32.TryParse(Console.ReadLine(), out nbArticle);
                        } while (nbArticle < 1 || nbArticle > 30);
                        ent.InsertArticleAuto(nbArticle);
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Commande commande = new Commande();
                        ent.AllArticles();
                        do
                        {
                            float achat = commande.Acheter(ent.ListeArticle);

                            caisse.EnleverArgent(achat);
                            Console.WriteLine("Etat de la caisse : " + caisse.Solde);

                            do
                            {
                                Console.Write("\nVoulez-vous passer une nouvelle commande ? O/N : ");
                                reponse = Console.ReadKey();
                            } while ((reponse.Key != ConsoleKey.N) && (reponse.Key != ConsoleKey.O));

                            Console.WriteLine("\n\nListe des articles de l'entrepot : ");
                            Console.WriteLine(ent.AllArticles());

                        } while (reponse.Key != ConsoleKey.N);
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        //vente
                        break;
                    default:
                        Console.WriteLine("Choix invalide");
                        break;
                }
            } while (reponse.Key != ConsoleKey.F1);
        }
        static private ConsoleKeyInfo displayMenu()
        {
            ConsoleKeyInfo key;
            Console.WriteLine("***** Bienvenue sur l\'entrepôt *****");
            Console.WriteLine("\t1.Consulter solde caisse");
            Console.WriteLine("\t2.Consulter liste article");
            Console.WriteLine("\t3.Ajouter des articles");
            Console.WriteLine("\t4.Acheter des articles");
            Console.WriteLine("\t5.Vendre des articles");
            Console.Write("Choix : ");
            key = Console.ReadKey();
            Console.Write("\n");
            return key;
        }
    }
}
