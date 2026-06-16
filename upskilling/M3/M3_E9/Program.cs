using System;

class Program
{
    static int CalculateFactorial(int n)
    {
        int Factorial(int x)
        {
            if (x <= 1)
                return 1;

            return x * Factorial(x - 1);
        }

        return Factorial(n);
    }

    static void Main()
    {
        int value = Convert.ToInt32(Console.ReadLine());
        int result = CalculateFactorial(value);

        Console.WriteLine($"Factorial = {result}");
    }
}