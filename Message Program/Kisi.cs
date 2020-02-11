using System;
using System.Collections.Generic;
using System.Text;

namespace Message_Program
{
	public class Kisi
	{
		private string ad;
		private string soyad;
		private List<GelenMesaj> gelenMesaj;
		private List<GidenMesaj> gidenMesaj;
		private List<TaslakMesaj> taslakMesaj;
		private Rehber kisiTelefonRehberi;

		public Kisi(string ad, string soyad)
		{
			this.ad = ad;
			this.soyad = soyad;
			gelenMesaj = new List<GelenMesaj>();
			gidenMesaj = new List<GidenMesaj>();
			taslakMesaj = new List<TaslakMesaj>();
			this.kisiTelefonRehberi = new Rehber();
		}

		public virtual void mesajGonder(Kisi alici, string mesaj)
		{
			if (kisiTelefonRehberi.kisiKayitliMi(alici))
			{
				this.gidenMesaj.Add(new GidenMesaj(this, alici, mesaj));
				alici.gelenMesaj.Add(new GelenMesaj(this, alici, mesaj));
			}
			else
			{
				Console.WriteLine("Rehberinizde boyle bir kisi bulunmamaktadir.");
			}
		}

		public virtual void taslakMesajiGonder(Kisi alici, string mesaj)
		{
			bool gonderildiMi = false;
			for (int i = 0; i < taslakMesaj.Count; i++)
			{

				if (this.taslakMesaj[i].getMesaj().Contains(mesaj) && kisiTelefonRehberi.kisiKayitliMi(alici))
				{
					mesajGonder(alici, mesaj);
					taslakMesajSil(mesaj);
					gonderildiMi = true;
				}
			}
			if (!gonderildiMi)
			{
				Console.WriteLine("Taslak mesaj gonderilemedi.");
			}
		}

		public virtual void taslakMesajYaz(string mesaj)
		{
			taslakMesaj.Add(new TaslakMesaj(this, mesaj));
		}

		
		public virtual void gelenMesajSil(Kisi gonderen, string mesaj)
		{
			if (kisiTelefonRehberi.kisiKayitliMi(gonderen))
			{
				GelenMesaj gecici = new GelenMesaj(gonderen, this, mesaj);
				for (int i = 0; i < gelenMesaj.Count; i++)
				{
					if (gelenMesaj[i].Equals(gecici))
					{
						gelenMesaj.RemoveAt(i);
						Console.WriteLine(gonderen.kisiBilgi() + " adli kisiden gelen mesaj:\n\"" + mesaj + "\" silindi.");
					}
				}
			}
			else
			{
				Console.WriteLine("Rehberinizde boyle bir kisi bulunmamaktadir.");
			}
		}

		
		public virtual void gelenMesajSil(string gonderenAdi, string gonderenSoyad, string mesaj)
		{
			Kisi gecici = new Kisi(gonderenAdi, gonderenSoyad);
			gelenMesajSil(gecici, mesaj);
		}

		
		public virtual void gidenMesajSil(Kisi alici, string mesaj)
		{
			if (kisiTelefonRehberi.kisiKayitliMi(alici))
			{
				GidenMesaj gecici = new GidenMesaj(this, alici, mesaj);
				for (int i = 0; i < gidenMesaj.Count; i++)
				{
					if (gidenMesaj[i].Equals(gecici))
					{
						gidenMesaj.RemoveAt(i);
						Console.WriteLine(alici.kisiBilgi() + " adli kisiye gelen mesaj:\n\"" + mesaj + "\" silindi.");
					}
				}
			}
			else
			{
				Console.WriteLine("Rehberinizde boyle bir kisi bulunmamaktadir.");
			}
		}

		
		public virtual void gidenMesajSil(string aliciAdi, string aliciSoyadi, string mesaj)
		{
			Kisi gecici = new Kisi(aliciAdi, aliciSoyadi);
			gidenMesajSil(gecici, mesaj);
		}

		public virtual void taslakMesajSil(string mesaj)
		{
			TaslakMesaj gecici = new TaslakMesaj(this, mesaj);
			for (int i = 0; i < taslakMesaj.Count; i++)
			{
				if (taslakMesaj[i].Equals(gecici))
				{
					taslakMesaj.RemoveAt(i);
					Console.WriteLine("Taslak mesaj \"" + mesaj + "\" silindi.");
				}
			}
		}

		public virtual void gidenMesajlariGoster()
		{
			if (!(gidenMesaj.Count == 0))
			{
				Console.WriteLine(this.kisiBilgi() + " kisisi " + this.gidenMesaj.Count + " adet mesaj gondermistir." + "\n---------------------");
				for (int i = 0; i < this.gidenMesaj.Count; i++)
				{
					Console.WriteLine(this.gidenMesaj[i].ToString() + "\n---------------------");
				}
			}
			else
			{
				Console.WriteLine(kisiBilgi() + " adli kisinin gonderdigi mesaj yok.");
			}
		}

		public virtual void gelenMesajlariGoster()
		{
			if (!(gelenMesaj.Count == 0))
			{
				Console.WriteLine(this.kisiBilgi() + " kisisine " + this.gelenMesaj.Count + " adet mesaj gelmistir." + "\n---------------------");
				for (int i = 0; i < this.gelenMesaj.Count; i++)
				{
					Console.WriteLine(this.gelenMesaj[i].ToString() + "\n---------------------");

				}
			}
			else
			{
				Console.WriteLine(kisiBilgi() + " adli kisiye gelen mesaj yok.");
			}
		}

		public virtual void taslakGoster()
		{
			if (!(taslakMesaj.Count == 0))
			{
				Console.WriteLine(this.kisiBilgi() + " kisisinin " + this.taslakMesaj.Count + " adet taslak mesaj� vardir.");
				for (int i = 0; i < this.taslakMesaj.Count; i++)
				{
					Console.WriteLine(this.taslakMesaj[i].ToString());
				}
			}
			else
			{
				Console.WriteLine(kisiBilgi() + " adli kisiye ait taslak mesaj yok.");
			}
		}

		public virtual void mesajSayisi()
		{
			Console.WriteLine(this.kisiBilgi() + " kisisinin " + (taslakMesaj.Count + gidenMesaj.Count + gelenMesaj.Count) + " kadar mesaji vardir.");
		}

		public override bool Equals(object kisi)
		{
			bool isEqual = false;
			if (!(kisi is Kisi))
			{
				return false;
			}
			if (this.ad.Equals(((Kisi)kisi).ad) && this.soyad.Equals(((Kisi)kisi).soyad))
			{
				isEqual = true;
			}
			return base.Equals(kisi) || isEqual;
		}

		public virtual Rehber Rehber
		{
			get
			{
				return kisiTelefonRehberi;
			}
		}

		public virtual string kisiBilgi()
		{
			return ad + " " + soyad;
		}

		public string Ad   
		{
			get { return ad; }   
			set { ad = value; }  
		}

		public string Soyad   
		{
			get { return soyad; }   
			set { soyad = value; }  
		}

	}
}
