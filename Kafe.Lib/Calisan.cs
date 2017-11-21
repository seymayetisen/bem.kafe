using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Calisan
    {
        public Calisan(string isim, DateTime girisTarihi, Kafe kafe)
        {
            Isim = isim;
            IseGirisTarihi = girisTarihi;
            MesaideMi = false;
            Kafe = kafe;
            Siparisler = new List<Siparis>();
            Gorev = new Gorev();
        }

        public int Id { get; set; }
        public string Isim { get; private set; }
        public DateTime IseGirisTarihi { get; private set; }
        public bool MesaideMi { get; private set; }
        public CalisanDurum Durum { get; set; }
        public List<Siparis> Siparisler { get; set; }
        public Kafe Kafe { get; set; }
        public Gorev Gorev { get; set; }

        public void MesaiyeBasladi()
        {
            MesaideMi = true;
        }

        public void MesaisiBitti()
        {
            MesaideMi = false;
        }
        
    }
}
