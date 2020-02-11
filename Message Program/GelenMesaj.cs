using System;
using System.Collections.Generic;
using System.Text;

namespace Message_Program
{
	public class GelenMesaj : Mesaj
	{
		private DateTime gelmeTarihi;

		public GelenMesaj(Kisi gonderen, Kisi alici, string mesaj)
		{
			base.gonderen = gonderen;
			base.alici = alici;
			base.mesaj = mesaj;
			this.gelmeTarihi = DateTime.Now;
		}

		public virtual string GelmeTarihi
		{
			get
			{
				return this.gelmeTarihi.ToString();
			}
		}

		public override bool Equals(object o)
		{
			if (o is GelenMesaj)
			{
				return (((GelenMesaj)o).gonderen.Ad.Equals(base.gonderen.Ad)) && (((GelenMesaj)o).gonderen.Soyad.Equals(base.gonderen.Soyad));
			}
			else
			{
				return false;
			}
		}

		public override string ToString()
		{
			return base.ToString() + "\nGelme Tarihi: " + GelmeTarihi;
		}
	}

}