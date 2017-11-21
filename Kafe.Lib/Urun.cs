namespace KafeYonetim.Lib
{
    public class Urun
    {
        public Urun(int id,string ad, double fiyat, bool stoktaVarMi)
        {
            Id = id;
            Ad = ad;
            Fiyat = fiyat;
            StoktaVarmi = stoktaVarMi;
        }

        public int Id { get; private set; }
        public string Ad { get; private set; }
        public double Fiyat { get; private set; }
        public bool StoktaVarmi { get; set; }
    }
}