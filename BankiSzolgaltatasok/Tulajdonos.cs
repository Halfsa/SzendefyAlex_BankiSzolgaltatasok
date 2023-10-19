using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	internal sealed class Tulajdonos
	{
		private string tulaj;

		public Tulajdonos(string tulaj)
		{
			this.tulaj = tulaj;
		}

		public string Tulaj { get => tulaj; set => tulaj = value; }
	}
}
