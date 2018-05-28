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
            Caisse caisse = new Caisse(1000F);
            Console.WriteLine(caisse.Solde);
            
            int nbArticle;

            do
            {
                Console.WriteLine("Entrer un nombre d'article : ");
                Int32.TryParse(Console.ReadLine(), out nbArticle);
            } while (nbArticle < 1 || nbArticle > 30);

            InsertArticle(nbArticle);

            Commande commande = new Commande();

            float achat = commande.Acheter(entrepot.ListeArticle);

            caisse.EnleverArgent(achat);
            Console.WriteLine(caisse.Solde);
            /*caisse.AjouterArgent(100F);
            Console.WriteLine(caisse.Solde);*/
            
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
                } while (margeBeneficiaire < 1 || margeBeneficiaire > 10);

                entrepot.ajouteArticle(new Article(nom, prix, quantite, margeBeneficiaire));
            }

            Console.WriteLine(entrepot.AllArticles());
        }
    }
}
