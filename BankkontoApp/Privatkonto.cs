using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankkontoApp
{
    public class Privatkonto : Konto
    {
        public int KontoNummer { get; set; }
        public double Guthaben { get; set; }
        public double ZinsGuthaben { get; set; }
        public double ZinsSchuld { get; set; }
        public static double AktivZins { get; set; }
        public static double PassivZins { get; set; }
        public static int KontoNummerZähler { get; set; } = 0;
        public double Maximalbetrag {  get; set; }
        public double JahresabschlussFixgebür {  get; set; }
        public int ZahlungsAufträgeCounter { get; set; }
        public double AuftragsGebühr {  get; set; }

        public Privatkonto()
        {
            KontoNummer = KontoNummerZähler + 1;
            KontoNummerZähler += 1;
            Guthaben = 0;
            ZinsGuthaben = 0;
            AktivZins = 0.02;
            PassivZins = 0.03;
            Maximalbetrag = -10000;
            JahresabschlussFixgebür = 1000;
            ZahlungsAufträgeCounter = 0;
            AuftragsGebühr = 2;
        }

        public void ZahleEin(double betrag)
        {
            Guthaben += betrag;
        }

        public void Beziehe(double betrag)
        {
            if (Guthaben - betrag >= Maximalbetrag)
            {
                Guthaben -= betrag;
            }
            else
            {
                throw new ArgumentException("Diese Transaktion würde das Konto über den Maximalbetrag hinaus überziehen.");
            }
        }

        public void Transferiere(Privatkonto gutschriftKonto, double betrag)
        {
            if (Guthaben - betrag >= Maximalbetrag)
            {
                if (ZahlungsAufträgeCounter <= 9)
                {
                    Guthaben -= betrag;
                    gutschriftKonto.Guthaben += betrag;
                    ZahlungsAufträgeCounter++;
                }
                else
                {
                    Guthaben -= betrag;
                    Guthaben -= AuftragsGebühr;
                    gutschriftKonto.Guthaben += betrag;
                    ZahlungsAufträgeCounter++;
                }
            }
            else
            {
                throw new ArgumentException("Diese Transaktion würde das Konto über den Maximalbetrag hinaus überziehen.");
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
            Guthaben -= JahresabschlussFixgebür;
        }
    }
}
