using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public abstract class Szamla : BankiSzolgaltatas
	{
		protected int aktEgyenleg;
		public Szamla(Tulajdonos tulaj) : base(tulaj)
		{
			aktEgyenleg = 0;
		}

		public int AktEgyenleg { get => aktEgyenleg;}

		public void Befizet(int osszeg)
		{
			aktEgyenleg += osszeg;
		}
		public abstract bool Kivesz(int osszeg);
		public Kartya UjKartya(string kartyaszam)
		{
			Kartya kartyus = new Kartya(this.Tulajdonos, this, kartyaszam);
			return kartyus;
		}
	}
}
