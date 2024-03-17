using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonFilePath = "data.json"; // Dostosuj ścieżkę w razie potrzeby

            // 1. Deserializacja JSON z pliku i wyświetlanie przykładowych tweetów
            string json = File.ReadAllText(jsonFilePath);
            TweetsContainer tweets = JsonConvert.DeserializeObject<TweetsContainer>(json) ?? new TweetsContainer();

            Console.WriteLine("Przykładowe tweety:");
            for (int i = 0; i < Math.Min(5, tweets.Data.Count); i++) // Wyświetl maksymalnie 5 tweetów
            {
                var tweet = tweets.Data[i];
                Console.WriteLine($"Tweet #{i+1}:");
                Console.WriteLine($"Tekst: {tweet.Text}");
                Console.WriteLine($"Nazwa użytkownika: {tweet.UserName}");
                Console.WriteLine($"Data utworzenia: {tweet.CreatedAt}");
                Console.WriteLine($"Link do tweeta: {tweet.LinkToTweet}");
                Console.WriteLine($"Pierwszy link URL: {tweet.FirstLinkUrl}");
                Console.WriteLine($"Kod osadzenia tweeta: {tweet.TweetEmbedCode}");
                Console.WriteLine("-----------------------------------------");
            }
            Console.WriteLine("\n");

            // 2. Konwersja danych do formatu XML i ich wczytanie
            Console.WriteLine("Konwersja danych do formatu XML i ich wczytanie:");
            XmlDataHandler.SaveTweetsToXml("tweets.xml", tweets);
            TweetsContainer loadedTweetsFromXml = XmlDataHandler.LoadTweetsFromXml("tweets.xml");
            Console.WriteLine("Dane zapisane i wczytane z formatu XML.");
            Console.WriteLine("\n");

            // 3. Sortowanie tweetów
            Console.WriteLine("Sortowanie tweetów:");
            TweetSorter.SortTweetsByUserName(tweets.Data);
            TweetDateSorter.SortTweetsByCreatedAt(tweets.Data);
            Console.WriteLine("Tweety zostały posortowane.");
            Console.WriteLine("\n");

            // 4. Wypisanie najnowszego i najstarszego tweeta
            Tweet newestTweet = TweetDateFinder.FindNewestTweet(tweets.Data);
            Tweet oldestTweet = TweetDateFinder.FindOldestTweet(tweets.Data);
            Console.WriteLine("Najnowszy tweet:");
            if (newestTweet != null)
            {
                Console.WriteLine($"Tekst: {newestTweet.Text}");
                Console.WriteLine($"Nazwa użytkownika: {newestTweet.UserName}");
                Console.WriteLine($"Data utworzenia: {newestTweet.CreatedAt}");
            }
            else
            {
                Console.WriteLine("Brak tweetów.");
            }
            Console.WriteLine("\nNajstarszy tweet:");
            if (oldestTweet != null)
            {
                Console.WriteLine($"Tekst: {oldestTweet.Text}");
                Console.WriteLine($"Nazwa użytkownika: {oldestTweet.UserName}");
                Console.WriteLine($"Data utworzenia: {oldestTweet.CreatedAt}");
            }
            else
            {
                Console.WriteLine("Brak tweetów.");
            }
            Console.WriteLine("\n");

            // 5. Stworzenie i wypisanie słownika tweetów indeksowanego po nazwie użytkownika
            Console.WriteLine("Słownik tweetów indeksowany po nazwie użytkownika:");
            var tweetsDictionary = TweetDictionaryCreator.CreateTweetsDictionary(tweets.Data);
            string exampleUser = "OhNoSheTwitnt";
            Console.WriteLine($"Tweety użytkownika {exampleUser}:");
            if (tweetsDictionary.ContainsKey(exampleUser))
            {
                foreach (var tweet in tweetsDictionary[exampleUser])
                {
                    Console.WriteLine($"\tTekst: {tweet.Text}");
                    Console.WriteLine($"\tData utworzenia: {tweet.CreatedAt}");
                    Console.WriteLine("\t-----------------------------------------");
                }
            }
            else
            {
                Console.WriteLine($"Brak tweetów dla użytkownika {exampleUser}.");
            }
            Console.WriteLine("\n");

            // 6. Obliczanie i wypisanie częstości występowania słów
            Console.WriteLine("Częstość występowania słów:");
            var wordFrequencies = TweetWordFrequencyCalculator.CalculateWordFrequencies(tweets.Data);
            // Tu możesz dodać kod do wypisywania, jeśli chcesz
            Console.WriteLine("\n");

            // 7. Wypisanie 10 najczęściej występujących słów o długości co najmniej 5 liter
            Console.WriteLine("10 najczęściej występujących słów o długości co najmniej 5 liter:");
            foreach (var pair in wordFrequencies.OrderByDescending(pair => pair.Value).Where(pair => pair.Key.Length >= 5).Take(10))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            Console.WriteLine("\n");

            // 8. Obliczenie i wypisanie 10 słów o największej wartości IDF
            Console.WriteLine("10 słów o największej wartości IDF:");
            var idfScores = TweetIdfCalculator.CalculateIdf(tweets.Data);
            foreach (var pair in idfScores.OrderByDescending(pair => pair.Value).Take(10))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
