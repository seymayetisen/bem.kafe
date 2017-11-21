using KafeYonetim.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Sunum.ConsoleApp
{
    class Program
    {
        private static Kafe kafe;

        static void Main(string[] args)
        {
            kafe = KafeInstanceOlustur();
            KafeyeUrunEkle(kafe);
            KafeyeCalisanEkle(kafe);
            KafeyeMasaEkle(kafe);
            kafe.Ac();
            ConsoleKeyInfo secim;
            do
            {
                MenuYazdir();

                secim = Console.ReadKey();

                switch (secim.KeyChar)
                {
                    case '1': MasayaGarsonCagir(); break;
                    case '2': GarsonuMasadanGonder(); break;
                    case '3': SiparisVer(); break;
                    case '4': MasaSiparisiniKontrolEt(); break;
                    case '5': SiparisHazirlandi(); break;
                    case '6': OdemeYap(); break;
                    case 't': BreakPoint();break; 
                    default:
                        break;
                }

            } while (secim.KeyChar != '0');

            Console.ReadKey();
        }

        private static void OdemeYap()
        {
            Console.Clear();
            Console.Write("Masa numarasını belirtin: ");
            int masaNo = int.Parse(Console.ReadLine());

            kafe.Masalar[masaNo].OdemeYap();
        }

        private static void SiparisHazirlandi()
        {
            Console.Clear();
            Console.Write("Sipariş numarasını belirtin: ");
            int siparisNo = int.Parse(Console.ReadLine());

            kafe.Siparisler[siparisNo].SiparisiHazirlayanAsci.SiparisHazirlandi(kafe.Siparisler[siparisNo]);
        }

        private static void MasaSiparisiniKontrolEt()
        {
            Console.Clear();
            Console.Write("Masa numarasını belirtin: ");
            int masaNo = int.Parse(Console.ReadLine());

            kafe.Masalar[masaNo].SiparisiKontrolEt();
        }

        public static void MasayaGarsonCagir()
        {
            Console.Clear();
            Console.Write("Masa numarasını belirtin: ");
            int masaNo = int.Parse(Console.ReadLine());

            kafe.Masalar[masaNo].GarsonCagir();
        }

        public static void GarsonuMasadanGonder()
        {
            Console.Clear();
            Console.Write("Masa numarasını belirtin: ");
            int masaNo = int.Parse(Console.ReadLine());
            kafe.Masalar[masaNo].GarsonuSerbestBirak();
        }

        public static void SiparisVer()
        {
            Console.Clear();
            Console.Write("Masa numarasını belirtin: ");
            int masaNo = int.Parse(Console.ReadLine());
            kafe.Masalar[masaNo].SiparisVer();
        }

        public static void MenuYazdir()
        {
            Console.Clear();
            Console.WriteLine("Menü");
            Console.WriteLine("1. Masaya Garson Çağır.");
            Console.WriteLine("2. Garsonu Serbest Bırak");
            Console.WriteLine("3. Masadan Garsona Sipariş Ver");
            Console.WriteLine("4. MasaSiparişini Kontrol Et");
            Console.WriteLine("5. Sipariş Hazırlandı");
            Console.WriteLine("6. Ödeme Yap");
            Console.WriteLine("0. Uygulamayaı kapat");
            Console.WriteLine();
            Console.Write("Bir seçim yapınız: ");
        }

        public static Kafe KafeInstanceOlustur()
        {
            var kafe = new Kafe("Bizim Kafe", "09:00", "22:00");

            Console.WriteLine("Kafe");
            Console.WriteLine($"\tAd: {kafe.Ad}");
            Console.WriteLine($"\tDurum: {kafe.Durum}");

            return kafe;
        }

        public static void KafeyeUrunEkle(Kafe kafe)
        {
            kafe.Urunler.Add(new Urun("Çay", 9.00f, true));
            kafe.Urunler.Add(new Urun("Kahve", 12.00f, true));
            kafe.Urunler.Add(new Urun("Gazoz", 12.00f, true));
            kafe.Urunler.Add(new Urun("Tonbalıklı Sandviç", 16.00f, true));
            kafe.Urunler.Add(new Urun("Pekin Usulü Portakallı Ördek", 150.00f, true));
        }

        public static void KafeyeCalisanEkle(Kafe kafe)
        {

            kafe.Calisanlar.Add(new Garson("Ahmet", new DateTime(2017, 11, 8), kafe));
            kafe.Calisanlar.Add(new Garson("Mehmet", new DateTime(2017, 11, 8), kafe));
            kafe.Calisanlar.Add(new Asci("Berk", new DateTime(2017, 11, 8), kafe));
        }

        public static void KafeyeMasaEkle(Kafe kafe)
        {
            kafe.Masalar.Add(new Masa(1, kafe));
            kafe.Masalar.Add(new Masa(2, kafe));
            kafe.Masalar.Add(new Masa(3, kafe));
            kafe.Masalar.Add(new Masa(4, kafe));
        }

        public static void BreakPoint()
        {

        }
    }
}
