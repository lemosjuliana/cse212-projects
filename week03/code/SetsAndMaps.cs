using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // Creating a set to store the words 
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();
        // Creating a set to keep track of seen words
        // This ensures each pair is added only once.
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            // This part ignores same letter words. It is best practiced to check for duplicates
            // before adding to the set.
            if (word[0] == word[1]) // words like "aa" aren't considered...

                continue;

            var reversedWord = new string(new[] { word[1], word[0] });

            // Check for symmetric pair
            if (wordSet.Contains(reversedWord) && !seen.Contains(reversedWord))
            {
                result.Add($"{word} & {reversedWord}");
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            // Check if the line has at least 4 fields
          if (fields.Length >= 4)
            {
                // Get the degree from the 4th column (index 3)
                var degree = fields[3].Trim();
                // Check if the degree is in the dictionary
                // If it is, increment the count
                // if not, add it with a count of 1  
                if (degrees.ContainsKey(degree))
                    degrees[degree]++;
                else
                    degrees[degree] = 1;
            }
    }
    return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // Remove all spaces and convert to lowercase to deal with case sensitivity
        // Using Replace(" ", "") instead of just Trim(), becau
        // Trim() didn't work
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // Check if the lengths are different
        // words with different lengths can't be anagrams
        if (word1.Length != word2.Length)
            return false;

        // Count letters in word1 by using a dictionary
        var letterCount = new Dictionary<char, int>();
        foreach (var letter in word1)
        {
            // TryGetValue() is more efficient than ContainsKey() 
            // if letter is already in the dictionary, + 1 to the count
            // if not, add it with a count of 1
            if (letterCount.TryGetValue(letter, out int count))
                letterCount[letter] = count + 1;
            else
                letterCount[letter] = 1;
        }

        // Subtract letter counts using word2
        foreach (var letter in word2)
        {
            if (letterCount.TryGetValue(letter, out int count))
            {
                letterCount[letter] = count - 1;
                if (letterCount[letter] < 0)
                    return false; // More letters in word2 than in word1 (not an anagram)
            }
            else
            {
                // Letter in word2 not found in word1
                return false;
            }
        }

        // If all counts are zero, it's an anagram
        return letterCount.Values.All(v => v == 0);
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}