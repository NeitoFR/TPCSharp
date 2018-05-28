using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpNetMSIA17
{
    class Program
    {
        private static Entrepot entrepot = new Entrepot();

        static void Main(string[] args)
        {
            ConsoleKeyInfo reponse;
            int nbArticle;
            Caisse caisse = new Caisse(1000F);
            Console.WriteLine("Etat de la caisse : " + caisse.Solde);
           
            do
            {
                Console.WriteLine("\nEntrer un nombre d'article : ");
                Int32.TryParse(Console.ReadLine(), out nbArticle);
            } while (nbArticle < 1 || nbArticle > 30);

            InsertArticleAuto(nbArticle);

            Commande commande = new Commande();

            do
            {
                float achat = commande.Acheter(entrepot.ListeArticle);

                caisse.EnleverArgent(achat);
                Console.WriteLine("Etat de la caisse : " + caisse.Solde);

                do
                {
                    Console.Write("\nVoulez-vous passer une nouvelle commande ? O/N : ");
                    reponse = Console.ReadKey();
                }while ((reponse.Key != ConsoleKey.N) && (reponse.Key != ConsoleKey.O));


            } while (reponse.Key != ConsoleKey.N);


            Console.ReadKey();
        }

        private static void  InsertArticle(int nbArticle)
        {
            string nom;
            float prix;
            int quantite;
            float margeBeneficiaire;

            for (int nb = 1; nb <= nbArticle; nb++)
            {
                Console.WriteLine("Article " + nb + " : ");
                Console.Write("Nom : ");
                nom = Console.ReadLine();
                do
                {
                    Console.Write("Prix : ");
                    float.TryParse(Console.ReadLine(), out prix);
                } while (prix < 1 || prix > 100);

                do
                {
                    Console.Write("Quantité : ");
                    Int32.TryParse(Console.ReadLine(), out quantite);
                } while (quantite < 1 || quantite > 10);
                

                do
                {
                    Console.Write("Marge bénéficiaire : ");
                    float.TryParse(Console.ReadLine(), out margeBeneficiaire);
                    Console.WriteLine();
                } while (margeBeneficiaire < 1 || margeBeneficiaire > 10);

                entrepot.ajouteArticle(new Article(nom, prix, quantite, margeBeneficiaire));
            }

            Console.WriteLine(entrepot.AllArticles());
        }

        private static void InsertArticleAuto(int nbArticle)
        {
            for (int nb = 1; nb <= nbArticle; nb++)
            {
                entrepot.ajouteArticle(new Article("Article " + nb, 12F, 5, 5F));
            }

            Console.WriteLine(entrepot.AllArticles());
        }
    }
}
