using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 5)
        {
            Console.WriteLine("Nieprawidłowa liczba argumentów. Użycie: <nazwaPliku> <liczba n> <dolnaGranica> <gornaGranica> seed typ");
            return;
        }

        string fileName = args[0];
        int n = int.Parse(args[1]);
        double lowerBound = double.Parse(args[2]);
        double upperBound = double.Parse(args[3]);
        int seed = int.Parse(args[4]);
        string type = args[5];

        Random random = new Random(seed);

        using (StreamWriter sw = new StreamWriter(fileName))
        {
            for (int i = 0; i < n; i++)
            {
                if (type.ToLower() == "int")
                {
                    int number = random.Next((int)lowerBound, (int)upperBound + 1);
                    sw.WriteLine(number);
                }
                else if (type.ToLower() == "real")
                {
                    double number = random.NextDouble() * (upperBound - lowerBound) + lowerBound;
                    sw.WriteLine(number);
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy typ danych. Użyj 'int' dla liczb całkowitych lub 'real' dla liczb rzeczywistych.");
                    return;
                }
            }
        }

        Console.WriteLine($"Wygenerowano {n} losowych liczb typu {type} do pliku '{fileName}'.");
    }
}
