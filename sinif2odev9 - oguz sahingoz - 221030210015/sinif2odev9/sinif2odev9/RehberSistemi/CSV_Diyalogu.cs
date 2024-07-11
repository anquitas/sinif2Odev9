using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehberSistemi
{
    internal class CSV_Diyalogu : IEnumerable
    {
        //##  ALANLAR  ----------  ----------  ----------  ----------
        #region singleton
        private static CSV_Diyalogu singletonLazy = null;
        #endregion



        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        #region dosya yolu
        public string DosyaLinki { get; private set; }
        #endregion

        #region veri nitelikleri
        public List<string[]> Veriler { get; private set; }

        public int SatirSayisi { get => Veriler != null ? Veriler[0].Length : 0; }
        #endregion



        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        #region oluşturucular
        public CSV_Diyalogu() { }
        #endregion



        //##  INDEXERLAR  ----------  ----------  ----------  ----------   
        #region ana indexer
        public string[] this[int index]
        {
            get
            {
                if (index < 0 || index >= Veriler.Count) throw new IndexOutOfRangeException("okuma sınır dışı");
                //  verilen index dizinin sınırları dışında ise exception verir
                return Veriler[index];
            }

            set
            {
                if (index < 0 || index >= Veriler.Count) throw new IndexOutOfRangeException("yazma sınır dışı");
                //  verilen index dizinin sınırları dışında ise exception verir
                Veriler[index] = value;
            }
        }  // belirli indexteki elemanı dönderir
        #endregion



        //##  METODLAR  ----------  ----------  ----------  ----------
        #region erişim fonksiyonları
        public static CSV_Diyalogu OrnekVer()
        {
            if (singletonLazy == null) 
            { 
                singletonLazy = new CSV_Diyalogu(); 
                return singletonLazy;
            } return singletonLazy;
        }

        
        public List<string[]> VeriListesi() => Veriler;

        public void LinkAl(string link) => DosyaLinki = link;
        #endregion

        #region veri eldesi


        public void VeriAl()
        { //tüm kayıtları string dizisi halinde listeye ekler listeyi dönderir
            string[] satirlar = File.ReadAllLines(DosyaLinki);
            List<string[]> liste = new List<string[]>();

            for (int j = 0; j < satirlar.Length; j++)
            {
                if(satirlar[j].Length <= 0) break;
                string[] kayit = satirlar[j].Split(' ');
                liste.Add(kayit);
            }
            Veriler = liste;
            //@"D:\repo\sinif2odev9\sinif2odev9\RehberSistemi\kisiListesi.csv"
        }

        public static string[] satirAl(string satir) => satir.Split(' ');

        #endregion

        #region interface implemantasyonu
        public IEnumerator GetEnumerator() => Veriler.GetEnumerator();
        #endregion

    }  //  CSV_Diyalogu sınıfı

}  //  RehberSistemi isim alanı sonu
