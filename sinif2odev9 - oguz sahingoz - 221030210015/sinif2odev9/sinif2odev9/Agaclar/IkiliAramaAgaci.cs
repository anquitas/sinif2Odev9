using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agaclar
{
    internal class IkiliAramaAgaci
    {
        //##  ALANLAR  ----------  ----------  ----------  ----------

        int _elemanSayisi = 0;

        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        public Dugum Kok { get; private set; }
        public int ElemanSayisi {  get => _elemanSayisi; }


        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        #region oluşturucular
        private IkiliAramaAgaci () => Kok = null;  //  ağacı başlatmak için oluşturucu
        #endregion

        //##  METODLAR  ----------  ----------  ----------  ----------

        #region yaratıcı fonksiyonlar
        public static IkiliAramaAgaci Yarat() => new IkiliAramaAgaci();  //  boş bir ağaç yaratıp dönderen yaratıcı fonksiyon
        #endregion

        #region ağaç operasyonları
        public void Ekle (IAgaclanabilir veri) 
        {
            if (Kok == null)
            {
                Kok = Dugum.Yarat(veri);
                _elemanSayisi++;
            }  //  ağaç boş ise
            else 
            { 
                Kok.Ekle(veri);
                _elemanSayisi++;
            }   //  ağaçta kök düğümü varsa       
        }  //  ağaca aldığı veriyi taşıyan yeni bir düğüm ekler

        public void OnceKok() => Kok.preOrder();
        public void OrtadaKok() => Kok.inOrder();
        public void SonraKok() => Kok.postOrder();
        #endregion

        #region kontrol fonksiyonları
        public bool BosMu () => Kok != null;  //  
        #endregion

    }  //  Agac sınıfı sonu
}  //  sinif2odev9 isim alanı sonu
