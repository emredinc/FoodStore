using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulamasi
{
    class Restaurant:RestaurantOzellikleri
    {
        string ad;
        DateTime kurTarih;

        public override string Ad
        {
            get
            {
                return ad;
            }
            set
            {
                ad = value;
            }
        }

        public override DateTime KurulusTarihi
        {
            get
            {
                return kurTarih;
            }
            set
            {
                kurTarih = value;
            }
        }

        public override ArrayList YemekList
        {
            get;
            set;
        }

        public Restaurant()
        {
            YemekList = new ArrayList();
        }

        public Restaurant(string ad, DateTime kurTarih)
        {
            Ad = ad;
            KurulusTarihi = kurTarih;
            
        }

        public override void SiparisVer()
        {
            throw new NotImplementedException();
        }
        int sayac = 1;
        public override void RestYemekList()
        {
            
            Console.WriteLine("_____{0} Restaurantı Yemek Listesi_____", Ad);
            foreach (Yemek item in YemekList)
            {
                Console.WriteLine(sayac + "." + item.ToString());
                sayac++;
            }
        }
        
       
    }
}
