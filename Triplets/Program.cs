using System.Diagnostics;
using ConsoleApp16;

var stopwatch = new Stopwatch();
stopwatch.Start();
string? address;
do
{
    Console.WriteLine("Введите адрес файла (в виде не пустой строки):");
    address = Console.ReadLine(); 
} while (address == string.Empty);
TripletCounter.Address = address;
var triplets = TripletCounter.Triplets;
TripletCounter tripCount = new TripletCounter();
tripCount.GetConcurrentDictionary();
TripletWriter tripWrite = new TripletWriter();
tripWrite.Triplets = triplets;
tripWrite.TripleWrite();

stopwatch.Stop();
Console.WriteLine();
Console.WriteLine(stopwatch.ElapsedMilliseconds);

