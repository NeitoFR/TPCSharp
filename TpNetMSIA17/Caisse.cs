using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpNetMSIA17
{
    public class Caisse : IDisposable
    {
        private float solde;

        public Caisse(float solde)
        {
            this.solde = solde;
        }
        
        public float Solde
        {
            get
            {
                return solde;
            }
            set
            {
                solde = value;
            }
        }

        public void AjouterArgent(float argent)
        {
            solde += argent;
        }

        public void EnleverArgent(float argent)
        {
            solde -= argent;
        }

        public void Dispose()
        {
            Console.WriteLine("Destruction de la caisse");
        }
    }
}