using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulamasi
{
    struct Siparis
    {
        string restAd;

        public string RestAd
        {
            get { return restAd; }
            set { restAd = value; }
        }
        string yemekAd;

        public string YemekAd
        {
            get { return yemekAd; }
            set { yemekAd = value; }
        }
        double fiyat;

        public double Fiyat
        {
            get { return fiyat; }
            set { fiyat = value; }
        }
    }
}
