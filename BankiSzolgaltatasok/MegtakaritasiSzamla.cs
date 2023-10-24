using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public class MegtakaritasiSzamla : Szamla
	{
		public static double alapKamat;
		private double kamat;

		public MegtakaritasiSzamla(Tulajdonos tulaj) : base(tulaj)
		{
			alapKamat = 1.1;
		}

		public double Kamat { get => kamat; set => kamat = value; }

		public override bool Kivesz(int osszeg)
		{
			if (base.aktualisEgyenleg - osszeg < 0)
			{
				return false;
			}
			aktualisEgyenleg -= osszeg;
			return true;
		}
		public void KamatJovairas()
		{
			base.aktualisEgyenleg = Convert.ToInt32(Math.Round(aktualisEgyenleg * kamat));
		}
	}
}
