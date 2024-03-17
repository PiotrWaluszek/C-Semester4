using System;
using System.IO;

class Program
{
    static void Main()
    {
        string maxString = ""; 
        string userInput;
        string fileName = "Wpisane.txt";

        Console.WriteLine("Wpisuj napisy ('koniec!' aby zakończyć): ");

        while (true)
        {
            userInput = Console.ReadLine();

            if (userInput == "koniec!")
            {
                break;
            }

            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(userInput);
            }

            if (String.Compare(userInput, maxString) > 0)
            {
                maxString = userInput;
            }
        }

        Console.WriteLine($"Napis, który bedzie ostatni po posortowaniu: {maxString}");
    }
}
