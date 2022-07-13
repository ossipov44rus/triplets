using System.Collections.Concurrent;
using System.Text;
namespace ConsoleApp16;

public class TripletCounter
{
    public static string? Address { get; set; }
    private readonly string[] _text = File.ReadAllLines(Address, Encoding.UTF8);
    public static  readonly ConcurrentDictionary<string, int> Triplets = new ConcurrentDictionary<string, int>();
   

    public void GetConcurrentDictionary()
    {
        switch (_text.Length)
        {
            case (1):
                Words firstWords = new Words(_text, Triplets);
                firstWords.CountTriplets();
                break;
            case(2):
                Words secondWords = new Words(_text, Triplets);
                secondWords.CountTriplets();
                break;
            case(3):
                Words thirdWords = new Words(_text, Triplets);
                thirdWords.CountTriplets();
                break;
            default:
                int numberOfStrings = _text.Length / 4;
                Span<string> textSpan = _text;
                Words forthWords1 = new Words(textSpan.Slice(0, numberOfStrings).ToArray(), Triplets);
                Words forthWords2 = new Words(textSpan.Slice(numberOfStrings, numberOfStrings).ToArray(), Triplets);
                Words forthWords3 = new Words(textSpan.Slice(numberOfStrings*2, numberOfStrings).ToArray(), Triplets);
                Words forthWords4 = new Words(textSpan.Slice(numberOfStrings*3).ToArray(), Triplets);
                Thread forthThread1 = new Thread(forthWords1.CountTriplets);
                Thread forthThread2 = new Thread(forthWords2.CountTriplets);
                Thread forthThread3 = new Thread(forthWords3.CountTriplets);
                Thread forthThread4 = new Thread(forthWords4.CountTriplets);
                forthThread1.Start();
                forthThread2.Start();
                forthThread3.Start();
                forthThread4.Start();
                forthThread4.Join();
                break;
        }
    }
}