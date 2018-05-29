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


        public List<Article> ListeArticleAchete
        {
            get
            {
                return listeArticleAchete;
            }
            set
            {
                listeArticleAchete = value;
            }
        }

        public string AllArticleAchete()
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

            if (quantite == article.Quantite)
            {
                listeArticle.Remove(article);
            }

            float achat = article.Prix * quantite;

            listeArticleAchete.Add(new Article(article.Nom, article.Prix, quantite, article.MargeBeneficiaire));

            article.Quantite -= quantite;
            
            return achat;
        }

        public float Vendre(List<Article> listeArticleAchete)
        {
            int numArticle;
            int quantite;

            do
            {
                Console.Write("\nNuméro de l'article à acheter : ");
                Int32.TryParse(Console.ReadLine(), out numArticle);

            } while (numArticle < 1 || numArticle > listeArticleAchete.Count);

            Article articleAchete = listeArticleAchete[numArticle - 1];

            do
            {
                Console.Write("Nombre de quantité désirée : ");
                Int32.TryParse(Console.ReadLine(), out quantite);
            } while (quantite < 1 || quantite > articleAchete.Quantite);

            if (quantite == articleAchete.Quantite)
            {
                listeArticleAchete.Remove(articleAchete);
            }

            float achat = articleAchete.Prix * quantite;

            listeArticleAchete.Add(new Article(articleAchete.Nom, articleAchete.Prix, quantite, articleAchete.MargeBeneficiaire));

            articleAchete.Quantite -= quantite;

            return achat;
        }
    }
}