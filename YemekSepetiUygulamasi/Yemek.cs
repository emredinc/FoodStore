using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulamasi
{
    class Yemek
    {
        string ad;

        public string Ad
        {
            get { return ad; }
            set { ad = value; }
        }
        double fiyat;

        public double Fiyat
        {
            get { return fiyat; }
            set { fiyat = value; }
        }
        bool kampanyaDurum;

        public bool KampanyaDurum
        {
            get { return kampanyaDurum; }
            set { kampanyaDurum = value; }
        }
        public override string ToString()
        {
            return "Ad: "+ad + " Fiyat: " + Fiyat;
        }
        
    }
}
