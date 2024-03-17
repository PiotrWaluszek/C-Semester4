using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Użycie: nazwaPliku");
            return;
        }

        string fileName = args[0];
        int lineCount = 0;
        int charCount = 0;
        double maxNumber = double.MinValue;
        double minNumber = double.MaxValue;
        double sum = 0;

        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineCount++;
                    charCount += line.Length;
                    if (double.TryParse(line, out double number))
                    {
                        maxNumber = Math.Max(maxNumber, number);
                        minNumber = Math.Min(minNumber, number);
                        sum += number;
                    }
                }
            }

            double average = lineCount > 0 ? sum / lineCount : 0;
            Console.WriteLine($"Liczba linii: {lineCount}");
            Console.WriteLine($"Liczba znaków: {charCount}");
            Console.WriteLine($"Największa liczba: {maxNumber}");
            Console.WriteLine($"Najmniejsza liczba: {minNumber}");
            Console.WriteLine($"Średnia liczb: {average}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Wystąpił błąd: {e.Message}");
        }
    }
}
