using System;
using System.Collections.Generic;
using System.Globalization;

namespace lab3
{
    public class TweetDateSorter
    {
        // Funkcja sortująca tweety po dacie utworzenia
        public static void SortTweetsByCreatedAt(List<Tweet> tweets)
        {
            tweets.Sort((x, y) =>
            {
                DateTime xDate = DateTime.ParseExact(x.CreatedAt, "MMMM dd, yyyy 'at' hh:mmtt", CultureInfo.InvariantCulture);
                DateTime yDate = DateTime.ParseExact(y.CreatedAt, "MMMM dd, yyyy 'at' hh:mmtt", CultureInfo.InvariantCulture);
                return DateTime.Compare(xDate, yDate);
            });
        }
    }
}
