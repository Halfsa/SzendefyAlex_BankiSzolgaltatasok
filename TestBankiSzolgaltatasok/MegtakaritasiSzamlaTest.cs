namespace TestBankiSzolgaltatasok
{
    public class MegtakaritasiSzamlaTest
    {

        MegtakaritasiSzamla szamla;

        public MegtakaritasiSzamlaTest()
        {
            Tulajdonos tulajdonos = new Tulajdonos("Gipsz Jakab");
            szamla = new MegtakaritasiSzamla(tulajdonos);
        }

        [Fact]
        public void GetKamat()
        {
            Assert.Equal(MegtakaritasiSzamla.alapKamat, szamla.Kamat);
        }

        [Fact]
        public void SetKamat()
        {
            szamla.Kamat = 1.08;
            Assert.Equal(1.08, szamla.Kamat);
        }

        [Fact]
        public void Kivesz()
        {
            Assert.False(szamla.Kivesz(1));
            szamla.Befizet(10000);
            Assert.Equal(10000, szamla.AktualisEgyenleg);
            Assert.False(szamla.Kivesz(10001));
            Assert.True(szamla.Kivesz(10000));
            Assert.Equal(0, szamla.AktualisEgyenleg);
        }

        [Fact]
        public void KamatJovairas()
        {
            szamla.Befizet(10000);
            int ujEgyenleg = (int)(szamla.AktualisEgyenleg * MegtakaritasiSzamla.alapKamat);
            szamla.KamatJovairas();
            Assert.Equal(ujEgyenleg, szamla.AktualisEgyenleg);
        }
    }
}
