using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri_G024
{
    class Galeri
    {

        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamAracSayisi
        {
            get
            {
                return Arabalar.Count;
            }
        }
        public int KiradakiAracSayisi
        {
            get
            {
                int adet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        adet++;
                    }
                }
                return adet;
            }
        }
        public int GaleridekiAracSayisi {
            get
            {
                int adet = 0;
                adet = ToplamAracSayisi - KiradakiAracSayisi;
                return adet;
            }
        }
        public int ToplamAracKiralamaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (Araba a in this.Arabalar)
                {
                    toplam += a.ToplamKiralanmaSuresi;
                }
                return toplam;
            }
        }
        public int ToplamAracKiralamaAdedi {
            get
            {
                int adet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        adet++;
                    }
                }
                return adet;

            }
            set
            {

            }
        }
        public float Ciro {
            get
            {
                float toplam = 0;
                foreach (Araba x in Arabalar)
                {
                    toplam += x.KiralamaBedeli * x.kiraS;

                }
                return toplam;

            }
        }
        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, ARAC_TIPI aracTipi)
        {
            Araba a = new Araba(plaka, marka, kiralamaBedeli, aracTipi);

            this.Arabalar.Add(a);
        }


        public void ArabaKirala(string plaka)
        {
            Araba car = null;

            foreach (Araba x in this.Arabalar)
            {
                if (x.Plaka == plaka.ToUpper())
                {
                    car = x;
                    break;
                }
            }

            if (car != null)
            {
                if (car.Durum == DURUM.Galeride)
                {
                    Console.Write("Kiralama Süresi: ");
                    int sure = int.Parse(Console.ReadLine());
                    car.Durum = DURUM.Kirada;
                    car.ToplamKiralanmaSayisi++;
                    car.ToplamKiralanmaSuresi += sure;
                    car.KiralanmaSureleri.Add(sure);
                    Console.WriteLine("{0} Plakalı araç {1} saatliğine kiralandı.", plaka, sure);
                }
                else if (car.Durum == DURUM.Kirada)
                {
                    Console.WriteLine("Araç zaten kirada.");
                }
                
            }
            else if(car == null)
            {
                Console.WriteLine("Galeriye ait böyle bir araç yok.");
            }
        }

        public void ArabaTeslim(string plaka)
        {
            Araba car = null;
            foreach (Araba x in Arabalar)
            {
                if (x.Plaka == plaka.ToUpper())
                {
                    car = x;
                    break;
                }
            }
            car.Durum = DURUM.Galeride;
        }
        public void TümArabalariiListele()
        {
            
            foreach (Araba x in Arabalar)
            {
                
                Console.WriteLine(x.Plaka.PadRight(21,' ') + x.Marka.PadRight(17,' ')+ x.KiralamaBedeli.ToString().PadRight(20, ' ') + x.AracTipi.ToString().PadRight(26, ' ') + x.ToplamKiralanmaSayisi.ToString().PadRight(17, ' ')  + x.Durum);
            }


        }
        public void KiradakiArabalarListele()
        {

            foreach (Araba x in Arabalar)
            {

                if (x.Durum == DURUM.Kirada)
                {
                    Console.WriteLine(x.Plaka.PadRight(21, ' ') + x.Marka.PadRight(17, ' ') + x.KiralamaBedeli.ToString().PadRight(20,' ')  + x.AracTipi.ToString().PadRight(26, ' ') + x.ToplamKiralanmaSayisi.ToString().PadRight(17, ' ') + x.Durum);
                }
            }
        }
        public void MusaitArabalarListele()
        {
            foreach (Araba x in Arabalar)
            {
                if (x.Durum == DURUM.Galeride)
                {
                    Console.WriteLine(x.Plaka.PadRight(21, ' ') + x.Marka.PadRight(17, ' ') + x.KiralamaBedeli.ToString().PadRight(20, ' ')  + x.AracTipi.ToString().PadRight(26, ' ') + x.ToplamKiralanmaSayisi.ToString().PadRight(17, ' ') + x.Durum);
                }

            }



        }
    }
}


