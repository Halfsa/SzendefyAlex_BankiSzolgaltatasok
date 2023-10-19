using BankiSzolgaltatasok;

namespace TestBankiSzolgaltatasok
{
    public class HitelSzamlaTest
    {
        HitelSzamla szamla;

        public HitelSzamlaTest()
        {
            szamla = new HitelSzamla(new Tulajdonos("Gipsz Jakab"), 10000);
        }

        [Fact]
        public void GetHitelKeret()
        {
            Assert.Equal(10000, szamla.HitelKeret);
        }

        [Fact]
        public void Kivesz()
        {
            Assert.False(szamla.Kivesz(10001));
            Assert.Equal(0, szamla.AktualisEgyenleg);
            Assert.True(szamla.Kivesz(10000));
            Assert.Equal(-10000, szamla.AktualisEgyenleg);
            szamla.Befizet(20000);
            Assert.True(szamla.Kivesz(5000));
            Assert.Equal(5000, szamla.AktualisEgyenleg);
        }
    }
}
