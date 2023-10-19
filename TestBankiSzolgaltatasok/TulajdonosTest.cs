namespace TestBankiSzolgaltatasok
{
    public class TulajdonosTest
    {
        Tulajdonos tulajdonos;

        public TulajdonosTest()
        {
            tulajdonos = new Tulajdonos("Gipsz Jakab");
        }

        [Fact]
        public void GetNev()
        {
            Assert.Equal("Gipsz Jakab", tulajdonos.Nev);
        }

        [Fact]
        public void SetNev()
        {
            tulajdonos.Nev = "Teszt Elek";
            Assert.Equal("Teszt Elek", tulajdonos.Nev);
        }

        [Fact]
        public void ClassIsSealed()
        {
            Assert.True(typeof(Tulajdonos).IsSealed);
        }
    }
}