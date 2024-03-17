using System;
using System.Collections.Generic;

namespace Lab02
{
    public class RachunekBankowy
    {
        private string numer;
        private decimal stanRachunku;
        private bool czyDozwolonyDebet;
        private List<PosiadaczRachunku> _posiadaczeRachunku = new List<PosiadaczRachunku>();
        private List<Transakcja> _transakcje = new List<Transakcja>(); // Lista przechowująca historię transakcji

        public string Numer
        {
            get { return numer; }
            set { numer = value; }
        }

        public decimal StanRachunku
        {
            get { return stanRachunku; }
            set { stanRachunku = value; }
        }

        public bool CzyDozwolonyDebet
        {
            get { return czyDozwolonyDebet; }
            set { czyDozwolonyDebet = value; }
        }

        public List<PosiadaczRachunku> PosiadaczeRachunku
        {
            get { return _posiadaczeRachunku; }
        }

        public List<Transakcja> Transakcje
        {
            get { return _transakcje; }
        }

        public RachunekBankowy(string numer, decimal stanRachunku, bool czyDozwolonyDebet, List<PosiadaczRachunku> posiadaczeRachunku)
        {
            if (posiadaczeRachunku == null || posiadaczeRachunku.Count == 0)
            {
                throw new ArgumentException("Lista posiadaczy rachunku musi zawierać co najmniej jedną pozycję.");
            }

            this.numer = numer;
            this.stanRachunku = stanRachunku;
            this.czyDozwolonyDebet = czyDozwolonyDebet;
            this._posiadaczeRachunku = new List<PosiadaczRachunku>(posiadaczeRachunku);
        }

        public void DodajPosiadacza(PosiadaczRachunku posiadacz)
        {
            if (!PosiadaczeRachunku.Contains(posiadacz))
            {
                PosiadaczeRachunku.Add(posiadacz);
            }
        }

        public void UsunPosiadacza(PosiadaczRachunku posiadacz)
        {
            if (PosiadaczeRachunku.Contains(posiadacz))
            {
                PosiadaczeRachunku.Remove(posiadacz);
            }
        }

        public int LiczbaPosiadaczy()
        {
            return PosiadaczeRachunku.Count;
        }

        public static void DokonajTransakcji(RachunekBankowy zrodlowy, RachunekBankowy docelowy, decimal kwota, string opis)
        {
            if (kwota < 0)
            {
                throw new ArgumentException("Kwota transakcji nie może być ujemna.");
            }

            if (zrodlowy == null && docelowy == null)
            {
                throw new ArgumentNullException("Oba rachunki nie mogą być null.");
            }

            if (zrodlowy != null && !zrodlowy.czyDozwolonyDebet && zrodlowy.stanRachunku < kwota)
            {
                throw new InvalidOperationException("Brak wystarczających środków na rachunku źródłowym i debet nie jest dozwolony.");
            }

            if (zrodlowy == null) // Wpłata gotówkowa
            {
                docelowy.stanRachunku += kwota;
                Transakcja transakcja = new Transakcja(null, docelowy, kwota, opis);
                docelowy._transakcje.Add(transakcja);
            }
            else if (docelowy == null) // Wypłata gotówkowa
            {
                zrodlowy.stanRachunku -= kwota;
                Transakcja transakcja = new Transakcja(zrodlowy, null, kwota, opis);
                zrodlowy._transakcje.Add(transakcja);
            }
            else // Przelew między rachunkami
            {
                zrodlowy.stanRachunku -= kwota;
                docelowy.stanRachunku += kwota;
                Transakcja transakcja = new Transakcja(zrodlowy, docelowy, kwota, opis);
                zrodlowy._transakcje.Add(transakcja);
                docelowy._transakcje.Add(transakcja);
            }
        }
    }
}
