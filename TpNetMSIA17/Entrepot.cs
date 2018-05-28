using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpNetMSIA17
{
    public class Entrepot
    {
        private List<Article> listeArticle;

        public Entrepot()
        {
            listeArticle = new List<Article>();
        }

        public List<Article> ListeArticle
        {
            get
            {
                return listeArticle;
            }
            set
            {
                listeArticle = value;
            }
        }

        public string AllArticles()
        {
            string liste = "";
            int index = 1;

            foreach(Article article in listeArticle)
            {
                liste += index + " : " + article.affiche() + "\n";
                index ++; 
            }

            return liste;
        }

        public void InsertArticle(int nbArticle)
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

                Article article = new Article(nom, prix, quantite, margeBeneficiaire);
                listeArticle.Add(article);
                Console.WriteLine("Ajout de l'article " + article.Nom + "\n");
            }

            Console.WriteLine(AllArticles());
        }

        public void InsertArticleAuto(int nbArticle)
        {
            for (int nb = 1; nb <= nbArticle; nb++)
            {
                Article article = new Article("Article " + nb, 12F, 5, 5F);
                listeArticle.Add(article);
            }

            Console.WriteLine(AllArticles());
        }

        public void supprimerArticle(Article article)
        {
            listeArticle.Remove(article);
            Console.WriteLine("Suppression de l'article" + article.Nom);
        }
    }
}