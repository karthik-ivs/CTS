using System;

class Calculator
{
    public int CalculateTotal(int a, int b)
    {
        return a + b;
    }

    public double CalculateTotal(double a, double b, double c)
    {
        return a + b + c;
    }

    public int CalculateTotal(int[] numbers)
    {
        int sum = 0;

        foreach (int num in numbers)
        {
            sum += num;
        }

        return sum;
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();

        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(calc.CalculateTotal(a, b));

        Console.WriteLine(calc.CalculateTotal(a, b, c));

        Console.WriteLine(calc.CalculateTotal(new int[] { 1, 2, 3, 4 }));
    }
}