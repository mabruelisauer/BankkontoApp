using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankkontoApp
{
    public class Jugendkonto : Konto
    {
        public int KontoNummer { get; set; }
        public double Guthaben { get; set; }
        public double ZinsGuthaben { get; set; }
        public double ZinsSchuld { get; set; }
        public static double AktivZins { get; set; }
        public static double PassivZins { get; set; }
        public static int KontoNummerZähler { get; set; } = 0;
        public double Bezugslimite { get; set; }

        public Jugendkonto(int alter)
        {
            if (alter >= 20)
            {
                throw new ArgumentException("Du bist zu alt um ein Jugendkonto zu eröffnen.");
            } 
            else
            {
                KontoNummer = KontoNummerZähler + 1;
                KontoNummerZähler += 1;
                Guthaben = 0;
                ZinsGuthaben = 0;
                ZinsSchuld = 0;
                AktivZins = 0.85;
                PassivZins = 0.03;
                Bezugslimite = 1000;
            }
        }

        public void ZahleEin(double betrag)
        {
            Guthaben += betrag;
        }

        public void Beziehe(double betrag)
        {
            if (Guthaben < betrag)
            {
                throw new ArgumentException("Du kannst ein Jugendkonto nicht überziehen.");
            }
            else if (betrag >= Bezugslimite)
            {
                throw new ArgumentException("Bezugslimite überschritten.");
            }
            else
            {
                Guthaben -= betrag;
            }
        }

        public void Transferiere(Jugendkonto gutschriftKonto, double betrag)
        {
            if (Guthaben >= betrag)
            {
                Guthaben -= betrag;
                gutschriftKonto.Guthaben += betrag;
            }
            else
            {
                throw new ArgumentException("Du kannst ein Jugendkonto nicht überziehen.");
            }
        }

        public void SchreibeZinsGut(int anzTage)
        {
            var tageImJahr = 360;

            if (Guthaben >= 0)
            {
                ZinsGuthaben += Guthaben * (AktivZins / tageImJahr) * anzTage;
            }
            else
            {
                ZinsSchuld += Guthaben * (PassivZins / tageImJahr) * anzTage;
            }
        }

        public void SchliesseKontAb()
        {
            double zins = ZinsGuthaben + ZinsSchuld;
            Guthaben += zins;
        }
    }
}
