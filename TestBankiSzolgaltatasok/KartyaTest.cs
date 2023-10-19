namespace TestBankiSzolgaltatasok
{
    public class KartyaTest
    {
        Kartya kartya;
        Szamla szamla;

        public KartyaTest()
        {
            Tulajdonos tulajdonos = new Tulajdonos("Gipsz Jakab");
            szamla = new MegtakaritasiSzamla(tulajdonos);
            kartya = new Kartya(tulajdonos, szamla, "1234-5678");
        }

        [Fact]
        public void GetKartyaSzam()
        {
            Assert.Equal("1234-5678", kartya.KartyaSzam);
        }

        [Fact]
        public void Vasarlas()
        {
            Assert.False(kartya.Vasarlas(1));
            szamla.Befizet(10000);
            Assert.False(kartya.Vasarlas(10001));
            Assert.Equal(10000, szamla.AktualisEgyenleg);
            Assert.True(kartya.Vasarlas(10000));
            Assert.Equal(0, szamla.AktualisEgyenleg);
        }
    }
}
