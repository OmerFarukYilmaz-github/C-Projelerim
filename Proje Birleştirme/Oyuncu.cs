using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Ödevi
{
    class Oyuncu : Calisan
    {
        private string ProjeIsim { get; set; }
        private DateTime ProjeBaslangic { get; set; }
        private DateTime ProjeBitis { get; set; }
        private string UzmanlikAlani { get; set; }

        //Fonksiyonlar
        public void OyuncuEkle(string ad, string soyad, decimal maas, string uzmanlikAlani)
        {
            this.Ad = ad;
            this.Soyad = soyad;
            this.UzmanlikAlani = uzmanlikAlani;
            this.Maas = Convert.ToInt32(maas);

        }

    }
}
