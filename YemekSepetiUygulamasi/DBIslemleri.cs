using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulamasi
{
    abstract class DBIslemleri
    {
      

        static ArrayList uyeList;

        public static ArrayList UyeList
        {
            get { return uyeList; }
            set { uyeList = value; }
        }
        static ArrayList yemekList;

        public static ArrayList YemekList
        {
            get { return yemekList; }
            set { yemekList = value; }
        }
        static ArrayList restList;

        public static ArrayList RestList
        {
            get { return restList; }
            set { restList = value; }
        }
        ArrayList restYemekList;

        public ArrayList RestYemekList
        {
            get { return restYemekList; }
            set { restYemekList = value; }
        }


        static DBIslemleri()
        {
            UyeList = new ArrayList();
            YemekList = new ArrayList();
            RestList = new ArrayList();
        }

        public abstract void UyeEkle(Uye uye);
        public abstract void UyeGuncelle(Uye uye);
        public abstract void UyeSil(Uye uye);
        public abstract void YemekEkle(Yemek yemek);
        public abstract void RestEkle(Restaurant rest);
        public abstract Restaurant RestaurantAra(string restAd);
        public abstract ArrayList YemekAra(string yemek);

    }
}
