using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulamasi
{
    class SystemControlImpl:ISystemKontrol
    {
        public bool MailValidMi(ArrayList uyeList, string email)
        {
            //daha önceden bu mail adresi ile kayıt yapılmış mı
            foreach (Uye item in uyeList)
            {
                if (item.Email.Equals(email))
                {
                    return false;
                }
            }
            return true;
        }

        public Uye IslemYapilanUye(ArrayList uyeList, string email)
        {
            foreach (Uye item in uyeList)
            {
                if (item.Email.Equals(email))
                {
                    return item;
                }
            }
            return null;
        }

        public bool MailSyntaxUygunMu(string email)
        {
            //gmail olması ve bir mail adresi olması
            //@gmail.com var mı bakılacak
            if (email.Contains("@gmail.com"))
            {
                return true;  //syntax uygun
            }
            return false;  //syntax uygun değil
        }

        public bool SifreSyntaxUygunMu(string sifre)
        {
            //şifrenin içerisinde en az bir rakam olmalı
            int cikti;
            for (int i = 0; i < sifre.Length; i++)
            {
                if (int.TryParse(sifre[i].ToString(), out cikti))
                {
                    return true;
                }
            }
            return false;
        }

        public bool SifrelerUyusuyorMu(string sifre, string sifreDogrulama)
        {
            if (sifre.Equals(sifreDogrulama))
            {
                return true;
            }
            return false;
        }

        public bool SifreMailUyusuyorMu(Uye uye, string sifre)
        {
            if (uye.Sifre.Equals(sifre))
            {
                return true;
            }
            return false;
        }
    }
}
