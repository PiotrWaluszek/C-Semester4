using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace lab3
{
    public class TweetDateFinder
    {
        // Funkcja znajdująca najnowszy tweet
        public static Tweet FindNewestTweet(List<Tweet> tweets)
        {
            return tweets
                .OrderByDescending(tweet => DateTime.ParseExact(tweet.CreatedAt, "MMMM dd, yyyy 'at' hh:mmtt", CultureInfo.InvariantCulture))
                .FirstOrDefault();
        }

        // Funkcja znajdująca najstarszy tweet
        public static Tweet FindOldestTweet(List<Tweet> tweets)
        {
            return tweets
                .OrderBy(tweet => DateTime.ParseExact(tweet.CreatedAt, "MMMM dd, yyyy 'at' hh:mmtt", CultureInfo.InvariantCulture))
                .FirstOrDefault();
        }
    }
}
