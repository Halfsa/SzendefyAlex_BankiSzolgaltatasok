using System.Reflection;

namespace TestBankiSzolgaltatasok
{
    public class SzamlaTest
    {
        private class SzamlaMock : Szamla
        {
            public SzamlaMock(Tulajdonos tulajdonos) : base(tulajdonos)
            {
            }

            public override bool Kivesz(int osszeg)
            {
                this.aktualisEgyenleg -= osszeg * 2;
                return true;
            }
        }

        Szamla szamla;

        public SzamlaTest()
        {
            Tulajdonos tulajdonos = new Tulajdonos("Gipsz Jakab");
            szamla = new SzamlaMock(tulajdonos);
        }

        [Fact]
        public void GetAktualisEgyenleg()
        {
            Assert.Equal(0, szamla.AktualisEgyenleg);
        }

        [Fact]
        public void Befizet()
        {
            Assert.Equal(0, szamla.AktualisEgyenleg);
            szamla.Befizet(10000);
            Assert.Equal(10000, szamla.AktualisEgyenleg);
        }

        [Fact]
        public void Kivesz()
        {
            Type szamlaType = typeof(Szamla);
            MethodBase? kiveszMethodBase = szamlaType.GetMethod("Kivesz");
            Assert.True(kiveszMethodBase!.IsAbstract);
        }

        [Fact]
        public void UjKartya()
        {
            Kartya k = szamla.UjKartya("1234-5678");
            szamla.Befizet(10000);
            k.Vasarlas(3000);
            Assert.Equal(4000, szamla.AktualisEgyenleg);
        }

        [Fact]
        public void classIsAbstract()
        {
            Assert.True(typeof(Szamla).IsAbstract);
        }
    }
}
