using System.Collections.Concurrent;
using System.Text;

var address = $"C:/CodeForces/triplets.txt";
string[] text = File.ReadAllLines(address, Encoding.UTF8);
ConcurrentDictionary<string,int> triplets = new ConcurrentDictionary<string, int>();
var sample = "мамама";
var sample1 = "папапа";
Word word = new Word(sample, triplets);
Word word1 = new Word(sample1, triplets);
Thread myThread1 = new Thread(word.CountTriplets);
myThread1.Start();



record class Word(string Sample, ConcurrentDictionary<string, int> MyDict)
{
    public void CountTriplets()
    {
        var counter = Sample.Length - 2;
        for (int i = 0; i < counter; i++)
        {
            StringBuilder triplet = new StringBuilder();
            triplet.Append(Sample.Substring(i, 3));
            MyDict.AddOrUpdate(triplet.ToString(), 1, (s, i1) => i1+1 );
        }
    }
}
