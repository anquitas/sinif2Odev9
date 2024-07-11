using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agaclar
{
    internal class Dugum 
    {
        //##  NİTELİKLER  ----------  ----------  ----------  ----------

        #region veri
        IAgaclanabilir Veri { get; set; }
        #endregion

        #region çocuklar
        Dugum Sol  { get; set; }
        Dugum Sag { get; set; }
        #endregion



        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------

        #region oluşturucular
        public Dugum(IAgaclanabilir veri) 
        { 
            Veri = veri; 
            Sol = null; 
            Sag = null;
        }
        #endregion



        //##  METODLAR  ----------  ----------  ----------  ----------

        #region asıl dolaşma fonksiyonları
        public void inOrder() => inOrderR(this);
        public void preOrder() => preOrderR(this);
        public void postOrder() => postOrderR(this);
        #endregion

        #region özyinelemeli dolaşma fonksiyonları
        public static void preOrderR(Dugum dugum)
        {
            if (dugum != null)  //  kökün varlığını kontrol et
            {
                Console.WriteLine(dugum);  //  kişi bilgisini yazdır
                preOrderR(dugum.Sol);  //  sola geç
                preOrderR(dugum.Sag);  //  sağa geç
            }  //  eğer çağırılan node null değilse arama yazdırmayı başlat
            //  eğer null ile çağırılırsa ise fonksiyonu sonlandır
        }  //  önce kök dolaşım

        public static void inOrderR(Dugum dugum)
        {
            if (dugum != null)  //  kökün varlığını kontrol et
            {
                inOrderR(dugum.Sol);  //  sola geç
                Console.WriteLine(dugum);  //  kişi bilgisini yazdır
                inOrderR(dugum.Sag);  //  sağa geç
            }  //  eğer çağırılan node null değilse arama yazdırmayı başlat
            //  eğer null ile çağırılırsa ise fonksiyonu sonlandır
        }  //  ortada kök dolaşım

        public static void postOrderR(Dugum dugum)
        {
            if (dugum != null)  //  kökün varlığını kontrol et
            {
                postOrderR(dugum.Sol);  //  sola geç
                postOrderR(dugum.Sag);  //  sağa geç
                Console.WriteLine(dugum);   //  kişi bilgisini yazdır
            }  //  eğer çağırılan node null değilse arama yazdırmayı başlat
            //  eğer null ile çağırılırsa ise fonksiyonu sonlandır
        }  //  sonra kök dolaşım
        #endregion

        #region statik araç fonksiyonları
        public static bool OnceMi (string str1, string str2)
        {
            CultureInfo turkishCulture = new CultureInfo("tr-TR");
                return string.Compare(str1, str2, turkishCulture, CompareOptions.StringSort) < 0;
        }  //  iki string karşılaştırır, ilki önce ise true, değil ise false

        public static int Karsilastir(string[] anahtarlar1, string[] anahtarlar2)
        {
            
            for (int i = 0; i < anahtarlar1.Length; i++)  //  anahtar kontrolü
            {
                if (anahtarlar1[i] != anahtarlar2[i]) return OnceMi(anahtarlar1[i] , anahtarlar2[i]) ? -1 : 1;
            } return 0;   // tüm anahtarların eşit olaması durumu
        }  //  sıra ile anahtarları kontol eder, anahtarlar aynı ise 0, ilki büyük ise 1, küçük ise -1 dönderir

        public static Dugum Yarat (IAgaclanabilir veri) => new Dugum (veri);  //  yaratıcı fonksiyon
        #endregion

        #region FONKSİYON void Ekle()
        public void Ekle(IAgaclanabilir veri)
        {
            
            if (Karsilastir(veri.Anahtarlar,Veri.Anahtarlar) < 0)
            {
                if (Sol == null)  // soldaki düğüm null ise oraya ekleme yapar
                    Sol = Yarat(veri);  //  sol boşluğa ekleme yap
                Sol.Ekle(veri);  //  düğüm null değilse sağdan yer aramaya devam eder
            }  //  parametre isim, düğüm isimden küçükse

            if (Karsilastir(veri.Anahtarlar, Veri.Anahtarlar) > 0)
            {
                if (Sag == null)  // sağdaki düğüm null ise oraya ekleme yapar
                    Sag = Yarat(veri);  //  sağ boşluğa ekleme yap
                Sag.Ekle(veri);  //  düğüm null değilse sağdan yer aramaya devam eder
            }  //  parametre isim, düğüm isimden küçükse
        }  //  arama ağacında uygun yere yeni bir düğüm ekler
        #endregion

        #region override metrodlar
        public override string ToString() => Veri.Deger;
        #endregion

    }  //  Dugum sınıfı sonu
}  //  sinif2odev9 isim alanı sonu
