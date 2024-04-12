public static class TweetDictionaryCreator {
    public static Dictionary<string, List<Tweet>> CreateTweetsDictionary(Tweets tweets) {
        var tweetsDictionary = new Dictionary<string, List<Tweet>>();

        foreach (var tweet in tweets.data) {                
            if (!tweetsDictionary.ContainsKey(tweet.UserName)) {                    
                tweetsDictionary[tweet.UserName] = new List<Tweet>();
            }
            
            tweetsDictionary[tweet.UserName].Add(tweet);
        }

        return tweetsDictionary;
    }
}