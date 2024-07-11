using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agaclar;
using RehberSistemi;
using KonsolUygulamasi;


namespace sinif2odev9
{
    internal class Program
    {
        static void Main(string[] args)  
        {
            init();
            uygulama.basla();
        }  // main fonksiyonu

        //##  ALANLAR  ----------  ----------  ----------  ----------
        //public static string link = AppDomain.CurrentDomain.BaseDirectory.Substring(0, 32) + "kisiListesi.csv";
        public static string link2 = @"..\..\kisiListesi.csv";

        public static Rehber rehber = Rehber.Yarat("kişiler");
        public static Uygulama uygulama = Uygulama.yarat();
        public static Menu temp;
        public static CSV_Diyalogu diyalog = CSV_Diyalogu.OrnekVer();



        //##  METODLAR  ----------  ----------  ----------  ----------
        public static void init ()
        {
            temp = Menu.Yarat("REHBER SİSTEMİ",new string[] {"kisileri görüntüle",  "liste al"},menu1_F);
            uygulama.menuEkle(temp);
        }  // uygulama ve menuyu yaratır

        public static void menu1_F(int secim) 
        {
            switch (secim)
            {
                case 1:  //  ilk seçenek
                    rehber.yazdir();
                    Console.ReadKey();
                    break;

                    case 2:  //  2. seçenek
                    Uygulama.secimAl(new string[] { "kisiListesi" });
                    diyalog.LinkAl(link2);
                    diyalog.VeriAl();
                    rehber.Ekle(diyalog);
                    Console.WriteLine("listedeki kişeler rehberinize eklendi");
                    Console.ReadKey();
                    break;
            }
        }  //  menü 1 için yapılacak işlemleri tanımlar

  


    }


}  //  sinif2odev9 isim alanı
