using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankkontoApp
{
    public class Bankkonto
    {
        public int KontoNummer { get; private set; }
        public double Guthaben { get; private set; }
        public double ZinsGuthaben { get; private set; }
        public double ZinsSchuld { get; private set; }
        public static double AktivZins { get; set; }
        public static double PassivZins { get; set; }
        public static int KontoNummerZähler { get; set; } = 0;

        public Bankkonto()
        {
            KontoNummer = KontoNummerZähler + 1;
            KontoNummerZähler += 1;
            Guthaben = 0;
            ZinsGuthaben = 0;
            ZinsSchuld = 0;
            AktivZins = 0.02;
            PassivZins = 0.03;
        }

        public void ZahleEin(double betrag)
        {
            Guthaben += betrag;
        }

        public void Beziehe(double betrag)
        {
            Guthaben -= betrag;
        }

        public void Transferiere(Bankkonto gutschriftKonto, double betrag)
        {
                Guthaben -= betrag;
                gutschriftKonto.Guthaben += betrag;
        }

        public void SchreibeZinsGut(int anzTage)
        {
            var tageImJahr = 360;

            if (Guthaben >= 0)
            {
                ZinsGuthaben += Guthaben * (AktivZins/tageImJahr) * anzTage;
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
