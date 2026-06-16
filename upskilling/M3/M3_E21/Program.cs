using System;

class Program
{
    static void DisplayInfo(object obj)
    {
        if (obj is int number)
        {
            Console.WriteLine($"Integer: {number}");
        }
        else if (obj is string text)
        {
            Console.WriteLine($"String: {text}");
        }

        string result = obj switch
        {
            int n => $"Square = {n * n}",
            string s => $"Length = {s.Length}",
            double d => $"Double Value = {d}",
            DateTime dt => $"Date = {dt:d}",
            _ => "Unknown Type"
        };

        Console.WriteLine(result);
    }

    static void Main()
    {
        DisplayInfo(10);

        Console.WriteLine();

        DisplayInfo("Karthik");

        Console.WriteLine();

        DisplayInfo(12.5);

        Console.WriteLine();

        DisplayInfo(DateTime.Now);
    }
}