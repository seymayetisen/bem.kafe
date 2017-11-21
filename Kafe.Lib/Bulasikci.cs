using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Bulasikci: Calisan
    {
        public Bulasikci(string isim, DateTime iseGirisTarihi, Kafe kafe): base(isim, iseGirisTarihi, kafe)
        {

        }

        public int HijyenPuani { get; set; }
    }
}
