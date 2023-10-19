namespace BankiSzolgaltatasok
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Tulajdonos tulajdonos = new Tulajdonos("Asshole Feri");
            Bank bank = new Bank();
            bank.SzamlaNyitas(tulajdonos, 200000);
            Console.WriteLine(bank.OsszHitelkeret);
            bank.SzamlaNyitas(tulajdonos, 2331143);
            Console.WriteLine(bank.OsszHitelkeret);
             
        }
    }
}