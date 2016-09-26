using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulamasi
{
    class DBIslemleriImpl:DBIslemleri
    {
        
        public override void UyeEkle(Uye uye)
        {
            UyeList.Add(uye);
        }

        public override void UyeGuncelle(Uye uye)
        {
            
        }

        public override void UyeSil(Uye uye)
        {
            UyeList.Remove(uye);
        }

        public override void YemekEkle(Yemek yemek)
        {
            YemekList.Add(yemek);
        }

        public override void RestEkle(Restaurant rest)
        {
            RestList.Add(rest);
        }

        public override Restaurant RestaurantAra(string restAd)
        {
            foreach (Restaurant item in RestList)
            {
                if (item.Ad.Equals(restAd))
                {
                    return item;
                }
            }
            return null;
        }

        public override ArrayList YemekAra(string yemek)
        {
            ArrayList restYemekList=new ArrayList();
            
            for (int i = 0; i < RestList.Count; i++)
            {
                Restaurant rest=((Restaurant)RestList[i]);
                for (int j = 0; j <rest.YemekList.Count; j++)
                {
                    if (((Yemek)rest.YemekList[j]).Ad.Equals(yemek))
                    {
                        restYemekList.Add(rest.Ad);
                    }
                }
            }
            
            return restYemekList; 
        
        }
        public void YemekListele()
        {
            int sayac = 1;
            foreach (Yemek item in YemekList)
            {
                Console.WriteLine(sayac + "." + item.ToString());
                sayac++;
            }

        }
    }
}
