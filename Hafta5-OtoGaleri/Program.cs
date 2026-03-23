using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Hafta5_OtoGaleri;

class Program
{
    static Galeri OtoGaleri = new Galeri();

    static void Main(string[] args)
    {
        OtoGaleri.DefaultArabaEkle();
        Uygulama();
    }

    static void Uygulama()
    {
        Menu();
    }

    static void Menu()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("".PadLeft(30, '-'));
            Console.WriteLine("===== McFLY OTO KIRALAMA =====");
            Console.WriteLine("".PadLeft(30, '-'));
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("1. Araba Kirala (K)");
            Console.WriteLine("2. Araba Teslim Al (T)");
            Console.WriteLine("3. Kiradaki Arabalari Listele (R)");
            Console.WriteLine("4. Galerideki Arabalari Listele (M)");
            Console.WriteLine("5. Tüm Arabalari Listele (A)");
            Console.WriteLine("6. Kiralama Iptali (I)");
            Console.WriteLine("7. Araba Ekle (Y)");
            Console.WriteLine("8. Araba Sil (S)");
            Console.WriteLine("9. Bilgileri Göster (G)");
            Console.WriteLine();
            break;
        }
        Secim();
    }

    static void Secim()
    {
        int yanlisGirisSayaci = 10;
        bool secimDevam = true;

        while (secimDevam)
        {
            string secim = SecimAl();

            Console.ResetColor();
            Console.WriteLine();

            switch (secim)
            {
                case "1": case "K": ArabaKirala(); break;
                case "2": case "T": ArabaTeslimAl(); break;
                case "3": case "R": KiradakiArabalariListele(); break;
                case "4": case "M": GaleridekiArabalariListele(); break;
                case "5": case "A": TumArabalariListele(); break;
                case "6": case "I": KiralamaIptali(); break;
                case "7": case "Y": ArabaEkle(); break;
                case "8": case "S": ArabaSil(); break;
                case "9": case "G": BilgileriGoster(); break;
                default:

                    yanlisGirisSayaci--;

                    if (yanlisGirisSayaci > 0)
                    {
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Hatali Secim. Yeni bir secim yapmalisiniz.");

                        Console.WriteLine("Kalan giris hakki: " + yanlisGirisSayaci);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("10 hatali giris yaptiniz. Program sonlandiriliyor.");
                        secimDevam = false;
                    }
                    break;
            }
        }
    }

    static string SecimAl()
    {
        Console.Write("Seciminiz: ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        return Console.ReadLine();
    }

    static void ArabaKirala()
    {
        Console.WriteLine("ARABA KIRALAMA");
        Console.WriteLine("".PadRight(30, '='));
        Console.WriteLine();

        if (OtoGaleri.Arabalar.Count < 1)
        {
            Console.WriteLine("Oto galeride islem yapilacak bir araba yok.");
            return;
        }

        string plaka;
        while (true)
        {
            Console.Write("Kiralanacak arabanin plakasi: ");
            string giris = Console.ReadLine().ToUpper();

            if (giris == "X")
            {
                CikisMesaji();
                return;
            }

            if (PlakaGecerliMi(giris))
            {
                plaka = giris;
            }
            else
            {
                Console.WriteLine("Bu sekilde plaka girisi yapamazsiniz.");
                continue;
            }

            Araba kiralanacakAraba = null;

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    kiralanacakAraba = item;
                }
            }

            if (kiralanacakAraba == null)
            {
                Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                continue;
            }

            if (kiralanacakAraba.Durum == "Kirada")
            {
                Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                continue;
            }
            break;
        }

        while (true)
        {
            Console.Write("Kiralanma süresi: ");
            string sureGiris = Console.ReadLine().ToUpper();

            if (sureGiris == "X")
            {
                CikisMesaji();
                return;
            }

            int sure = 0;
            bool sayiMi = int.TryParse(sureGiris, out sure);

            if (sayiMi == false)
            {
                Console.WriteLine("Hatali giris. Bir sayi degeri giriniz.");
                continue;
            }

            OtoGaleri.ArabaKirala(plaka, sure);
            Console.WriteLine
            ("Araba kiralandi!");
            break;
        }
    }

    static void ArabaTeslimAl()
    {
        Console.WriteLine("ARABA TESLIM ALMA");
        Console.WriteLine("".PadRight(30, '='));
        Console.WriteLine();

        if (OtoGaleri.Arabalar.Count < 1)
        {
            Console.WriteLine("Oto galeride islem yapilacak bir araba yok.");
            return;
        }

        string plaka;
        while (true)
        {
            Console.Write("Teslim alinacak arabanin plakasi: ");
            string giris = Console.ReadLine().ToUpper();

            if (giris == "X")
            {
                CikisMesaji();
                return;
            }

            if (PlakaGecerliMi(giris))
            {
                plaka = giris;
            }
            else
            {
                Console.WriteLine("Bu sekilde plaka girisi yapamazsiniz.");
                continue;
            }

            Araba teslimAlinacakAraba = null;

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    teslimAlinacakAraba = item;
                }
            }

            if (teslimAlinacakAraba == null)
            {
                Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                continue;
            }

            if (teslimAlinacakAraba.Durum == "Galeride")
            {
                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                continue;
            }
            break;
        }

        OtoGaleri.ArabaTeslimAl(plaka);
        Console.WriteLine
        ("Araba galeride beklemeye alındı.");
    }

    static void KiradakiArabalariListele()
    {
        Console.WriteLine("KIRADAKI ARABALAR");
        Console.WriteLine("".PadRight(30, '='));
        Console.WriteLine();

        if (OtoGaleri.ToplamAracSayisi < 1)
        {
            Console.WriteLine("Otogaleride listelenecek araba yok. Araba ekleyin.");
            return;
        }

        if (OtoGaleri.KiradakiAracSayisi < 1)
        {
            Console.WriteLine("Listelenecek kirada araba yok. Hepsi galeride.");
            return;
        }

        BaslikYazdirma();

        foreach (Araba item in OtoGaleri.Arabalar)
        {
            if (item.Durum == "Kirada")
            {
                ArabaYazdirma(item);
            }
        }
        Console.WriteLine();
    }

    static void GaleridekiArabalariListele()
    {
        Console.WriteLine("GALERIDEKI ARABALAR");
        Console.WriteLine("".PadRight(30, '='));
        Console.WriteLine();

        if (OtoGaleri.ToplamAracSayisi < 1)
        {
            Console.WriteLine("Otogaleride listelenecek araba yok. Araba ekleyin.");
            return;
        }

        if (OtoGaleri.GaleridekiAracSayisi < 1)
        {
            Console.WriteLine("Galeride listelenecek araba yok. Hepsi kirada.");
            return;
        }

        BaslikYazdirma();

        foreach (Araba item in OtoGaleri.Arabalar)
        {
            if (item.Durum == "Galeride")
            {
                ArabaYazdirma(item);
            }
        }
        
        Console.WriteLine();
    }

    static void TumArabalariListele()
    {
        Console.WriteLine("OTO GALERIDEKI TUM ARABALAR");
        Console.WriteLine("".PadRight(30, '='));
        Console.WriteLine();

        if (OtoGaleri.Arabalar.Count < 1)
        {
            Console.WriteLine("Oto galeride listelenecek araba yok.");
            return;
        }

        BaslikYazdirma();
        foreach (var a in OtoGaleri.Arabalar)
        {
            ArabaYazdirma(a);
        }
    }

    static void KiralamaIptali()
    {
        Console.WriteLine("ARABA TESLIM ALMA");
        Console.WriteLine("".PadRight(30, '='));
        Console.WriteLine();

        if (OtoGaleri.Arabalar.Count < 1)
        {
            Console.WriteLine("Oto galeriye ait islem yapilacak bir araba yok.");
            return;
        }

        string plaka;
        while (true)
        {
            Console.Write("Kiralamasi iptal edilecek arabanin plakasi: ");
            string giris = Console.ReadLine().ToUpper();

            if (giris == "X")
            {
                CikisMesaji();
                return;
            }


            if (PlakaGecerliMi(giris))
            {
                plaka = giris;
            }
            else
            {
                Console.WriteLine("Bu sekilde plaka girisi yapamazsiniz.");
                continue;
            }

            Araba teslimAlinacakAraba = null;

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    teslimAlinacakAraba = item;
                }
            }

            if (teslimAlinacakAraba == null)
            {
                Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                continue;
            }

            if (teslimAlinacakAraba.Durum == "Galeride")
            {
                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                continue;
            }
            break;
        }

        OtoGaleri.KiralamaIptal(plaka);
        Console.WriteLine("İptal gerçekleştirildi.");
    }

    static void ArabaEkle()
    {
        Console.WriteLine("ARABA EKLEME");
        Console.WriteLine("".PadRight(30, '='));
        Console.WriteLine();

        Console.WriteLine("Eklenecek arabanin");

        //Plaka sorgu
        string plaka;
        while (true)
        {
            Console.Write("Plaka: ");
            string plakaGiris = Console.ReadLine().ToUpper();

            if (plakaGiris == "X")
            {
                CikisMesaji();
                return;
            }

            if (PlakaGecerliMi(plakaGiris))
            {
                plaka = plakaGiris;
            }
            else
            {
                Console.WriteLine("Bu sekilde plaka girisi yapamazsiniz.");
                continue;
            }
            bool geldiMi = false;

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin.");
                    geldiMi = true;
                    break;
                }
            }

            if (!geldiMi)
            {
                break;
            }
        }

        //Model sorgu
        string model;
        while (true)
        {
            Console.Write("Model: ");
            string modelGiris = Console.ReadLine().ToUpper();

            if (modelGiris == "X")
            {
                CikisMesaji();
                return;
            }

            int modelSayi = 0;
            bool modelSayiMi = int.TryParse(modelGiris, out modelSayi);

            if (!modelSayiMi)
            {
                model = modelGiris;
                break;
            }
            else
            {
                Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                continue;

            }
        }

        //Bedel sorgu
        float bedel;
        while (true)
        {
            Console.Write("Kiralama Bedeli: ");
            string bedelGiris = Console.ReadLine().ToUpper();

            if (bedelGiris == "X")
            {
                CikisMesaji();
                return;
            }

            bool bedelSayiMi = float.TryParse(bedelGiris, out bedel);

            if (bedelSayiMi)
            {
                break;
            }
            else
            {
                Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                continue;
            }
        }

        //Araba tipi

        Console.WriteLine("Araba tipi: ");
        Console.WriteLine("SUV icin 1");
        Console.WriteLine("Hatchback icin 2");
        Console.WriteLine("Sedan icin 3");

        string tip;
        while (true)
        {
            Console.Write("Araba tipi: ");
            string tipGiris = Console.ReadLine();

            if (tipGiris == "X")
            {
                CikisMesaji();
                return;
            }

            if (tipGiris == "1")
            {
                tip = "SUV";
                break;
            }
            else if (tipGiris == "2")
            {
                tip = "HATCHBACK";
                break;
            }
            else if (tipGiris == "3")
            {
                tip = "SEDAN";
                break;
            }
            else
            {
                Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                continue;
            }
        }

        OtoGaleri.ArabaEkle(plaka, model, bedel, tip);
        Console.WriteLine("Araba başarılı bir şekilde eklendi.");
    }

    static void ArabaSil()
    {
        Console.WriteLine("ARABA SIL");
        Console.WriteLine("".PadRight(30, '='));
        Console.WriteLine();

        if (OtoGaleri.Arabalar.Count < 1)
        {
            Console.WriteLine("Oto galeride islem yapilacak bir araba yok.");
            return;
        }

        string plaka;
        while (true)
        {
            Console.Write("Kiralamasi iptal edilecek arabanin plakasi: ");
            string giris = Console.ReadLine().ToUpper();

            if (giris == "X")
            {
                CikisMesaji();
                return;
            }


            if (PlakaGecerliMi(giris))
            {
                plaka = giris;
            }
            else
            {
                Console.WriteLine("Bu sekilde plaka girisi yapamazsiniz.");
                continue;
            }

            Araba teslimAlinacakAraba = null;

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    teslimAlinacakAraba = item;
                }
            }

            if (teslimAlinacakAraba == null)
            {
                Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                continue;
            }

            if (teslimAlinacakAraba.Durum == "Kirada")
            {
                Console.WriteLine("Araba kirada oldugu için silme islemi gerceklestirilemedi.");
                continue;
            }
            break;
        }

        OtoGaleri.ArabaSil(plaka);
        Console.WriteLine("Araba silindi.");
    }

    static void BilgileriGoster()
    {
        Console.WriteLine("GALERI BILGILERI");
        Console.WriteLine("".PadRight(30, '='));
        Console.WriteLine();

        Console.WriteLine("Toplam araba sayisi: " + OtoGaleri.ToplamAracSayisi);
        Console.WriteLine("Kiradaki araba sayisi: " + OtoGaleri.KiradakiAracSayisi);
        Console.WriteLine("Bekleyen araba sayisi: " + OtoGaleri.GaleridekiAracSayisi);
        Console.WriteLine("Toplam araba kiralama süresi: " + OtoGaleri.ToplamAracKiralamaSuresi);
        Console.WriteLine("Toplam kiralama adedi: " + OtoGaleri.KiradakiAracSayisi);
        Console.WriteLine("Ciro : " + OtoGaleri.Ciro);
    }

    static void CikisMesaji()
    {
        Console.WriteLine("Ana menüye dönülüyor.");
    }

    static bool PlakaGecerliMi(string giris)
    {
        string pattern = @"^[0-9]{2}[A-Z]{1,3}[0-9]{2,4}$";
        return Regex.IsMatch(giris.ToUpper(), pattern);
    }

    static void ArabaYazdirma(Araba a)
    {
        Console.WriteLine();
        Console.WriteLine
        (
             a.Plaka.PadRight(15).ToUpper() +
             a.Marka.PadRight(15).ToUpper() +
             a.KiralamaBedeli.ToString().PadRight(15) +
             a.AracTipi.PadRight(15).ToUpper() +
             a.KiralanmaSayisi.ToString().PadRight(15) +
             a.Durum.PadRight(15).ToUpper()
        );
    }

    static void BaslikYazdirma()
    {
        Console.WriteLine();
        Console.WriteLine
            (
        "Plaka".PadRight(15) +
        "Marka".PadRight(15) +
        "K.Bedeli".PadRight(15) +
        "Araba Tipi".PadRight(15) +
        "K.Sayisi".PadRight(15) +
        "Durum".PadRight(15)
            );
        Console.WriteLine(new string('-', 90));
    }
}

 
 
 
 