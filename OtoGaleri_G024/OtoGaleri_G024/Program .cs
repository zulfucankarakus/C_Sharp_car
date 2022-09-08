using System;
using System.Collections.Generic;

namespace OtoGaleri_G024
{
    class Program
    {
        static Galeri OtoGaleri = new Galeri();

        static void Main(string[] args)
        {
            Uygulama();
        }
        static void Uygulama()
        {
            SahteVeriGir();
            Menu();
            while (true)
            {
                switch (SecimAl().ToUpper())
                {
                    case "1":
                    case "K":
                        ArabaKirala();
                        break;
                    case "2":
                    case "T":
                        ArabaTeslimAl();
                        break;
                    case "3":
                    case "R":
                        KiradakiArabalariListele();
                        break;
                    case "4":
                    case "M":
                        MüsaitArabalariListele();
                        break;
                    case "5":
                    case "A":
                        TümArabalariListele();
                        break;
                    case "6":
                    case "I":
                        KiralamaIptali();
                        break;
                    case "7":
                    case "Y":
                        ArabaEkle();
                        break;
                    case "8":
                    case "S":
                        ArabaSil();
                        break;
                    case "9":
                    case "G":
                        BilgileriGoster();
                        break;
                    default: Console.WriteLine();
                        break;
                }
            }
        }
        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon ");
            Console.WriteLine("1 - Araba Kirala(K)"); //
            Console.WriteLine("2 - Araba Teslim Al(T)"); //
            Console.WriteLine("3 - Kiradaki arabaları listele(R)"); // 
            Console.WriteLine("4 - Müsait arabaları listele(M)"); //
            Console.WriteLine("5 - Tüm arabaları listele(A)"); //
            Console.WriteLine("6 - Kiralama İptali(I)"); //
            Console.WriteLine("7 - Yeni araba Ekle(Y)"); //
            Console.WriteLine("8 - Araba sil(S)"); //
            Console.WriteLine("9 - Bilgileri göster(G)"); //
    
        }
        static void ArabaKirala()
        {
            Console.WriteLine("-Araç Kirala-");
            while (true)
            {
                basadon:
                Console.Write("Kiralanacak aracın plakası: ");
                string plaka = Console.ReadLine().ToUpper();
                if (PlakaKontrol(plaka) == true)
                {
                    OtoGaleri.ArabaKirala(plaka);
                    break;
                }
                else
                {
                    Console.WriteLine("Giriş Tanımlanamadı. Tekrar Deneyin.");
                    goto basadon;
                    break;
                }
                break;
            }
        }
        static void ArabaTeslimAl()
        {
            Console.WriteLine("-Araba Teslim-");
        basadon:
            Console.Write("Teslim Edilecek Arabanın Plakası: ");
            string plaka = Console.ReadLine().ToUpper();
            bool galeridevarmı = false;
            Araba car = null;
            foreach (Araba x in OtoGaleri.Arabalar)
            {
                if (x.Plaka == plaka)
                {
                    galeridevarmı = true;
                    car = x;
                    break;
                }
            }
            if (galeridevarmı == false&&PlakaKontrol(plaka)==true)
            {
                Console.WriteLine("Galeriye ait böyle bir araç yok.");
            }
            if (car != null)
            {
                if (car.Durum == DURUM.Galeride)
                {
                    Console.WriteLine("Araç zaten galeride. ");
                    goto basadon;
                }
            }

            if (PlakaKontrol(plaka) == true && galeridevarmı == true)
            {
                OtoGaleri.ArabaTeslim(plaka);
                Console.WriteLine("Araç galeride beklemeye alındı.");

            }
            if (PlakaKontrol(plaka)==false)
            {
                Console.WriteLine("Giriş Tanımlanamadı. Tekrar Deneyin.");
                goto basadon;
            }
        }
        static void KiradakiArabalariListele()
        {
            if (OtoGaleri.Arabalar.Count == 0)
            {
                Console.WriteLine("Kirada Araç yoktur.");
            }
            else if (OtoGaleri.Arabalar.Count > 0)
            {
                Console.WriteLine("-Kiradaki Araçlar-");
                Console.WriteLine("Plaka                Marka        Kiralama Bedeli        Araç Tipi           Kiralanma Sayısı         Durum");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                OtoGaleri.KiradakiArabalarListele();
            }
        }
        static void MüsaitArabalariListele()
        {
            Console.WriteLine("-Müsait Araçlar-");
            Console.WriteLine("Plaka                Marka        Kiralama Bedeli        Araç Tipi           Kiralanma Sayısı         Durum");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            OtoGaleri.MusaitArabalarListele();
        }
        static void TümArabalariListele()
        {
            if (OtoGaleri.Arabalar.Count == 0)
            {
                Console.WriteLine("Galeride Araç yoktur.");
            }
            else if (OtoGaleri.Arabalar.Count > 0)
            {
                Console.WriteLine("-Tüm Araçlar-");
                Console.WriteLine("Plaka                Marka        Kiralama Bedeli        Araç Tipi           Kiralanma Sayısı         Durum");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                OtoGaleri.TümArabalariiListele();
            }
        }
        static void KiralamaIptali()
        {
            Console.WriteLine("-Kiralama İptali-");
                basadon:
            Console.Write("Kiralaması iptal edilecek aracın plakası: ");
            string plaka = Console.ReadLine().ToUpper();
            if (PlakaKontrol(plaka) == true)
            {
                if (OtoGaleri.Arabalar.Count == 0)
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araç yok.");
                    goto basadon;
                }
                else if (OtoGaleri.Arabalar.Count > 0)
                {
                    Araba car = null;
                    foreach (Araba x in OtoGaleri.Arabalar)
                    {
                        if (x.Plaka == plaka)
                        {
                            car = x;
                            break;
                        }
                    }
                    if (car == null)
                    {
                        Console.WriteLine("Galeriye ait böyle bir araç yok.");
                        goto basadon;
                    }
                    else if (car != null)
                    {
                        if (car.Durum == DURUM.Galeride)
                        {
                            Console.WriteLine("Hatalı giriş yapıldı. Araç zaten galeride. ");
                            goto basadon;
                        }
                        else
                        {
                            Console.WriteLine("İptal gerçekleştirildi.");
                            car.Durum = DURUM.Galeride;
                            car.KiralanmaSureleri.RemoveAt(car.KiralanmaSureleri.Count - 1);
                        }
                    }
                }
            }
            else if (PlakaKontrol(plaka) == false)
            {
                Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin. ");
                goto basadon;
            }
        }
        static void ArabaEkle()
        {
        basadon:
            Console.WriteLine("-Yeni Araç Ekle-");
            Console.Write("Plaka: ");
            string plaka = Console.ReadLine().ToUpper();
            bool plakavarmı = false;
            foreach (Araba x in OtoGaleri.Arabalar)
            {
                if (x.Plaka != plaka)
                {
                    plakavarmı = true;
                }
                else
                {
                    Console.WriteLine("Aynı plakada araç mevcut. Girdiğiniz plakayı kontrol edin.");
                    goto basadon;
                }
            }
            if (PlakaKontrol(plaka) == true && plakavarmı == true)
            {
                Console.Write("Marka: ");
                string marka = Console.ReadLine();
                Console.Write("Kiralama Bedeli: ");
                float kBedeli = float.Parse(Console.ReadLine());
                while (true)
                {
                    Console.WriteLine("Araç Tipleri: ");
                    Console.WriteLine("-SUV için 1 ");
                    Console.WriteLine("-HatchBack için 2 ");
                    Console.WriteLine("-Sedan için 3 ");
                    Console.Write("Araç Tipi: ");
                    string secim = Console.ReadLine();
                    switch (secim)
                    {
                        case "1":
                            OtoGaleri.ArabaEkle(plaka, marka, kBedeli, ARAC_TIPI.SUV);
                            break;
                        case "2":
                            OtoGaleri.ArabaEkle(plaka, marka, kBedeli, ARAC_TIPI.Hatcback);
                            break;
                        case "3":
                            OtoGaleri.ArabaEkle(plaka, marka, kBedeli, ARAC_TIPI.Sedan);
                            break;
                        default:
                            Console.WriteLine("Hatalı tuşladınız. Tekrar Deneyin.");
                            continue;
                    }
                    Console.WriteLine("Araç başarılı bir şekilde eklendi.");
                    break;
                }

            }
            else
            {
                Console.WriteLine("Bu sekilde plaka girisi yapamazsiniz. Tekrar deneyin.");
                goto basadon;
            }

        }
        static void ArabaSil()
        {
            Console.WriteLine("-Araba Sil -");
            basadon:
            Console.Write("Silinmek istenen araç plakasını girin: ");
            string plaka = Console.ReadLine().ToUpper();
            if (PlakaKontrol(plaka) == true)
            {
                Araba car = null;
                foreach (Araba x in OtoGaleri.Arabalar)
                {
                    if (x.Plaka == plaka)
                    {
                        car = x;
                        break;
                    }
                }
                if (car != null)
                {
                    if (car.Durum == DURUM.Kirada)
                    {
                        Console.WriteLine("Araç kirada olduğu için silme işlemi gerçekleştirilemedi.");
                        goto basadon;
                    }
                    else
                    {
                        Console.WriteLine("Araç silindi.");
                        OtoGaleri.Arabalar.Remove(car);

                    }
                }
                else
                {
                    Console.WriteLine("Silinecek araç bulunamadi.");
                    goto basadon;
                }


            }
            else if (PlakaKontrol(plaka) == false)
            {
                Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                goto basadon;
            }

        }
        static void BilgileriGoster()
        {

            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine("Toplam Araç Sayısı: " + OtoGaleri.ToplamAracSayisi);
            Console.WriteLine("Kiradaki Araç Sayısı: " + OtoGaleri.KiradakiAracSayisi);
            Console.WriteLine("Bekleyen Araç Sayısı: " + OtoGaleri.GaleridekiAracSayisi);
            Console.WriteLine("Toplam araç kiralama süresi: " + OtoGaleri.ToplamAracKiralamaSuresi);
            Console.WriteLine("Toplam araç kiralama adedi: " + OtoGaleri.ToplamAracKiralamaAdedi);
            Console.WriteLine("Ciro: " + OtoGaleri.Ciro);


        }
        static void SahteVeriGir()
        {
            OtoGaleri.ArabaEkle("12aaa121", "Opel", 120, ARAC_TIPI.Sedan);
            OtoGaleri.ArabaEkle("45asd454", "Ford", 150, ARAC_TIPI.SUV);
            OtoGaleri.ArabaEkle("34la2001", "Bajaj", 100, ARAC_TIPI.Hatcback);
            OtoGaleri.ArabaEkle("01lo1290", "Renault", 150, ARAC_TIPI.Sedan);

        }
        static string SecimAl()
        {
            Console.Write("Seçiminiz: ");
            return Console.ReadLine();
        }

        static bool PlakaKontrol(string plaka)
        {
            int a;
            if (plaka.Length == 6 || plaka.Length == 7 || plaka.Length == 8)
            {
                string gecici = plaka.Substring(0, 2);
                if (int.TryParse(gecici, out a) == true)
                {
                    gecici = plaka.Substring(2, 3);
                    if (int.TryParse(gecici, out a) == false)
                    {
                        gecici = plaka.Substring(6, 1);
                        if (int.TryParse(gecici, out a) == true)
                        {
                            return true;
                        }
                    }
                }
            }
            else if (plaka.Length < 6 || plaka.Length > 8)
            {
                return false;
            }
            return false;
        }

    }
}
