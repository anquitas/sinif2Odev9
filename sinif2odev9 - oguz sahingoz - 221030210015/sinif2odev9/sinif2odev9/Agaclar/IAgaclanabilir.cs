using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agaclar
{
    internal interface IAgaclanabilir
    {
        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        string[] Anahtarlar {  get; }  //  veriye ait düğümde kullanılacak anahtarlar
        int AnahtarSayisi{  get; }  //  veriye ait anahtar sayısı
        string Deger {  get; }  //  veriye ait değer 
    }  //  IAgaclanabilir arayüzü
}  //  Agaclar isim alanı
