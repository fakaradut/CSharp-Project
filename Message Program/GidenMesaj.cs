using System;
using System.Collections.Generic;
using System.Text;

namespace Message_Program
{
	public class GidenMesaj : Mesaj
	{
		private DateTime gondermeTarihi;

		public GidenMesaj(Kisi gonderen, Kisi alici, string mesaj)
		{
			base.gonderen = gonderen;
			base.alici = alici;
			base.mesaj = mesaj;
			this.gondermeTarihi = DateTime.Now;

		}

		public virtual string GondermeTarihi
		{
			get
			{
				return gondermeTarihi.ToString();
			}
		}

		public override bool Equals(object o)
		{
			if (!(o is GidenMesaj))
			{
				return false;
			}
			else if (base.gonderen.Ad.Equals(((GidenMesaj)o).gonderen.Ad) && base.gonderen.Soyad.Equals(((GidenMesaj)o).gonderen.Soyad) && base.mesaj.Equals(((GidenMesaj)o).mesaj))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public override string ToString()
		{
			return base.ToString() + "\nGonderme Tarihi: " + GondermeTarihi;
		}
	}
}