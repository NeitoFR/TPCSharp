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

        public Article ajouteArticle(Article article)
        {
            listeArticle.Add(article);
            Console.WriteLine("Ajout de l'article " + article.Nom);

            return article;
        }

        public void supprimerArticle(Article article)
        {
            listeArticle.Remove(article);
            Console.WriteLine("Suppression de l'article" + article.Nom);
        }
    }
}