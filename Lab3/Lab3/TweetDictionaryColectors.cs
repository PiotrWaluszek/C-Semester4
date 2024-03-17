using System.Collections.Generic;

namespace lab3
{
    public static class TweetDictionaryCreator
    {
        public static Dictionary<string, List<Tweet>> CreateTweetsDictionary(List<Tweet> tweets)
        {
            var tweetsDictionary = new Dictionary<string, List<Tweet>>();

            foreach (var tweet in tweets)
            {
                // Sprawdzanie, czy słownik już zawiera klucz (username)
                if (!tweetsDictionary.ContainsKey(tweet.UserName))
                {
                    // Jeśli nie zawiera, dodaj nową parę klucz-wartość z pustą listą
                    tweetsDictionary[tweet.UserName] = new List<Tweet>();
                }
                // Dodawanie tweeta do listy dla danego username
                tweetsDictionary[tweet.UserName].Add(tweet);
            }

            return tweetsDictionary;
        }
    }
}
