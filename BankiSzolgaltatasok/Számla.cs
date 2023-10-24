using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public abstract class Szamla : BankiSzolgaltatas
	{
		protected int aktualisEgyenleg;
		public Szamla(Tulajdonos tulaj) : base(tulaj)
		{
			aktualisEgyenleg = 0;
		}

		public int AktualisEgyenleg { get => aktualisEgyenleg;}

		public void Befizet(int osszeg)
		{
			aktualisEgyenleg += osszeg;
		}
		public abstract bool Kivesz(int osszeg);
		public Kartya UjKartya(string kartyaszam)
		{
			Kartya kartyus = new Kartya(this.Tulajdonos, this, kartyaszam);
			return kartyus;
		}
	}
}
