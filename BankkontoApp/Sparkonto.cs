using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankkontoApp.Privatkonto;

namespace BankkontoApp
{
    public class Sparkonto : Konto
    {

        public int KontoNummer { get; set; }
        public double Guthaben { get; set; }
        public double ZinsGuthaben { get; set; }
        public double ZinsSchuld { get; set; }
        public static double AktivZins { get; set; }
        public static double PassivZins { get; set; }
        public static int KontoNummerZähler { get; set; } = 0;
        public KundenStatus Status { get; set; }


        public Sparkonto(KundenStatus status)
        {
            KontoNummer = KontoNummerZähler + 1;
            KontoNummerZähler += 1;
            Guthaben = 0;
            ZinsGuthaben = 0;
            ZinsSchuld = 0;
            AktivZins = 1.04;
            PassivZins = 0.03;
            Status = status;
        }

        public enum KundenStatus
        {
            Standard,
            VIP
        }

        public void ZahleEin(double betrag)
        {
            Guthaben += betrag;
        }

        public void Beziehe(double betrag)
        {
            if (Guthaben >= betrag)
            {
                Guthaben -= betrag;
            }
            else
            {
                throw new ArgumentException("Du kannst ein Sparkonto nicht überziehen.");
            }
        }

        public void Transferiere(Sparkonto gutschriftKonto, double betrag)
        {
            if (Guthaben >= betrag)
            {
                Guthaben -= betrag;
                gutschriftKonto.Guthaben += betrag;
            }
            else
            {
                throw new ArgumentException("Du kannst ein Sparkonto nicht überziehen.");
            }
        }

        public void SchreibeZinsGut(int anzTage)
        {
            var tageImJahr = 360;

            if (Guthaben == 0)
            {
                throw new NotImplementedException();
            }
            else if (Guthaben > 0)
            {
                if (Guthaben < 10000)
                {
                    ZinsGuthaben += Guthaben * (AktivZins / tageImJahr) * anzTage;
                }
                else if (Guthaben < 50000)
                {
                    double zins = AktivZins - 0.5;
                    ZinsGuthaben += Guthaben * (zins / tageImJahr) * anzTage;
                }
                else if (Guthaben < 100000 && Status == KundenStatus.VIP)
                {
                    double zins = AktivZins - 0.75;
                    ZinsGuthaben += Guthaben * (zins / tageImJahr) * anzTage;
                }
                else if (Guthaben < 100000 && Status == KundenStatus.Standard)
                {
                    double zins = AktivZins - 1;
                    ZinsGuthaben += Guthaben * (zins / tageImJahr) * anzTage;
                }
                else
                {
                    throw new NotImplementedException();
                }
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
