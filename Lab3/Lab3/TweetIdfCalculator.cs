using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab3
{
    public static class TweetIdfCalculator
    {
        // Obliczanie IDF dla każdego słowa
        public static Dictionary<string, double> CalculateIdf(List<Tweet> tweets)
        {
            // Słownik przechowujący liczbę dokumentów zawierających dane słowo
            var documentFrequency = new Dictionary<string, int>();
            int totalDocuments = tweets.Count;

            foreach (var tweet in tweets)
            {
                // Używając HashSet, aby uniknąć powtórzeń słów w jednym dokumencie
                var wordsInTweet = new HashSet<string>(
                    Regex.Replace(tweet.Text.ToLower(), @"http[^\s]+", string.Empty, RegexOptions.IgnoreCase)
                        .Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '-', '\n', '\r', '"', '(', ')', '@', '#' }, 
                        StringSplitOptions.RemoveEmptyEntries)
                        .Where(word => word.Length >= 5)
                );

                foreach (var word in wordsInTweet)
                {
                    if (!documentFrequency.ContainsKey(word))
                    {
                        documentFrequency[word] = 1;
                    }
                    else
                    {
                        documentFrequency[word]++;
                    }
                }
            }

            // Obliczanie IDF dla każdego słowa
            var idfScores = new Dictionary<string, double>();
            foreach (var pair in documentFrequency)
            {
                // Obliczanie wartości IDF zgodnie z definicją
                double idf = Math.Log10((double)totalDocuments / (1 + pair.Value));
                idfScores[pair.Key] = idf;
            }

            return idfScores;
        }
    }
}
