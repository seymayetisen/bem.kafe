using System.Collections.Generic;

namespace KafeYonetim.Lib
{
    public class Siparis
    {
        public Siparis()
        {
            Kalemler = new List<Kalem>();
        }

        public int SiparisNo { get; private set; }
        public List<Kalem> Kalemler { get; set; }
        public Garson SiparisiAlanGarson { get; set; }
        public Asci SiparisiHazirlayanAsci { get; set; }
        public Masa Masa { get; set; }
        public string Not { get; set; }
        public double ToplamFiyat {
            get {
                double toplam = 0f;

                foreach (var kalem in Kalemler)
                {
                    toplam += kalem.Urun.Fiyat * kalem.Adet;
                }

                return toplam;
            }
        }
    }
}