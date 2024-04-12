using System.Globalization;
public class TweetSorter {
    public static void SortTweetsByUserName(Tweets tweets) {
        tweets.data.Sort((x, y) => string.Compare(x.UserName, y.UserName, StringComparison.OrdinalIgnoreCase));
    }

    public static void SortTweetsByCreatedAt(Tweets tweets) {
            tweets.data.Sort((x, y) => {
                DateTime xDate = DateTime.ParseExact(x.CreatedAt, "MMMM dd, yyyy 'at' hh:mmtt", CultureInfo.InvariantCulture);
                DateTime yDate = DateTime.ParseExact(y.CreatedAt, "MMMM dd, yyyy 'at' hh:mmtt", CultureInfo.InvariantCulture);
                return DateTime.Compare(xDate, yDate);
            });
    }
}