using System.Diagnostics;
using ConsoleApp16;

var stopwatch = new Stopwatch();
string? address;

/*
string fileName = "SampleText.txt";
address = Path.Combine(Directory.GetCurrentDirectory(), fileName);*/
do
{
    Console.WriteLine("Введите адрес файла (в виде не пустой строки):");
    address = Console.ReadLine(); 
} while (address == string.Empty);
stopwatch.Start();
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

