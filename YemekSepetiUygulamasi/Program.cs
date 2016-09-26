using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YemekSepetiUygulamasi
{
    class Program
    {
        static string secim;
        static DBIslemleriImpl db = new DBIslemleriImpl();
        static SystemControlImpl control = new SystemControlImpl();
        static string karar;
        static Uye ilgiliUye;
        static double toplamTutar = 0;
        static bool girisDurum = false;
      
     
        static void Main(string[] args)
        {
  
            Menu();
            
        }
       
   
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1.Kaydol\n2.Üye Girişi\n3.Tanımlamalar\n4.Çıkış\n");
            Console.WriteLine("Lütfen seçim yapın");
            secim = Console.ReadLine();
            switch (secim)
            {
                case "1": KullaniciBilgiAl(); break;
                case "2": UyeGiris(); break;
                case "3": RestYemekMenu(); break;
                case "4": Environment.Exit(0); break;
                default: Console.WriteLine("Hatalı Giriş!");
                    break;
            }
        }
        static void Menu2()
        {
            try
            {
             Console.Clear();
            Console.WriteLine("1. Sipariş Hazırla\n2. Profil Yönetimi\n3. Sipariş Tamamla\n4 .Çıkış");
            Console.WriteLine("Lütfen seçim yapın");
            secim = Console.ReadLine();
            switch (secim)
            {
                case "1": AramaMenu(); break;
                case "2": ProfilYönetimi(); break;
                case "3": SiparisTamamla(); break;
                case "4": girisDurum=false;
                     Thread.Sleep(750);
                Menu();
                    break;
                default: 
                    break;
            }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                Thread.Sleep(750);
                Menu();
            }
            
        }

        static void SiparisTamamla()
        {
           
            try
            { double fatura;
                if (ilgiliUye.SiparisList!=null)
                {
                    foreach (var item in ilgiliUye.SiparisList)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine(ilgiliUye.IndirimKupon+" TL İndirim Kuponu Var Kullanmak İster misin(E - H)");
                    secim = Console.ReadLine().ToUpper();
                    
                    if (secim=="E")
                    {
                       fatura = toplamTutar - ilgiliUye.IndirimKupon;
                       Console.Write("Toplam: "+fatura);
                       ilgiliUye.IndirimKupon = 0;
                    }
                    else
                    {
                        Console.Write("Toplam: "+toplamTutar);
                        Thread.Sleep(750);
                Menu();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Sipariş Verilmedi");
                    Thread.Sleep(750);
                Menu();
                }
            }
            catch (Exception)
            {
                 Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                Thread.Sleep(750);
                Menu();
            }
        }
    

     
        private static void ProfilYönetimi()
        {
            try
            {
                Console.Clear();
            Console.WriteLine("1. Profil Güncelle\n2. Profili Sil");
            secim = Console.ReadLine();
            switch (secim)
            {
                case "1":ProfilGuncelle() ; break;
                case "2":ProfilSil() ; break;
                default: Console.WriteLine("Hatalı Seçim Menu Yönlendiriliyor");
                    Thread.Sleep(500);
                Menu();
                    break;
            }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                Thread.Sleep(500);
                Menu();
                
            }
            
        }
        static void ProfilSil()
        {
            try
            {
                Console.WriteLine("Profil Silinsin Mi? (E - H)");
                secim = Console.ReadLine().ToUpper();
                if (secim=="E")
                {
                    db.UyeSil(ilgiliUye);
                    girisDurum = false;
                    Console.WriteLine("Profil Silindi ");
                Thread.Sleep(500);
                Menu();
                }
            }
            catch (Exception)
            {
               Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                
            }
        }
        private static void ProfilGuncelle()
        {
            try
            {
            Console.Write("Şifre Gir: ");
            string sifre = Console.ReadLine();
            if (control.SifreSyntaxUygunMu(sifre))
            {
                Console.Write("Şifreyi Tekrar Gir: ");
                string sifre2 =Console.ReadLine();
                if (control.SifrelerUyusuyorMu(sifre,sifre2))
                {
                    for (int i = 0; i < DBIslemleri.UyeList.Count; i++)
            
                    {
                        Uye uye = (Uye)DBIslemleri.UyeList[i];
                        if (ilgiliUye.Email == uye.Email) 
                        {
                            ((Uye)DBIslemleri.UyeList[i]).Sifre = sifre;
                            Console.WriteLine("Şifre Güncelleme Yapıldı Yeniden Giriş Yapın");
                            girisDurum = false;
                            Thread.Sleep(500);
                            Menu(); 
                            break;
                        }
                    }
                }
            }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                Thread.Sleep(500);
                Menu();
            }
        
           
            
            
        }
        static void UyeGiris()
        {
            try
            {

                Console.Write("Mail : ");
            string mail = Console.ReadLine();
            Console.Write("Şifre: ");
            string sifre = Console.ReadLine();
            ilgiliUye = control.IslemYapilanUye(DBIslemleri.UyeList, mail);
            if (ilgiliUye != null)
            {
                if (control.SifreMailUyusuyorMu(ilgiliUye, sifre))
                {
                    Console.WriteLine(ilgiliUye.AdSoyad + " hoşgeldiniz!");
                    girisDurum = true;
                    Menu();
                }
                else
                {
                    Console.Clear();
                    AltMenu();
                }
            }
            else
            {
                Console.WriteLine("Kayıt Bulunamadı Kaydolmak İster misiniz ? (E - H)");
                secim = Console.ReadLine().ToUpper();
                if (secim=="E")
                {
                    Menu();
                }
                else
                {
                    Environment.Exit(0);
                }

            }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                Thread.Sleep(500);
                Menu();

            }
            
           
            
        }
        static void KullaniciBilgiAl()
        {
            try
            {
            Uye uye = new Uye();
            Console.WriteLine("Ad soyad girin");
            string adSoyad = Console.ReadLine();
            Console.WriteLine("Cinsiyet girin ");
            Cinsiyet cinsiyet = (Cinsiyet) Enum.Parse(typeof(Cinsiyet),Console.ReadLine(),true);
            Console.WriteLine("gmail adresi girin");
            string mail = Console.ReadLine();
            if (control.MailSyntaxUygunMu(mail))
            {
                if (control.MailValidMi(DBIslemleri.UyeList, mail))
                {
                    
                    Console.WriteLine("Şifre girin");
                    string sifre = Console.ReadLine();
                    if (control.SifreSyntaxUygunMu(sifre))
                    {
                        Console.WriteLine("Doğrulama şifresini girin");
                        string dSifre = Console.ReadLine();
                        if (control.SifrelerUyusuyorMu(sifre, dSifre))
                        {
                            uye.AdSoyad = adSoyad;
                            uye.Cinsiyet = cinsiyet;
                            uye.Email = mail;
                            uye.Sifre = sifre;
                            db.UyeEkle(uye); 
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine("Şifreler uyuşmuyor!"); 
                            Thread.Sleep(500); 
                            Menu();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bu adres daha önceden kullanılmıştır");
                    Menu();
                }
            }
            else
            {
                Console.WriteLine("Lütfen bir gmail adresi girin!"); 
                Thread.Sleep(500); 
                Menu();
            }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                Thread.Sleep(500);
                Menu();
            }
            
        }
    

      
        static void AramaMenu()
        {
            try
            {
            Console.WriteLine("1.Restauranta göre arama\n2.Yemek adına göre arama");
            secim = Console.ReadLine();
            switch (secim)
            {
                case "1": RestAra(); break;
                case "2": YemekArama(); break;
                default: Console.WriteLine("Hatalı Seçim Menu Yönlendiriliyor");
                Thread.Sleep(500);
                Menu();
                    break;
            }
            }
            catch (Exception )
            {
                Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                Thread.Sleep(500);
                Menu();
                
            }
            
        }
        static void YemekArama()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---- Yemek Arama");
                
                Console.WriteLine("Yemek Ad: ");
                string yemek = Console.ReadLine();
                if (DBIslemleri.YemekList == null)
                {
                    Console.WriteLine("Yemek Bulunamadı");
                }
                else
                {
                    foreach (var item in db.YemekAra(yemek))
                    {
                        Console.WriteLine(item);
                    }
                    Console.Write("Restorana Adı Gir: ");

                    string restAd = Console.ReadLine().ToUpper();
                    
                    for (int i = 0; i < DBIslemleri.RestList.Count; i++)
                    {
                        Restaurant rest = ((Restaurant)DBIslemleriImpl.RestList[i]);
                        if (restAd==rest.Ad)
                        {
                            for (int j = 0; i <rest.YemekList.Count ; i++)
			
                            {
                                Yemek ymk = (Yemek)rest.YemekList[j];
                                if (yemek==ymk.Ad)
                                {
                                    ilgiliUye.SiparisList.Add(ymk.Ad);
                                    toplamTutar += ymk.Fiyat;
                                    break;
                                }
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Restoran Adı Yanlış Girildi "); break;
                        }
                    }
                    
                    
                }

                AramaMenu();
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                Thread.Sleep(500);
                Menu();
            }
            
        }
        static void RestAra()
        {
            try
            {
            Console.Clear();
            Console.WriteLine("---- Restoranlarda Yemek Arama");
            Console.WriteLine("Restaurant adını girin");
            string restAd = Console.ReadLine().ToUpper();
            Restaurant rest = db.RestaurantAra(restAd);
            if (rest != null)
            {
                rest.RestYemekList();
                Console.WriteLine("Siparişiniz beklenmektedir, lütfen yemek seçimi yapınız");
                do
                {
                    int yemekIndex = int.Parse(Console.ReadLine());
                    if (rest.YemekList.Count >= yemekIndex)
                    {
                        ilgiliUye.SiparisList.Add(rest.YemekList[yemekIndex-1]);
                        toplamTutar += ((Yemek) rest.YemekList[yemekIndex - 1]).Fiyat;
                    }
                    else
                    {
                        Console.WriteLine("Listede olmayan bir yemek girdiniz");
                    }
                    Console.WriteLine("Devam mı (E/H)");
                    karar = Console.ReadLine().ToUpper();
                } while (karar.Equals("E"));
                if (ilgiliUye.KuponVarMi)
                {
                    Console.WriteLine("İndirim kuponunuzu kullanmak ister misiniz? (E/H)");
                    karar = Console.ReadLine();
                    if (karar.Equals("E"))
                    {
                        toplamTutar = toplamTutar - ilgiliUye.IndirimKupon;
                    }
                }
                Menu();
                
            }
            else
            {
                Console.WriteLine("Restoran Bulunamadı");
                Thread.Sleep(750);
                Menu();
            }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                
                Menu();
            }
            
        }
        static void AltMenu()
        {
            try
            {

                Console.Clear();
                Console.WriteLine("1.Kaydol\n2.Şifremi unuttum\n");
            secim = Console.ReadLine();
            switch (secim)
            {
                case "1": KullaniciBilgiAl(); break;
                case "2": Console.Write("Şifreniz: " + ilgiliUye.Sifre);
                    Console.WriteLine("Kullanıcı Giriş İçin (E - H)");
                    secim = Console.ReadLine().ToUpper();
                    if (secim=="E")
                    {
                        Menu();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                    break;
                default:
                    break;
            }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                Thread.Sleep(500);
                Menu();
            }
            
        }
        
        static void RestYemekMenu()
        {
            try
            {
            Console.Clear();
            Console.WriteLine("1.Restaurant Tanımla\n2.Yemek Tanımla\n3. Restoran Yemek Listesi Hazırla");
            Console.WriteLine("Lütfen seçim yapın");
            secim = Console.ReadLine();
            string restAd;
            switch (secim)
            {
                case "1": Console.WriteLine("Restaurant adı girin");
                          restAd = Console.ReadLine().ToUpper();
                          Console.WriteLine("Kuruluş tarihi girin");
                          DateTime kurTarih = Convert.ToDateTime(Console.ReadLine());
                          Restaurant rest = new Restaurant(restAd, kurTarih);
                          db.RestEkle(rest);
                          break;
                case "2": Yemek yemek = new Yemek();
                          Console.WriteLine("Yemek adı girin");
                          yemek.Ad = Console.ReadLine().ToUpper();
                          Console.WriteLine("Fiyat girin");
                          yemek.Fiyat = Convert.ToDouble(Console.ReadLine());
                          Console.WriteLine("Kampanyalı mı (1/0)");
                          yemek.KampanyaDurum = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                          
                          db.YemekEkle(yemek); break;

                case "3": 
                   
                    Console.WriteLine("Restoran Adı Gir");
                    restAd = Console.ReadLine().ToUpper();
                    Restaurant rest1 = db.RestaurantAra(restAd);
                    if (rest1!=null)
                    {
                        Console.WriteLine();
                        if (DBIslemleri.YemekList.Count >= 0)
                        {
                            rest1.YemekList = new ArrayList();
                            Console.WriteLine("Yemek Seç");
                            db.YemekListele();
                            do
                            {
                                
                                int index = int.Parse(Console.ReadLine());
                                if (index-1<=DBIslemleriImpl.YemekList.Count)
                                {
                                    rest1.YemekList.Add(DBIslemleriImpl.YemekList[index - 1]);
                                }
                                else
                                {
                                    Console.WriteLine("Listede Olmayan Yemek");
                                }
                                
                                Console.WriteLine("Liste Bitir mı (E/H)");
                                karar = Console.ReadLine().ToUpper();
                                
                            } while (karar.Equals("H"));
                        }
                        else
                        {
                            Console.WriteLine("Yemek Eklenmemiş");
                        }  
                    }

                    break;


                default: Console.WriteLine("Hatalı Giriş!");
                    break;
            }
            Console.WriteLine("Devam etmek istiyor musunuz? (E/H)");
            char durum = Convert.ToChar(Console.ReadLine().ToUpper());
            if (durum == 'E')
            {
                RestYemekMenu();
            }
            else
            {
                Menu();
            }
        
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Menu Yönlendiriliyor");
                Thread.Sleep(500);
                Menu();
            }

        }
    
    }
}
