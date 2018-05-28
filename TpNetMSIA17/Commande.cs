using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpNetMSIA17
{
    public class Commande
    {
        private static List<Article> listeArticleAchete;

        public Commande()
        {
            listeArticleAchete = new List<Article>();
        }
        
        public static string AllArticleAchete()
        {
            string liste = "";
            int index = 1;

            foreach (Article articleAchete in listeArticleAchete)
            {
                liste += index + " : " + articleAchete.affiche() + "\n";
                index++;
            }

            return liste;
        }

        public float Acheter(List<Article> listeArticle)
        {
            int numArticle;
            int quantite;

            do
            {
                Console.Write("\nNuméro de l'article à acheter : ");
                Int32.TryParse(Console.ReadLine(), out numArticle);
            } while (numArticle < 1 || numArticle > listeArticle.Count);

            Article article = listeArticle[numArticle - 1];

            do {
                Console.Write("Nombre de quantité désirée : ");
                Int32.TryParse(Console.ReadLine(), out quantite);
            } while (quantite < 1 || quantite > article.Quantite);

            float achat = article.Prix * quantite;

            listeArticleAchete.Add(article);

            article.Quantite -= quantite;

            /*Console.WriteLine();
            Console.WriteLine("Début test : ");
            Console.WriteLine("Article : " + article.affiche());
            Console.WriteLine("Achat = " + achat);
            Console.WriteLine("AllArticleAchete() : " + AllArticleAchete());
            Console.WriteLine("article.Quantite : " + article.Quantite);*/
            
            return achat;
        }

        public float Vendre()
        {
            throw new System.NotImplementedException();
        }
    }
}