using System.Text.RegularExpressions;
public class Tweets
{
    public List<Tweet> ?data { get; set; }

    public int size {
        get {
            if (data == null)
                return 0;
            else
                return data.Count;
        }
    }

    public Dictionary<string, int> CalculateWordFrequencies() {
        var wordFrequencies = new Dictionary<string, int>();

        foreach (var tweet in data) {          
            string textWithoutUrls = Regex.Replace(tweet.Text, @"http[^\s]+", string.Empty, RegexOptions.IgnoreCase);

            var words = textWithoutUrls
                .ToLower() 
                .Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '-', '\n', '\r', '"', '(', ')', '@', '#'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words) {
                if (word.Length >= 5) {
                    if (!string.IsNullOrWhiteSpace(word)) {
                        if (wordFrequencies.ContainsKey(word)) {
                            wordFrequencies[word]++;
                        }
                        else {
                            wordFrequencies[word] = 1;
                        }
                    }
                }
            }
        }

        return wordFrequencies;
    }

    public Dictionary<string, double> CalculateIDF()
    {
        HashSet<string> allWords = new HashSet<string>();

        foreach (Tweet tweet in data) {
            string textWithoutUrls = Regex.Replace(tweet.Text, @"http[^\s]+", string.Empty, RegexOptions.IgnoreCase);

            var words = textWithoutUrls
                .ToLower() 
                .Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '-', '\n', '\r', '"', '(', ')', '@', '#'}, StringSplitOptions.RemoveEmptyEntries);          
            
            foreach (string word in words) {
                allWords.Add(word.ToLower());
            }
        }

        Dictionary<string, double> idfValues = new Dictionary<string, double>();
        int totalDocuments = data.Count;

        foreach (string word in allWords) {
            int documentsContainingWord = GetDocumentsContainingWord(word);
            double idf = Math.Log((double)totalDocuments / (documentsContainingWord));
            idfValues[word] = idf;
        }

        return idfValues;
    }

    private int GetDocumentsContainingWord(string word) {
        return data.Count(tweet => tweet.Text.ToLower().Contains(word.ToLower()));
    }
}

public class Tweet {
    public string ?Text { get; set; }
    public string ?UserName { get; set; }
    public string ?LinkToTweet { get; set; }
    public string ?FirstLinkUrl { get; set; }
    public string ?CreatedAt { get; set; }
    public string ?TweetEmbedCode { get; set; }

    public override string ToString() {
        return $"Text: {Text}\nUserName: {UserName}\nLinkToTweet: {LinkToTweet}\nFirstLinkUrl: {FirstLinkUrl}\nCreatedAt: {CreatedAt}\nTweetEmbedCode: {TweetEmbedCode }";
    }    
}