using System;
using System.Net;

class Program
{
    static void Main()
    {
        Console.Write("Enter Text: ");

        string input = Console.ReadLine();

        string sanitized =
            WebUtility.HtmlEncode(input);

        Console.WriteLine();

        Console.WriteLine("Original:");
        Console.WriteLine(input);

        Console.WriteLine();

        Console.WriteLine("Sanitized:");
        Console.WriteLine(sanitized);
    }
}