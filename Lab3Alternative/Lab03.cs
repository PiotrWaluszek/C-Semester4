class Lab03 {
    static void Main() {
        //zad1
        JsonHandler jsonHandler = new JsonHandler();
        Tweets tweets_json = jsonHandler.ReadFromJson("data.json");

        Console.WriteLine("From Json:\n" + tweets_json.data[0].ToString());

        //zad2
        XmlHandler xmlHandler = new XmlHandler();
        xmlHandler.WriteToXml("tweet.xml", tweets_json);

        Tweets tweets_xml = xmlHandler.ReadFromXml("tweet.xml");

        Console.WriteLine("\nFrom Xml:\n" + tweets_xml.data[0].ToString());

        //zad3 i 4
        TweetSorter.SortTweetsByUserName(tweets_json);
        Console.WriteLine("\nSorted By UserName:\n" + tweets_json.data[0].ToString());

        TweetSorter.SortTweetsByCreatedAt(tweets_xml);
        Console.WriteLine("\nSorted By CreatedAt (First):\n" + tweets_xml.data[0].ToString());
        Console.WriteLine("\nSorted By CreatedAt (Last):\n" + tweets_xml.data[tweets_xml.size - 1].ToString());          
        
        //zad5       
        var tweetsDictionary = TweetDictionaryCreator.CreateTweetsDictionary(tweets_json);
        string exampleUser = "cmclymer";
        Console.WriteLine($"\nTweety użytkownika {exampleUser}:");
        if (tweetsDictionary.ContainsKey(exampleUser))
        {
            foreach (var tweet in tweetsDictionary[exampleUser])
            {
                Console.WriteLine($"Tekst: {tweet.Text}");
                Console.WriteLine($"Data utworzenia: {tweet.CreatedAt}");
                Console.WriteLine("-----------------------------------------");
            }
        }
        else
        {
            Console.WriteLine($"Brak tweetów dla użytkownika {exampleUser}.");
        }
        Console.WriteLine("\n");

        //zad6 i 7      
        var wordFrequencies = tweets_json.CalculateWordFrequencies();
        Console.WriteLine($"Przykładowa częstość występowania słów:");
        foreach (var pair in wordFrequencies.Where(pair => pair.Key.Length >= 5).Take(5)) {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        Console.WriteLine("\n10 najczęściej występujących słów:");
        foreach (var pair in wordFrequencies.OrderByDescending(pair => pair.Value).Where(pair => pair.Key.Length >= 5).Take(10)) {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
        Console.WriteLine("\n");

        //zad8
        Dictionary<string, double> idfValues = tweets_json.CalculateIDF();
     
        var idfWords = idfValues.OrderByDescending(pair => pair.Value).Take(10);
       
        Console.WriteLine("10 słów z największym IDF:");
        foreach (var pair in idfWords) {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}