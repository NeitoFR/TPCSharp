using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpNetMSIA17
{
    public class Article
    {
        private string nom;
        private float prix;
        private float margeBeneficiaire;
        private int quantite;

        public Article(string nom, float prix, int quantite, float margeBeneficiaire)
        {
            this.nom = nom;
            this.prix = prix;
            this.margeBeneficiaire = margeBeneficiaire;
            this.quantite = quantite;
            afficheCreation(nom);
        }

        public float Prix
        {
            get
            {
                return prix;
            }

            set
            {
                prix = value;
            }
        }

        public float MargeBeneficiaire
        {
            get
            {
                return margeBeneficiaire;
            }

            set
            {
                margeBeneficiaire = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public int Quantite
        {
            get
            {
                return quantite;
            }

            set
            {
                quantite = value;
            }
        }

        private void afficheCreation(string nom)
        {
            Console.WriteLine("Creation de l'article " + nom);
        }

        public string affiche()
        {
            return "Article : " + nom + ", Prix : " + prix + ", Quantité : " + quantite + ", Marge bénéficiaire : " + margeBeneficiaire;
        }
    }
}