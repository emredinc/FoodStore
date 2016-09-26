using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulamasi
{
    interface IAyarlar
    {
        void ProfilGoruntule(Uye uye);
        void SiparisList(Uye uye);
        void IndirimKuponList(Uye uye);
    }
}
