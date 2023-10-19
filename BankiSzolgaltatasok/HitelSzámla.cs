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
			if (base.aktEgyenleg-osszeg < 0) 
			{
				if (Math.Abs(base.aktEgyenleg-osszeg) > hitelKeret)
				{
					return false;
				}
				else 
				{
					aktEgyenleg -= osszeg;
					return true; 
				}
			}
			aktEgyenleg -= osszeg;
			return true;
		}
	}
}
