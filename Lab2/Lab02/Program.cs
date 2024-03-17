using System;
using System.Collections.Generic;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            OsobaFizyczna osobaFizyczna = new OsobaFizyczna("Jan", "Kowalski", "Adam", "12345678901", "AB1234567");
            OsobaPrawna osobaPrawna = new OsobaPrawna("XYZ Sp. z o.o.", "Kraków");

            List<PosiadaczRachunku> posiadacze = new List<PosiadaczRachunku> { osobaFizyczna, osobaPrawna };

            RachunekBankowy rachunekZrodlowy = new RachunekBankowy("1234567890", 1000.00m, true, posiadacze);
            RachunekBankowy rachunekDocelowy = new RachunekBankowy("0987654321", 500.00m, true, posiadacze);

            Console.WriteLine("Stan początkowy:");
            Console.WriteLine($"Rachunek źródłowy: {rachunekZrodlowy.StanRachunku}");
            Console.WriteLine($"Rachunek docelowy: {rachunekDocelowy.StanRachunku}\n");

            Console.WriteLine("Przeprowadzanie transakcji...");
            RachunekBankowy.DokonajTransakcji(rachunekZrodlowy, rachunekDocelowy, 200.00m, "Przelew bez błędów");

            Console.WriteLine("\nStan końcowy:");
            Console.WriteLine($"Rachunek źródłowy: {rachunekZrodlowy.StanRachunku}");
            Console.WriteLine($"Rachunek docelowy: {rachunekDocelowy.StanRachunku}");

            Console.WriteLine("\nDane posiadacza rachunku źródłowego:");
            foreach (var posiadacz in rachunekZrodlowy.PosiadaczeRachunku)
            {
                Console.WriteLine(posiadacz.ToString());
            }

            Console.WriteLine("\nSprawdzenie poprawności PESEL:");
            try
            {
                OsobaFizyczna osobaZaDlugiPesel = new OsobaFizyczna("Piotr", "Nadmierny", "", "12345678901234567890", "BC1234567");
                Console.WriteLine("Utworzono osobę fizyczną z za długim PESEL.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Błąd przy tworzeniu osoby z za długim PESEL: {e.Message}");
            }
        }
    }
}
