using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agaclar;

namespace RehberSistemi
{
    internal class Kisi : IAgaclanabilir
    {
        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        #region veriler
        string Isim {  get; set; }
        string Soyisim { get; set; }
        long TC { get; set; }
        #endregion

        #region IAgaclanabilir
        public string[] Anahtarlar { get; private set; }
        public int AnahtarSayisi { get => Anahtarlar.Length; }
        public string Deger { get => ToString(); }
        #endregion



        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        #region oluşturucular
        private Kisi(string isim, string soyisim)
        {
            Isim = isim;
            Soyisim = soyisim;

            Anahtarlar = new string[] { soyisim, isim };
        }
        private Kisi (string isim, string soyisim, long tc)
        {
            Isim = isim;
            Soyisim = soyisim;
            TC = tc;

            Anahtarlar = new string[] { soyisim, isim };
        }
        #endregion



        //##  METODLAR  ----------  ----------  ----------  ----------
        #region FONKSİYON Kisi Yarat()
        public static Kisi Yarat(string isim, string soyisim) => new Kisi(isim, soyisim);
        public static Kisi Yarat(string isim, string soyisim, long tc) => new Kisi(isim, soyisim, tc);
        #endregion

        #region override metodlar
        public override string ToString() => $"{Isim} {Soyisim} -> {TC}";
        #endregion

        #region FONKSİYON void Guncelle()
        public void Guncelle(string isim, string soyisim)
        {
            Isim = isim;
            Soyisim = soyisim;
        }  //  
        
        public void Guncelle (string isim, string soyisim, long tc)
        {
            Isim = isim;
            Soyisim = soyisim;
            TC = tc;
        }
        #endregion



    }  //  Kisi Sınıfı Sonu
}  //  sinif2odev9 isim alanı sonu
