using System;
using System.Collections.Generic;
using System.Globalization;

namespace lab3
{
    public class TweetSorter
    {
        // Funkcja sortująca tweety po nazwie użytkownika
        public static void SortTweetsByUserName(List<Tweet> tweets)
        {
            tweets.Sort((x, y) => string.Compare(x.UserName, y.UserName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
