using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulamasi
{
    interface ISystemKontrol
    {
        Uye IslemYapilanUye(ArrayList uyeList, string email);
        bool MailValidMi(ArrayList uyeList, string email);
        bool MailSyntaxUygunMu(string email);
        bool SifreSyntaxUygunMu(string sifre);
        bool SifrelerUyusuyorMu(string sifre, string sifreDogrulama); 
        bool SifreMailUyusuyorMu(Uye uye, string sifre);
    }
}
