using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public class Kartya : BankiSzolgaltatas
	{
		private string kartyaSzam;
		private Szamla szamla;
		public Kartya(Tulajdonos tulaj, Szamla szamla, string kartyaSzam) : base(tulaj)
		{
			this.szamla = szamla;
			this.kartyaSzam = kartyaSzam;
		}

		public string KartyaSzam { get => kartyaSzam; }

		public bool Vasarlas(int osszeg)
		{
            if (szamla.Kivesz(osszeg))
            {
				return true;
            }
			return false;
        }
	}
}
