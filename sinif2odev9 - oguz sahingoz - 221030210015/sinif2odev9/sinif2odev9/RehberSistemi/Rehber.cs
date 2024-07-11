using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agaclar;

namespace RehberSistemi
{
    internal class Rehber
    {
        //##  NITELIKLER  ----------  ----------  ----------  ----------
        #region rehber bilgileri
        public string Baslik {  get; private set; }
        #endregion

        #region veri ve bilgileri
        private IkiliAramaAgaci agac {  get; set; }

        public int KisiSayisi { get => agac.ElemanSayisi; }
        #endregion

        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        #region oluşturucular
        private Rehber (string baslik) => Baslik = baslik;
        #endregion


        //##  METODLAR  ----------  ----------  ----------  ----------
        #region yaratıcı fonksiyonlar
        public static Rehber Yarat(string baslik) { Rehber temp = new Rehber(baslik); temp.agac = IkiliAramaAgaci.Yarat(); return temp; }
        #endregion

        #region FONKSİYON Ekle()
        public void Ekle (Kisi kisi) => agac.Ekle(kisi); 

        public void Ekle (string isim, string soyisim, long tc) => Ekle(Kisi.Yarat(isim, soyisim, tc));

        public void Ekle(string[] kisiVektoru) => Ekle(kisiVektoru[0], kisiVektoru[1], long.Parse(kisiVektoru[2]));
        

        public void Ekle(CSV_Diyalogu diyalog)
        {
            foreach (string[] satir in diyalog)
                Ekle(satir);
        }
        #endregion

        #region bilgi fonksiyonları
        public bool BosMu () => agac != null;

        public void yazdir() => agac.OrtadaKok();
        #endregion

    }  //  Rehber sınıfı sonu
}  //  sinif2odev9 isim alanı sonu
