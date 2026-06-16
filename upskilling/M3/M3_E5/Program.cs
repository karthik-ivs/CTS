using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Score: ");

        int score = Convert.ToInt32(Console.ReadLine()); // Taking input from the user and converting it into integer 32

        if (score < 0 || score > 100)
        {
            Console.WriteLine("Invalid Score");
            return;
        }

        string grade = score switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };

        Console.WriteLine("Grade: " + grade);
    }
}