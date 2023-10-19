using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	internal class Szamla : BankiSzolgaltatas
	{
		private int aktEgyenleg;
		public Szamla(Tulajdonos tulaj) : base(tulaj)
		{
			aktEgyenleg = 0;
		}

		public int AktEgyenleg { get => aktEgyenleg;}

		public void Befizet(int osszeg)
		{
			aktEgyenleg += osszeg;
		}
		public bool Kivesz(int osszeg)
		{
			return false;
		}
	}
}
