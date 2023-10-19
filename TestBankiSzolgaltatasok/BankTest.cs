namespace TestBankiSzolgaltatasok
{
    public class BankTest
    {

        Bank bank;
        Tulajdonos tulajdonos;

        public BankTest()
        {
            bank = new Bank();
            tulajdonos = new Tulajdonos("Gipsz Jakab");
        }

        [Fact]
        public void SzamlaNyitas()
        {
            Szamla sz1 = bank.SzamlaNyitas(tulajdonos, 0);
            Szamla sz2 = bank.SzamlaNyitas(tulajdonos, 1);
            Assert.True(sz1 is MegtakaritasiSzamla);
            Assert.True(sz2 is HitelSzamla);
        }

        [Fact]
        public void SzamlaNyitasNegativHitelkeret()
        {
            Assert.Throws<ArgumentException>(() => bank.SzamlaNyitas(tulajdonos, -1));
        }

        [Fact]
        public void GetOsszEgyenleg()
        {
            Tulajdonos t2 = new Tulajdonos("Teszt Elek");
            Tulajdonos t3 = new Tulajdonos("Teszt Elek");
            Szamla sz1 = bank.SzamlaNyitas(tulajdonos, 0);
            Szamla sz2 = bank.SzamlaNyitas(tulajdonos, 1);
            Szamla sz3 = bank.SzamlaNyitas(t2, 0);
            Szamla sz4 = bank.SzamlaNyitas(t2, 1);
            Szamla sz5 = bank.SzamlaNyitas(t3, 0);
            Szamla sz6 = bank.SzamlaNyitas(t3, 1);
            sz1.Befizet(15000);
            sz2.Befizet(10000);
            sz3.Befizet(30000);
            sz4.Befizet(35000);
            sz5.Befizet(70000);
            sz6.Befizet(75000);
            Assert.Equal(25000, bank.GetOsszEgyenleg(tulajdonos));
            Assert.Equal(65000, bank.GetOsszEgyenleg(t2));
            Assert.Equal(145000, bank.GetOsszEgyenleg(t3));
        }

        [Fact]
        public void GetLegnagyobbEgyenleguSzamla()
        {
            Tulajdonos t2 = new Tulajdonos("Teszt Elek");
            Tulajdonos t3 = new Tulajdonos("Teszt Elek");
            Szamla sz1 = bank.SzamlaNyitas(tulajdonos, 0);
            Szamla sz2 = bank.SzamlaNyitas(tulajdonos, 1);
            Szamla sz3 = bank.SzamlaNyitas(t2, 0);
            Szamla sz4 = bank.SzamlaNyitas(t2, 1);
            Szamla sz5 = bank.SzamlaNyitas(t3, 0);
            Szamla sz6 = bank.SzamlaNyitas(t3, 1);
            sz1.Befizet(85000);
            sz2.Befizet(10000);
            sz3.Befizet(30000);
            sz4.Befizet(35000);
            sz5.Befizet(75000);
            sz6.Befizet(70000);
            Assert.Equal(sz1, bank.GetLegnagyobbEgyenleguSzamla(tulajdonos));
            Assert.Equal(sz4, bank.GetLegnagyobbEgyenleguSzamla(t2));
            Assert.Equal(sz5, bank.GetLegnagyobbEgyenleguSzamla(t3));
        }

        [Fact]
        public void GetOsszHitelkeret()
        {
            Tulajdonos t2 = new Tulajdonos("Teszt Elek");
            Tulajdonos t3 = new Tulajdonos("Teszt Elek");
            bank.SzamlaNyitas(tulajdonos, 0);
            bank.SzamlaNyitas(tulajdonos, 10000);
            bank.SzamlaNyitas(t2, 0);
            bank.SzamlaNyitas(t2, 15000);
            bank.SzamlaNyitas(t3, 0);
            bank.SzamlaNyitas(t3, 20000);
            Assert.Equal(45000, bank.OsszHitelkeret);
        }
    }
}
