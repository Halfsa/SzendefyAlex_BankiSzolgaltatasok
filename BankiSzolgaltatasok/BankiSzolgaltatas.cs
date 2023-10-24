using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public abstract class BankiSzolgaltatas
	{
		private Tulajdonos tulajdonos;
		protected BankiSzolgaltatas(Tulajdonos tulaj)
		{
			tulajdonos = tulaj;
		}

		public Tulajdonos Tulajdonos { get => tulajdonos; }
	}
}
