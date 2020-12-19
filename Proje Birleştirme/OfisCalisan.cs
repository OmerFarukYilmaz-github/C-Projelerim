using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Ödevi
{
    class OfisCalisan : Calisan
    {
        private string Gorev { get; set; }
        //Fonksiyonlar
        public void ofisCalisanEkle(string ofisCalisanAd, string ofisCalisanSoyad, string
              ofisCalisanGorev, int ofisCalisanIzin, decimal ofisCalisanMaas)
        {
            this.Ad = ofisCalisanAd;
            this.Soyad = ofisCalisanSoyad;
            this.Gorev = ofisCalisanGorev;
            this.IzınGunu = ofisCalisanIzin;
            this.Maas = ofisCalisanMaas;
        }
        public string ofisCalisanListele(string ofisCalisanAd, string ofisCalisanSoyad, string
            ofisCalisanGorev, int ofisCalisanIzin, decimal ofisCalisanMaas)
        {
            return this.Ad + " " + this.Soyad + " " + this.Gorev + " " + this.IzınGunu + " " + this.Maas;
        }

    }
}


