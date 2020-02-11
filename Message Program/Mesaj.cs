namespace Message_Program
{
	public abstract class Mesaj
	{
		protected internal Kisi gonderen;
		protected internal Kisi alici;
		protected internal string mesaj;

		public virtual string getMesaj()
		{
			return mesaj;
		}


		public override string ToString()
		{
			if (alici == null)
			{
				return "Gonderen: " + gonderen.Ad + " " + gonderen.Soyad + "\nMesaj: " + getMesaj();
			}
			else
			{
				return "Gonderen: " + gonderen.Ad + " " + gonderen.Soyad + "\nGonderilen: " + alici.Ad + " " + alici.Soyad + "\nMesaj: " + getMesaj();
			}
		}

	}

}