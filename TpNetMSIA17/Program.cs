﻿using System;
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

            //entrepot.InsertArticle(nbArticle);

            entrepot.InsertArticleAuto(nbArticle);

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

                Console.WriteLine("\n\nListe des articles de l'entrepot : ");
                Console.WriteLine(entrepot.AllArticles());

            } while (reponse.Key != ConsoleKey.N);


            Console.ReadKey();
        }
    }
}
