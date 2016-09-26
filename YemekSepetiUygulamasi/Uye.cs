using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulamasi
{
    class Uye
    {
        string adSoyad;

        public string AdSoyad
        {
            get { return adSoyad; }
            set { adSoyad = value; }
        }
        Cinsiyet cinsiyet;

        internal Cinsiyet Cinsiyet
        {
            get { return cinsiyet; }
            set { cinsiyet = value; }
        }
        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        string sifre;

        public string Sifre
        {
            get { return sifre; }
            set { sifre = value; }
        }
        ArrayList siparisList;

        public ArrayList SiparisList
        {
            get { return siparisList; }
            set { siparisList = value; }
        }
        int indirimKupon;

        public int IndirimKupon
        {
            get { return indirimKupon; }
            set { indirimKupon = value; }
        }
        bool kuponVarMi;

        public bool KuponVarMi
        {
            get { return kuponVarMi; }
            set { kuponVarMi = value; }
        }

        public Uye()
        {
            siparisList = new ArrayList();
        }
      

    }
}
