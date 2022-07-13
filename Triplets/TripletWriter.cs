using System.Collections.Concurrent;

namespace ConsoleApp16;

public class TripletWriter
{
    public ConcurrentDictionary<string,int> Triplets { get; set; }

    public void TripleWrite()
    {
        var a = Triplets.Values;
        var b = a.OrderByDescending(x => x);
        var counter = 0;
        foreach (var i in b)
        {
            if (counter < 10)
            {
                int myValue;
                var key = Triplets.FirstOrDefault(x => x.Value == i).Key;
                Console.Write($"{key}, ");
                Triplets.TryRemove(key, out myValue);
                counter++;
            }
            else
            {
                break;
            }
        }
    }
}