using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public class HitelSzamla : Szamla
	{
		private int hitelKeret;
		public HitelSzamla(Tulajdonos tulaj, int hitelKeret) : base(tulaj)
		{
			this.hitelKeret = hitelKeret;
		}

		public int HitelKeret { get => hitelKeret; }

		public override bool Kivesz(int osszeg)
		{
			if (base.aktualisEgyenleg-osszeg < 0) 
			{
				if (Math.Abs(base.aktualisEgyenleg-osszeg) > hitelKeret)
				{
					return false;
				}
				else 
				{
					aktualisEgyenleg -= osszeg;
					return true; 
				}
			}
			aktualisEgyenleg -= osszeg;
			return true;
		}
	}
}
