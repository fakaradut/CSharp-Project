using System;
using System.Collections.Generic;
using System.Text;

namespace Message_Program
{
	public class TaslakMesaj : Mesaj
	{
		private DateTime olusturmaTarihi;

		public TaslakMesaj(Kisi gonderen, string mesaj)
		{
			base.gonderen = gonderen;
			base.mesaj = mesaj;
			olusturmaTarihi = DateTime.Now;
		}

		public virtual string getolusturmaTarihi()
		{
			return olusturmaTarihi.ToString();
		}

		public override bool Equals(object taslak)
		{
			if (!(taslak is TaslakMesaj))
			{
				return false;
			}
			else if (this.gonderen.Equals(((TaslakMesaj)taslak).Gonderen))
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
			return base.ToString() + "\nOlusturma tarihi : " + getolusturmaTarihi();
		}

		public virtual Kisi Gonderen
		{
			get
			{
				return base.gonderen;
			}
		}
	}

}