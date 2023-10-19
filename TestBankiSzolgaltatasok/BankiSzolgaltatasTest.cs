namespace TestBankiSzolgaltatasok
{
    public class BankiSzolgaltatasTest
    {
        class BankiSzolgaltatasMock : BankiSzolgaltatas
        {
            public BankiSzolgaltatasMock(Tulajdonos tulajdonos) : base(tulajdonos)
            {
            }
        }

        [Fact]
        public void GetTulajdonos()
        {
            Tulajdonos tulajdonos = new Tulajdonos("Gipsz Jakab");
            BankiSzolgaltatas szolgaltatas = new BankiSzolgaltatasMock(tulajdonos);
            Assert.Equal(tulajdonos, szolgaltatas.Tulajdonos);
        }

        [Fact]
        public void ClassIsAbstract()
        {
            Assert.True(typeof(BankiSzolgaltatas).IsAbstract);
        }
    }
}
