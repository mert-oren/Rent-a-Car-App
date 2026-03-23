using System;
namespace rent_a_car_app
{
    public class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamAracSayisi
        {
            get
            {
                return this.Arabalar.Count;
            }
        }

        public int KiradakiAracSayisi
        {
            get
            {
                int adet = 0;
                foreach (Araba item in Arabalar)
                {
                    if (item.Durum == "Kirada")
                    {
                        adet++;
                    }
                }
                return adet;
            }
        }

        public int GaleridekiAracSayisi
        {
            get
            {
                return Arabalar.Count - KiradakiAracSayisi;
            }
        }

        public int ToplamAracKiralamaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (Araba item in Arabalar)
                {
                    toplam += item.ToplamKiralanmaSuresi;
                }
                return toplam;
            }
        }

        public int ToplamAracKiralamaAdeti
        {
            get
            {
                int toplam = 0;
                foreach (Araba item in Arabalar)
                {
                    toplam += item.KiralanmaSayisi;
                }
                return toplam;
            }
        }

        public float Ciro
        {
            get
            {
                float arabaCiro = 0;
                float toplamCiro = 0;
                foreach (Araba item in Arabalar)
                {
                    arabaCiro = item.ToplamKiralanmaSuresi * item.KiralamaBedeli;
                    toplamCiro += arabaCiro;
                }
                return toplamCiro;
            }
        }

        public void ArabaKirala(string plaka, int sure)
        {
            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.Durum = "Kirada";
                a.KiralamaSureleri.Add(sure);
            }
        }

        public void ArabaTeslimAl(string plaka)
        {
            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.Durum = "Galeride";
            }
        }

        public void KiralamaIptal(string plaka)
        {
            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.KiralamaSureleri.RemoveAt(a.KiralamaSureleri.Count - 1);
                a.Durum = "Galeride";
            }
        }

        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, string aracTipi)
        {
            Araba a = new Araba(plaka, marka, kiralamaBedeli, aracTipi);
            this.Arabalar.Add(a);
        }


        public void ArabaSil(string plaka)
        {
            Araba a = null;
            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                this.Arabalar.Remove(a);
            }
        }

        public void DefaultArabaEkle()
        {
            Araba a1 = new Araba("34AA1234", "Audi", 50, "SUV");
            Arabalar.Add(a1);
            Araba a2 = new Araba("35CD2345", "BMW", 20, "Sedan");
            Arabalar.Add(a2);
        }
    }
}



