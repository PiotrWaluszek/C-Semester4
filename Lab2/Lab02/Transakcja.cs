using System;

namespace Lab02
{
    public class Transakcja
    {
        private RachunekBankowy rachunekZrodlowy;
        private RachunekBankowy rachunekDocelowy;
        private decimal kwota;
        private string opis;

        public RachunekBankowy RachunekZrodlowy
        {
            get { return rachunekZrodlowy; }
            set { rachunekZrodlowy = value; }
        }

        public RachunekBankowy RachunekDocelowy
        {
            get { return rachunekDocelowy; }
            set { rachunekDocelowy = value; }
        }

        public decimal Kwota
        {
            get { return kwota; }
            set { kwota = value; }
        }

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public Transakcja(RachunekBankowy rachunekZrodlowy, RachunekBankowy rachunekDocelowy, decimal kwota, string opis)
        {
            if (rachunekZrodlowy == null || rachunekDocelowy == null)
            {
                throw new ArgumentNullException("Rachunek źródłowy i docelowy nie mogą być null.");
            }

            if (rachunekZrodlowy == rachunekDocelowy)
            {
                throw new ArgumentException("Rachunek źródłowy i docelowy muszą być różne.");
            }

            this.rachunekZrodlowy = rachunekZrodlowy;
            this.rachunekDocelowy = rachunekDocelowy;
            this.kwota = kwota;
            this.opis = opis;
        }

        public override string ToString()
    {
        string numerZrodlowy = RachunekZrodlowy?.Numer ?? "brak"; 
        string numerDocelowy = RachunekDocelowy?.Numer ?? "brak";
        return $"Z: {numerZrodlowy}, Do: {numerDocelowy}, Kwota: {Kwota:C}, Opis: {Opis}";
    }
    }
    
}
