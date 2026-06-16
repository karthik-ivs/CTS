using System;

class Program
{
    static void Increase(ref int value)
    {
        value += 10;
    }

    static void Initialize(out int value)
    {
        value = 100;
    }

    static void Display(in int value)
    {
        Console.WriteLine(value);
    }

    static void Main()
    {
        int a = 5;

        Console.WriteLine($"Before ref: {a}");

        Increase(ref a);

        Console.WriteLine($"After ref: {a}");

        int b;

        Initialize(out b);

        Console.WriteLine($"Out value: {b}");

        Console.Write("In value: ");

        Display(in b);
    }
}