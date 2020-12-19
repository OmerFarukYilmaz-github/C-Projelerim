using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Ödevi
{
    class Calisan
    {
        protected virtual string Ad {get;set;}
        protected virtual string Soyad { get; set; }
        protected decimal Maas { get; set; }
        protected int IzınGunu { get; set; }

        //FONKİSYONLAR

       /* public override string ToString()
        {
            return Ad + Soyad;
        }
       */

    }
}
