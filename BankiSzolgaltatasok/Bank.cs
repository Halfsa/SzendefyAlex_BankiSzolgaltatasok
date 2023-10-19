using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public class Bank
	{
		private List<Szamla> szamlaLista;

		public Bank()
		{
			this.szamlaLista = new List<Szamla>();
		}
		private int osszHitel()
		{
			int krumpli = 0;
            foreach (var item in szamlaLista)
            {
				if (item.GetType() == typeof(HitelSzamla))
				{
					krumpli += ((HitelSzamla)item).HitelKeret;
				}
            }
			return krumpli;
        }
		public long OsszHitelkeret { get =>  osszHitel(); }
		public Szamla SzamlaNyitas(Tulajdonos tulajdonos, int hitelKeret)
		{
			if (hitelKeret>0)
			{
				HitelSzamla szamla = new HitelSzamla(tulajdonos,hitelKeret);
				szamlaLista.Add(szamla);
				return szamla;
			}
			else if (hitelKeret==0)
			{
				MegtakaritasiSzamla szamla = new MegtakaritasiSzamla(tulajdonos);
				szamlaLista.Add(szamla);
				return szamla;
			}
			throw new ArgumentException("A hitelkeret nem lehet negatív!");
		}
		public long GetOsszEgyenleg(Tulajdonos tulajdonos)
		{
			int egyenleg = 0;
			foreach (var item in szamlaLista)
			{
				if (item.Tulajdonos == tulajdonos)
				{
					egyenleg += item.AktEgyenleg;
				}
			}
			return egyenleg;
		}
		public Szamla GetLegnagyobbEgyenleguSzamla(Tulajdonos tulajdonos)
		{
			int legnagyobb = int.MinValue;
			int index = 0;

			for (int i = 0; i < szamlaLista.Count; i++)
			{
				if (szamlaLista[i].Tulajdonos == tulajdonos)
				{
					if (szamlaLista[i].AktEgyenleg>legnagyobb)
					{
						legnagyobb = szamlaLista[i].AktEgyenleg;
						index = i;
					}
				}
			}
			return szamlaLista[index];
        }
	}
}
