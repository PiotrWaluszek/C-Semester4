using System;

namespace Lab02
{
    public class OsobaFizyczna : PosiadaczRachunku
    {
        private string imie;
        private string nazwisko;
        private string drugieImie;
        private string pesel;
        private string numerPaszportu;

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        public string DrugieImie
        {
            get { return drugieImie; }
            set { drugieImie = value; }
        }

        public string PESEL
        {
            get { return pesel; }
            set
            {
                if (value == null || value.Length != 11)
                {
                    throw new ArgumentException("PESEL musi mieć dokładnie 11 cyfr.");
                }
                pesel = value;
            }
        }

        public string NumerPaszportu
        {
            get { return numerPaszportu; }
            set { numerPaszportu = value; }
        }

        public OsobaFizyczna(string imie, string nazwisko, string drugieImie, string pesel, string numerPaszportu)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.DrugieImie = drugieImie;
            this.PESEL = pesel;
            this.NumerPaszportu = numerPaszportu;

            if (pesel == null && numerPaszportu == null)
            {
                throw new ArgumentException("Musisz podać PESEL lub numer paszportu.");
            }
        }

        public override string ToString()
        {
            return $"Osoba Fizyczna: {Imie} {Nazwisko}";
        }
        
    }
}