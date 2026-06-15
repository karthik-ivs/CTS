// Exercise07 - Method Overloading
// The compiler selects the correct CalculateTotal method based on arguments.

Console.WriteLine($"Two integers: {Calculator.CalculateTotal(10, 20)}");
Console.WriteLine($"Three doubles: {Calculator.CalculateTotal(12.5, 3.75, 9.25)}");
Console.WriteLine($"Array of numbers: {Calculator.CalculateTotal([1.5, 2.5, 3.0, 4.0])}");

internal static class Calculator
{
    public static int CalculateTotal(int first, int second) => first + second;

    public static double CalculateTotal(double first, double second, double third) => first + second + third;

    public static double CalculateTotal(double[] numbers) => numbers.Sum();
}
