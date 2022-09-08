using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri_G024
{
    class Araba
    {

        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaBedeli { get; set; }
        public int ToplamKiralanmaSayisi
        {

            get
            {
                return this.KiralanmaSureleri.Count;

            }
            set
            {

            }
        }
        public int ToplamKiralanmaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (int x in KiralanmaSureleri)
                {
                    toplam += x;
                }
                return toplam;
            }
            set
            {

            }
        }
        public int kiraS
        {
            get
            {
                int toplam = 0;
                foreach (int  x in KiralanmaSureleri)
                {
                    toplam = x;
                }
                return toplam;
            }
            set
            {

            }



        }
        public List<int> KiralanmaSureleri = new List<int>();
        public ARAC_TIPI AracTipi { get; set; }
        public DURUM Durum { get; set; }

        public Araba(string plaka, string marka, float kiralamaBedeli, ARAC_TIPI aracTipi)
        {
            this.Plaka = plaka.ToUpper();
            this.Marka = marka.ToUpper();
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aracTipi;
            this.Durum = DURUM.Galeride;
        }

    }

    public enum DURUM
    {
        Galeride,
        Kirada
    }

    public enum ARAC_TIPI
    {
        SUV,
        Sedan,
        Hatcback
    }
    

}
