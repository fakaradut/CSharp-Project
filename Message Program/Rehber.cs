using System;
using System.Collections.Generic;
using System.Text;

namespace Message_Program
{

	public class Rehber
	{
		private List<Kisi> rehber;

		public Rehber()
		{
			rehber = new List<Kisi>();
		}

		
		public virtual void rehbereEkle(Kisi kisi)
		{
			if (!kisiKayitliMi(kisi))
			{
				rehber.Add(kisi);
			}
			else
			{
				Console.WriteLine(kisi.kisiBilgi() + " adli kisi bu rehbere zaten kayitli.");
			}
		}

		public virtual void rehbereEkle(Kisi[] kisiler)
		{
			for (int i = 0; i < kisiler.Length; i++)
			{
				if (kisiler[i] != null)
				{
					rehbereEkle(kisiler[i]);
				}
			}
		}

		public virtual void rehberdenSil(Kisi kisi)
		{
			if (this.kisiKayitliMi(kisi))
			{
				rehber.Remove(kisi);
				Console.WriteLine(kisi.kisiBilgi() + " adli kisi bu rehberden silindi.");
			}
		}

		public virtual void rehberiTemizle()
		{
			rehber = new List<Kisi>();
		}

		public virtual bool kisiKayitliMi(Kisi kisi)
		{
			for (int i = 0; i < rehber.Count; i++)
			{
				if (rehber[i].Equals(kisi))
				{
					return true;
				}
			}
			return false;
		}

		public virtual void rehbereKayitliKisileriYazdir()
		{
			if (rehber.Count == 0)
			{
				Console.WriteLine("Rehbere kayitli kimse yoktur.");
			}
			else
			{
				Console.WriteLine("Bu rehbere " + (rehber.Count) + " kadar kisi kayitlidir.");
			}
			for (int i = 0; i < rehber.Count; i++)
			{
				if (rehber[i] != null)
				{
					Console.WriteLine(rehber[i].kisiBilgi());
				}
			}
		}
	}

}