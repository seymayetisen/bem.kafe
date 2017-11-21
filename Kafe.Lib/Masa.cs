using System;

namespace KafeYonetim.Lib
{
    public class Masa
    {
        public Masa(string masaNo, Kafe kafe)
        {
            MasaNo = masaNo;
            Kafe = kafe;
        }



        public string MasaNo { get; private set; }
        public Siparis Siparis { get; set; }
        public MasaDurum Durum { get; set; }
        public Garson Garson { get; set; }
        public Kafe Kafe { get; private set; }
        public byte KisiSayisi { get; set; }

        public void GarsonCagir()
        {
            if(!(Garson is null))
            {
                return;
            }

            Garson = Kafe.UygunGarsonuBul(CalisanDurum.Masada);

            Console.WriteLine("Garson geldi.");
        }

        public void GarsonuSerbestBirak()
        {
            Garson.Durum = CalisanDurum.Uygun;
            Garson = null;
        }

        public void SiparisVer()
        {
            GarsonCagir();

            Siparis = Siparis ?? new Siparis();
            Siparis.SiparisiAlanGarson = Garson;
            Siparis.Masa = this;

            UrunSecimEkrani();
            Garson.SiparisAl(Siparis);

            GarsonuSerbestBirak();

            Console.WriteLine("Sipariş verildi.");
        }

        public void OdemeYap()
        {
            GarsonCagir();
            Durum = MasaDurum.Bos;
            Console.WriteLine($"Toplam {Siparis.ToplamFiyat} TL Ödeme yapıldı.");
            Siparis = null;

            Console.ReadKey();
            GarsonuSerbestBirak();
        }

        private void UrunSecimEkrani()
        {
            Console.Clear();
            Console.WriteLine("Ürün Seçimi");

            do
            {
                for (int i = 0; i < Kafe.Urunler.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Kafe.Urunler[i].Ad} - {Kafe.Urunler[i].Fiyat} ");
                }

                Console.Write("Ürün numarasını belirtiniz: ");
                Console.Write("Siparişi tamamlamak için T harfine basınız!");

                var secim = Console.ReadLine();

                if (secim.ToLower() == "t")
                {
                    break;
                }

                var kalem = new Kalem();
                kalem.Urun = Kafe.Urunler[int.Parse(secim)-1];

                Console.Write("Adet belirtiniz: ");
                var adet = int.Parse(Console.ReadLine());
                kalem.Adet = adet;

                Siparis.Kalemler.Add(kalem);
            } while (true);

            Console.WriteLine("Sipariş alındı");
            Console.ReadKey();
        }

        public void SiparisiKontrolEt()
        {
            Console.Clear();
            Console.WriteLine("Siparişler");

            foreach (var kalem in Siparis.Kalemler)
            {
                Console.WriteLine($"{kalem.Urun.Ad} - {kalem.Durum}");
            }

            Console.WriteLine($"\nToplam tutar: {Siparis.ToplamFiyat}");
            Console.ReadKey();
        }
    }
}