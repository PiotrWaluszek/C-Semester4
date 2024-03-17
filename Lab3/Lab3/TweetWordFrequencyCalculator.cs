using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab3
{
    public static class TweetWordFrequencyCalculator
    {
        public static Dictionary<string, int> CalculateWordFrequencies(List<Tweet> tweets)
        {
            var wordFrequencies = new Dictionary<string, int>();

            foreach (var tweet in tweets)
            {
                // Usuwanie URL z tekstu tweeta
                string textWithoutUrls = Regex.Replace(tweet.Text, @"http[^\s]+", string.Empty, RegexOptions.IgnoreCase);

                var words = textWithoutUrls
                    .ToLower() // Przekształć tekst na małe litery, aby zapewnić niezależność od wielkości liter
                    .Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '-', '\n', '\r', '"', '(', ')', '@', '#'}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (word.Length >= 5 && !word.StartsWith("https") && !word.Contains("://"))
                    {
                        if (!string.IsNullOrWhiteSpace(word))
                        {
                            if (wordFrequencies.ContainsKey(word))
                            {
                                wordFrequencies[word]++;
                            }
                            else
                            {
                                wordFrequencies[word] = 1;
                            }
                        }
                    }
                }
            }

            return wordFrequencies;
        }
    }
}
