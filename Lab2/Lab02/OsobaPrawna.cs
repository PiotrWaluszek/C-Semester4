using System;

namespace Lab02
{
    public class OsobaPrawna : PosiadaczRachunku
    {
        private readonly string nazwa;
        private readonly string siedziba;

        public string Nazwa
        {
            get { return nazwa; }
        }

        public string Siedziba
        {
            get { return siedziba; }
        }

        public OsobaPrawna(string nazwa, string siedziba)
        {
            this.nazwa = nazwa;
            this.siedziba = siedziba;
        }

        public override string ToString()
        {
            return $"Osoba Prawna: {Nazwa}, Siedziba: {Siedziba}";
        }
    }
}