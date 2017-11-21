using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Kafe
    {
        //Constructor - İnşa edici metod / Yapılandırıcı Metod

        public Kafe(int id, string ad, string acilisSaati, string kapanisSaati) : this(ad, acilisSaati, kapanisSaati)
        {
            Id = id;
        }

        public Kafe(string ad, string acilisSaati, string kapanisSaati)
        {
            Ad = ad;
            AcilisSaati = acilisSaati;
            KapanisSaati = kapanisSaati;

            Durum = KafeDurum.Kapali;

            Urunler = new List<Urun>();
            Calisanlar = new List<Calisan>();
            Masalar = new List<Masa>();
            Siparisler = new List<Siparis>();
        }

        internal Asci UygunAsciBul()
        {
            return UygunAsciBul(CalisanDurum.Uygun);
        }

        internal Asci UygunAsciBul(CalisanDurum yeniDurum)
        {
            return UygunCalisanBul<Asci>(yeniDurum);
        }

        public Garson UygunGarsonuBul(CalisanDurum yeniDurum)
        {
            return UygunCalisanBul<Garson>(yeniDurum);
        }

        internal T UygunCalisanBul<T>(CalisanDurum yeniDurum) where T : Calisan
        {
            foreach (var calisan in Calisanlar)
            {
                if (!(calisan is T))
                {
                    continue;
                }

                if (calisan.MesaideMi && calisan.Durum == CalisanDurum.Uygun)
                {
                    calisan.Durum = yeniDurum;
                    return (T)calisan;
                }
            }

            return null;
        }

        //internal Asci UygunAsciBul(CalisanDurum yeniDurum)
        //{
        //    foreach (var calisan in Calisanlar)
        //    {
        //        if (!(calisan is Asci))
        //        {
        //            continue;
        //        }

        //        if (calisan.MesaideMi && calisan.Durum == CalisanDurum.Uygun)
        //        {
        //            calisan.Durum = yeniDurum;
        //            return (Asci)calisan;
        //        }
        //    }

        //    return null;
        //}

        //public Garson UygunGarsonuBul(CalisanDurum yeniDurum)
        //{
        //    foreach (var calisan in Calisanlar)
        //    {
        //        if (!(calisan is Garson))
        //        {
        //            continue;
        //        }

        //        if (calisan.MesaideMi && calisan.Durum == CalisanDurum.Uygun)
        //        {
        //            calisan.Durum = yeniDurum;
        //            return (Garson)calisan;
        //        }
        //    }

        //    return null;
        //}

        public int Id { get; set; }
        public string Ad { get; private set; }
        public string AcilisSaati { get; private set; }
        public string KapanisSaati { get; private set; }
        public KafeDurum Durum { get; set; }
        public List<Calisan> Calisanlar { get; set; }
        //public List<Garson> Garsonlar { get; set; }
        //public List<Asci> Ascilar { get; set; }
        public List<Urun> Urunler { get; set; }
        public List<Masa> Masalar { get; set; }
        public List<Siparis> Siparisler { get; set; }

        public void Ac()
        {
            Durum = KafeDurum.Acik;
            foreach (var calisan in Calisanlar)
            {
                calisan.MesaiyeBasladi();
            }
        }

        public void Kapat()
        {
            Durum = KafeDurum.Kapali;
        }


    }
}
