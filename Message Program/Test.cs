using System;

namespace Message_Program
{
	public class Test
	{
		public static void Main(string[] args)
		{

			Kisi ahmet = new Kisi("Ahmet", "Kaplan");
			Kisi mehmet = new Kisi("Mehmet", "Kara");

			ahmet.Rehber.rehbereEkle(mehmet);
			mehmet.Rehber.rehbereEkle(ahmet);

			ahmet.mesajGonder(mehmet, "Nasilsin?");
			mehmet.mesajGonder(ahmet, "Iyi senden");
			ahmet.mesajGonder(mehmet, "Ayni.");
			ahmet.gelenMesajSil(mehmet, "Sen nasilsin?");
			Console.WriteLine("\n---------------------");
			ahmet.gelenMesajlariGoster();
			Console.WriteLine("\n---------------------");
			mehmet.gelenMesajlariGoster();
			ahmet.gidenMesajSil(mehmet, "Nasilsin?");

			ahmet.taslakMesajYaz("Hey");
			ahmet.taslakGoster();
			ahmet.taslakMesajiGonder(mehmet, "Hey");
			ahmet.taslakMesajiGonder(mehmet, "Hey");
			ahmet.mesajSayisi();
			Console.WriteLine("\n---------------------");
			ahmet.Rehber.rehbereKayitliKisileriYazdir();
		}


	}

}