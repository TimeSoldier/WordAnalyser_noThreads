using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

internal class Program
{
    public static Stopwatch watch = new Stopwatch();
    public static string[] words;
    public static string fileText;
    public static void MostCommonWord()
    {

        Dictionary<string, int> mostCommon = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (mostCommon.ContainsKey(word)) { }
            else
            {
                mostCommon.Add(word, 1);
            }


        }
        int placeHolder = 1;
        foreach (string word in words)
        {
            foreach (var item in mostCommon)
            {
                if (word == item.Key) mostCommon[word]++;
                if (mostCommon[word] > placeHolder) placeHolder = mostCommon[word];
            }
        }
        List<string> mostComm = new List<string>();
        foreach (var item in mostCommon)
        {
            if (item.Value == placeHolder)
                mostComm.Add(item.Key);
        }
        if (mostComm.Count > 1)
        {
            Console.Write("Most common words(" + mostComm.Count + ") are ");
            foreach (string w in mostComm)
            {

                Console.Write(w + ", ");
            }
            Console.WriteLine("and are used " + placeHolder + " times (..." + watch.ElapsedMilliseconds + ")");
        }
        else
        {
            string most = mostComm.First();
            Console.WriteLine("The most common word is: " + most + " and is used " + placeHolder + " times (..." + watch.ElapsedMilliseconds + ")");
        }
        Console.WriteLine();



    }
    public static void LeastCommonWord()
    {
        Dictionary<string, int> leastCommon = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (leastCommon.ContainsKey(word)) { }
            else
            {
                leastCommon.Add(word, 1);
            }


        }
        int placeHolder = words.Length;
        foreach (string word in words)
        {
            foreach (var item in leastCommon)
            {
                if (word == item.Key) leastCommon[word]++;

            }
            if (leastCommon[word] < placeHolder) placeHolder = leastCommon[word];
        }
        List<string> leastComm = new List<string>();
        foreach (var item in leastCommon)
        {
            if (item.Value == placeHolder)
                leastComm.Add(item.Key);
        }
        if (leastComm.Count > 1)
        {
            Console.Write("Least common words (" + leastComm.Count + ") are ");
            foreach (string w in leastComm)
            {

                Console.Write(w + ", ");
            }
            Console.WriteLine("and are used " + placeHolder + " times (..." + watch.ElapsedMilliseconds + ")");
        }
        else
        {
            string most = leastComm.First();
            Console.WriteLine("The least common word is: " + most + " and is used " + placeHolder + " times (..." + watch.ElapsedMilliseconds + ")");
        }
        Console.WriteLine();



    }
    public static void WordCount()
    {

        int count = 0;
        foreach (string word in words)
        {
            if (word.Length > 2) count++;
        }
        Console.WriteLine("The word count is " + count + "(..." + watch.ElapsedMilliseconds + ")");
        Console.WriteLine();
    }
    public static void AverageLenght()
    {
        int letters = 0;
        foreach (string word in words)
        {
            if (word.Length > 2)
                letters = letters + word.Length;
        }
        int count = 0;
        foreach (string word in words)
        {
            if (word.Length > 2) count++;
        }
        Console.WriteLine("The average word lenght is " + letters / count + "(..." + watch.ElapsedMilliseconds + ")");
        Console.WriteLine();
    }
    public static void LongestWords()
    {
        bool buffer = true;
        List<string> longest = new List<string>();
        int i = 0;
        foreach (string w in words)
        {
            if (w.Length > i)
            {
                i = w.Length;
            }
        }
        foreach (string w in words)
        {
            if (w.Length == i)
            {

                foreach (string word in longest)
                {
                    buffer = true;
                    if (w == word)
                    {

                        buffer = false;
                        break;
                    }

                }
                if (buffer == true) longest.Add(w);

            }
        }
        if (longest.Count > 1)
        {
            Console.Write("Longest words are " + longest.Count + ": ");
            foreach (string w in longest)
            {

                Console.Write(w + ", ");
            }
            Console.Write("and they contain " + i + " letters" + "(..." + watch.ElapsedMilliseconds + ")");
        }
        else
        {
            string oneLongestWord = longest.First();
            Console.WriteLine("The longest word is: " + oneLongestWord + " and is " + i + " letters long" + "(..." + watch.ElapsedMilliseconds + ")");
        }
        Console.WriteLine();

    }
    public static void ShortestWords()
    {
        bool buffer = true;
        List<string> shortest = new List<string>();
        int i = 100;
        foreach (string w in words)
        {
            if (w.Length < i && w.Length > 2)
            {
                i = w.Length;
            }
        }
        foreach (string w in words)
        {
            if (w.Length == i)
            {

                foreach (string word in shortest)
                {
                    buffer = true;
                    if (w == word)
                    {

                        buffer = false;
                        break;
                    }

                }
                if (buffer == true) shortest.Add(w);

            }
        }
        if (shortest.Count > 1)
        {
            Console.Write("Shortest words are " + shortest.Count + ": ");
            foreach (string w in shortest)
            {

                Console.Write(w + ", ");
            }
            Console.WriteLine("and they contain " + i + " letters" + "(..." + watch.ElapsedMilliseconds + ")");
        }
        else
        {
            string oneShortestWord = shortest.First();
            Console.WriteLine("The shortest word is: " + oneShortestWord + " and is " + i + " letters long" + "(..." + watch.ElapsedMilliseconds + ")");
        }
        Console.WriteLine();


    }


    
    static void Main(string[] args)
    {

        Console.WriteLine("Please enter text address");
        bool success = false;
        string address = "";
        while (!success)
        {
            try
            {
                address = Console.ReadLine();
                fileText = File.ReadAllText(address);
                success = true;
                Console.WriteLine("The address is correct");
            }
            catch (Exception)
            {
                Console.WriteLine("You`ve entered wrong adress.");
            }
        }
        
        watch.Start();

        string[] delimiterStrings = { " ", ",", ".", ":", "\n", ";", "_", "!", "?", "\t", "\r", "“", "(", ")", "’", "”", "n’t", "’d", "’s", "\"", "‘", "…" };
        words = fileText.Split(delimiterStrings, System.StringSplitOptions.RemoveEmptyEntries);

        Thread a = new Thread(ShortestWords);
        a.Start();
        Thread b = new Thread(LongestWords);
        b.Start();
        Thread c = new Thread(WordCount);
        c.Start();
        Thread d = new Thread(LeastCommonWord);
        d.Start();
        Thread e = new Thread(MostCommonWord);
        e.Start();
        Thread f = new Thread(AverageLenght);
        f.Start();
        a.Join();
        b.Join();
        c.Join();
        d.Join();
        e.Join();
        f.Join();

        Console.WriteLine( "(..." +  watch.ElapsedMilliseconds + ")");

    }

}
