using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Garson: Calisan
    {
        public double Bahsis { get; set; }


        public Garson(string i, DateTime g, Kafe k): base(i, g, k)
        {

        }

        public void MasaAc()
        {
            Console.WriteLine("Masa açıldı.");
        }

        //Method Signature - Metod imzası
        //  1. Metodun adı
        //  2. Parametre sayısı
        //  3. Parametre tipleri
        public void SiparisAl(Siparis siparis)
        {
            Siparisler.Add(siparis);
            Asci asci = Kafe.UygunAsciBul();//OVERLOAD
            siparis.SiparisiHazirlayanAsci = asci;
            asci.SiparisiHazirla(siparis);
            Kafe.Siparisler.Add(siparis);
            Console.WriteLine("Sipariş alındı.");
        }
        
        public void SiparisiServisEt(Siparis siparis)
        {
            foreach (var kalem in siparis.Kalemler)
            {
                kalem.Durum = SiparisDurum.TeslimEdildi;
            }

            siparis.SiparisiAlanGarson.Durum = CalisanDurum.Uygun;
            siparis.SiparisiAlanGarson = null;

            Console.WriteLine("Sipariş servis edildi.");
        }

        public void OdemeAl()
        {
            Console.WriteLine("Ödeme alındı.");
        }
    }
}
