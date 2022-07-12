using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;

var stopwatch = new Stopwatch();
stopwatch.Start();
Thread currentThread = Thread.CurrentThread;
currentThread.Name = "Main";
var address = $"C:/CodeForces/triplets.txt";
string[] text = File.ReadAllLines(address, Encoding.UTF8);
ConcurrentDictionary<string,int> triplets = new ConcurrentDictionary<string, int>();
foreach (var j in text)
{
    var samples = j.Split(' ');
    int sampleCount = samples.Length;
    foreach (var k in samples)
    {
        Word myWord = new Word(k,triplets);
        Thread testThread = new Thread(myWord.CountTriplets);
        testThread.Start();
        testThread.Join();
    }
}

foreach (var i in triplets)
{
    Console.WriteLine($"{i.Key}-{i.Value}");
}
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);


record  Word(string Sample, ConcurrentDictionary<string, int> MyDict)
{
    public void CountTriplets()
    {
        if (Sample.Length >= 3)
        {
            var counter = Sample.Length - 2;
            for (int i = 0; i < counter; i++)
            {
                StringBuilder triplet = new StringBuilder();
                triplet.Append(Sample.Substring(i, 3));
                MyDict.AddOrUpdate(triplet.ToString(), 1, (string s,int i1) => i1+1 );
            }
        }
        
    }
}
