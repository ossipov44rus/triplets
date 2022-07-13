using System.Collections.Concurrent;
using System.Text;

namespace ConsoleApp16;

record  Words(string[] Sample, ConcurrentDictionary<string, int> MyDict)
{
    public void CountTriplets()
    {
        foreach (var j in Sample)
        {
            var wordArr = j.Split(' ');
            foreach (var word in wordArr)
            {
                if (word.Length >= 3)
                {
                    var counter = word.Length - 2;
                    for (int i = 0; i < counter; i++)
                    {
                        StringBuilder triplet = new StringBuilder();
                        triplet.Append(word.ToLower().Substring(i, 3));
                        MyDict.AddOrUpdate(triplet.ToString(), 1, (string s, int i1) => i1 + 1);
                    }
                }
            }
        }
    }
}