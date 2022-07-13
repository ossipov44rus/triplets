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
                Span<string> textSpan2 = _text;
                Words secondWords1 = new Words(textSpan2.Slice(0,1).ToArray(), Triplets);
                Words secondWords2 = new Words(textSpan2.Slice(1).ToArray(), Triplets);
                Thread secondThread1 = new Thread(secondWords1.CountTriplets);
                Thread secondThread2 = new Thread(secondWords2.CountTriplets);
                secondThread1.Start();
                secondThread2.Start();
                secondThread2.Join();
                break;
            case(3):
                Span<string> textSpan3 = _text;
                Words thirdWords1 = new Words(textSpan3.Slice(0,1).ToArray(), Triplets);
                Words thirdWords2 = new Words(textSpan3.Slice(1,1).ToArray(), Triplets);
                Words thirdWords3 = new Words(textSpan3.Slice(2,1).ToArray(), Triplets);
                Thread thirdThread1 = new Thread(thirdWords1.CountTriplets);
                Thread thirdThread2 = new Thread(thirdWords2.CountTriplets);
                Thread thirdThread3 = new Thread(thirdWords3.CountTriplets);
                thirdThread1.Start();
                thirdThread2.Start();
                thirdThread3.Start();
                thirdThread3.Join();
                break;
            default:
                int numberOfStrings = _text.Length / 4;
                Span<string> textSpan4 = _text;
                Words forthWords1 = new Words(textSpan4.Slice(0, numberOfStrings).ToArray(), Triplets);
                Words forthWords2 = new Words(textSpan4.Slice(numberOfStrings, numberOfStrings).ToArray(), Triplets);
                Words forthWords3 = new Words(textSpan4.Slice(numberOfStrings*2, numberOfStrings).ToArray(), Triplets);
                Words forthWords4 = new Words(textSpan4.Slice(numberOfStrings*3).ToArray(), Triplets);
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