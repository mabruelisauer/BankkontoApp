using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankkontoApp
{
    internal interface Konto
    {
        public int KontoNummer { get; protected set; }
        public double Guthaben { get; protected set; }
        public double ZinsGuthaben { get; protected set; }
        public static double AktivZins { get; set; }
        public static double PassivZins { get; set; }
        public static int KontoNummerZähler { get; set; } = 0;


        public void Beziehe(double betrag)
        {
            
        }

        public void Transferiere(Bankkonto gutschriftKonto, double betrag)
        {
           
        }

        public void SchreibeZinsGut(int anzTage)
        {
            
        }

        public void SchliesseKontAb()
        {
            
        }
    }
}
