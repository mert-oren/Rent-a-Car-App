using System;
namespace rent_a_car_app
{
    public class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaBedeli { get; set; }
        public string AracTipi { get; set; }
        public string Durum { get; set; }
        public List<int> KiralamaSureleri { get; set; }

        public Araba(string plaka, string marka, float kiralamaBedeli, string aracTipi)
        {
            this.Plaka = plaka;
            this.Marka = marka;
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aracTipi;
            this.Durum = "Galeride";
            this.KiralamaSureleri = new List<int>();
        }

        public int KiralanmaSayisi
        {
            get
            {
                return this.KiralamaSureleri.Count;
            }
        }

        public int ToplamKiralanmaSuresi
        {
            get
            {
                return this.KiralamaSureleri.Sum();
            }
        }
    }
}


