using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulamasi
{
    abstract class RestaurantOzellikleri
    {
        string ad;

        public abstract string Ad
        {
            get;
            set;
        }
        DateTime kurulusTarihi;

        public abstract DateTime KurulusTarihi
        {
            get;
            set;
        }
        ArrayList yemekList;

        public abstract ArrayList YemekList
        {
            get;
            set;
        }
        public abstract void SiparisVer();
        public virtual void KampanyaliUrunTanimla(ArrayList secilenYemekler)
        {            
        }
        public abstract void RestYemekList();
    }
}
