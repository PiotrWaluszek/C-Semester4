using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Proszę podać nazwę pliku i ciąg znaków do znalezienia jako argumenty.");
            return;
        }

        string fileName = args[0];
        string searchString = args[1];
        int lineNumber = 0;

        try
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    lineNumber++;
                    string line = sr.ReadLine();
                    int position = line.IndexOf(searchString);

                    while (position != -1)
                    {
                        Console.WriteLine($"linijka: {lineNumber}, pozycja: {position + 1}");
                        position = line.IndexOf(searchString, position + 1);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Wystąpił błąd: {e.Message}");
        }
    }
}
