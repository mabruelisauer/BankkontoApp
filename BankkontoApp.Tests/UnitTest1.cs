namespace BankkontoApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AKontoNummerTest()
        {
            //Assign
            Bankkonto bankkonto = new Bankkonto();
            Bankkonto bankkonto2 = new Bankkonto();
            Bankkonto bankkonto3 = new Bankkonto();
            //Act
            //Assert
            Assert.AreEqual(3, bankkonto3.KontoNummer);
        }

        [TestMethod]
        public void ZahleEinTest()
        {
            //Assign
            Bankkonto bankkonto = new Bankkonto();
            //Act
            bankkonto.ZahleEin(500);
            //Assert
            Assert.AreEqual(500, bankkonto.Guthaben);
        }

        [TestMethod]
        public void ErfolgreichBezieheTest()
        {
            //Assign
            Bankkonto bankkonto = new Bankkonto();
            //Act
            bankkonto.ZahleEin(1000);
            bankkonto.Beziehe(500);
            //Assert
            Assert.AreEqual(500, bankkonto.Guthaben);
        }

        //[TestMethod]
        //public void ExceptionBezieheTest()
        //{
        //    //Assign
        //    Bankkonto bankkonto = new Bankkonto();
        //    //Act
        //    bankkonto.ZahleEin(200);
        //    //Assert
        //    Assert.ThrowsException<ArgumentException>(() => bankkonto.Beziehe(500));
        //}

        [TestMethod]
        public void ErfolgreichTransferiere()
        {
            //Assign
            Bankkonto bankkonto = new Bankkonto();
            Bankkonto bankkonto2 = new Bankkonto();
            //Act
            bankkonto.ZahleEin(1000);
            bankkonto.Transferiere(bankkonto2, 500);
            //Assert
            Assert.AreEqual(bankkonto.Guthaben, bankkonto2.Guthaben);
        }

        //[TestMethod]
        //public void ExceptionTransferiere()
        //{
        //    //Assign
        //    Bankkonto bankkonto = new Bankkonto();
        //    Bankkonto bankkonto2 = new Bankkonto();
        //    //Act
        //    //Assert
        //    Assert.ThrowsException<ArgumentException>(() => bankkonto.Transferiere(bankkonto2, 500));
        //}

        [TestMethod]
        public void AktivzinsTest()
        {
            //Assign
            Bankkonto bankkonto = new Bankkonto();
            //Act
            bankkonto.ZahleEin(10000);
            bankkonto.SchreibeZinsGut(45);
            //Assert
            Assert.AreEqual(25, bankkonto.ZinsGuthaben);
        }

        [TestMethod]
        public void PassivzinsTest()
        {
            //Assign
            Bankkonto bankkonto = new Bankkonto();
            //Act
            bankkonto.Beziehe(10000);
            bankkonto.SchreibeZinsGut(45);
            //Assert
            Assert.AreEqual(-37.5, bankkonto.ZinsSchuld);
        }

        [TestMethod]
        public void SchreibeZinsGutTest()
        {
            //Assign
            Bankkonto bankkonto = new Bankkonto();
            //Act
            bankkonto.ZahleEin(1000);
            bankkonto.ZahleEin(1000);
            bankkonto.Beziehe(3000);
            bankkonto.ZahleEin(2000);
            bankkonto.SchreibeZinsGut(360);
            //Assert
            Assert.AreEqual(20, bankkonto.ZinsGuthaben);
        }

        [TestMethod]
        public void SchliesseKontoAbTest()
        {
            //Assign
            Bankkonto bankkonto = new Bankkonto();
            //Act
            bankkonto.ZahleEin(1000);
            bankkonto.ZahleEin(1000);
            bankkonto.Beziehe(3000);
            bankkonto.ZahleEin(2000);
            bankkonto.SchreibeZinsGut(360);

            bankkonto.SchliesseKontAb();
            //Assert
            Assert.AreEqual(1020, bankkonto.Guthaben);
        }

        [TestMethod]
        public void SchliesseKontoNegativAbTest()
        {
            //Assign
            Bankkonto bankkonto = new Bankkonto();
            //Act
            bankkonto.Beziehe(10000);
            bankkonto.SchreibeZinsGut(45);

            bankkonto.SchliesseKontAb();
            //Assert
            Assert.AreEqual(-10037.5, bankkonto.Guthaben);
        }






        [TestMethod]
        public void PrivatkontoÜberzug()
        {
            //Assign
            Privatkonto privatkonto = new Privatkonto();
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => privatkonto.Beziehe(10001));
        }

        [TestMethod]
        public void SparkontoÜberzug()
        {
            //Assign
            Sparkonto sparkonto = new Sparkonto(Sparkonto.KundenStatus.VIP);
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => sparkonto.Beziehe(1));
        }

        [TestMethod]
        public void JugendkontoÜberzug()
        {
            //Assign
            Jugendkonto jugendkonto = new Jugendkonto(17);
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => jugendkonto.Beziehe(1));
        }

        [TestMethod]
        public void JugendkontoBezugslimitte()
        {
            //Assign
            Jugendkonto jugendkonto = new Jugendkonto(18);
            //Act
            jugendkonto.ZahleEin(2000);
            //Assert
            Assert.ThrowsException<ArgumentException>(() => jugendkonto.Beziehe(1001));
        }

        [TestMethod]
        public void PrivatkontoFixgebühr()
        {
            //Assign
            Privatkonto privatkonto = new Privatkonto();
            //Act
            privatkonto.ZahleEin(4000);
            privatkonto.Beziehe(3000);
            privatkonto.SchreibeZinsGut(360);

            privatkonto.SchliesseKontAb();
            //Assert
            Assert.AreEqual(20, privatkonto.Guthaben);
        }

        [TestMethod]
        public void JugendkontoZuAlt()
        {
            //Assign
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => new Jugendkonto(20));
        }

        [TestMethod]
        public void PrivatkontoAuftragsgebühr()
        {
            //Assign
            Privatkonto privatkonto1 = new Privatkonto();
            Privatkonto privatkonto2 = new Privatkonto();
            //Act
            privatkonto1.ZahleEin(1000);
            for (int i = 0; i < 11; i++)
            {
                privatkonto1.Transferiere(privatkonto2, 10);
            }
            //Assert
            Assert.AreEqual(888, privatkonto1.Guthaben);
        }







        [TestMethod]
        public void StatusZinsTest1()
        {
            //Assign
            Sparkonto sparkonto = new Sparkonto(Sparkonto.KundenStatus.VIP);
            double expected = 1040.0000000000002;

            //Act
            sparkonto.ZahleEin(1000);
            sparkonto.SchreibeZinsGut(360);
            //Assert
            Assert.AreEqual(expected, sparkonto.ZinsGuthaben);
        }

        [TestMethod]
        public void StatusZinsTest2()
        {
            //Assign
            Sparkonto sparkonto = new Sparkonto(Sparkonto.KundenStatus.Standard);
            //Act
            sparkonto.ZahleEin(11000);
            sparkonto.SchreibeZinsGut(360);
            //Assert
            Assert.AreEqual(5940, sparkonto.ZinsGuthaben);
        }

        [TestMethod]
        public void StatusZinsTest3()
        {
            //Assign
            Sparkonto sparkonto = new Sparkonto(Sparkonto.KundenStatus.VIP);
            //Act
            sparkonto.ZahleEin(51000);
            sparkonto.SchreibeZinsGut(360);
            //Assert
            Assert.AreEqual(14790, sparkonto.ZinsGuthaben);
        }

        [TestMethod]
        public void StatusZinsTest4()
        {
            //Assign
            Sparkonto sparkonto = new Sparkonto(Sparkonto.KundenStatus.Standard);
            double expected = 2040.0000000000018;
            //Act
            sparkonto.ZahleEin(51000);
            sparkonto.SchreibeZinsGut(360);
            //Assert
            Assert.AreEqual(expected, sparkonto.ZinsGuthaben);
        }

        [TestMethod]
        public void StatusZinsTest5()
        {
            //Assign
            Sparkonto sparkonto = new Sparkonto(Sparkonto.KundenStatus.Standard);
            //Act
            sparkonto.ZahleEin(101000);

            //Assert
            Assert.ThrowsException<NotImplementedException>(() => sparkonto.SchreibeZinsGut(360));
        }

        [TestMethod]
        public void StatusZinsTest6()
        {
            //Assign
            Sparkonto sparkonto = new Sparkonto(Sparkonto.KundenStatus.Standard);
            //Act
            //Assert
            Assert.ThrowsException<NotImplementedException>(() => sparkonto.SchreibeZinsGut(360));
        }
    }
}