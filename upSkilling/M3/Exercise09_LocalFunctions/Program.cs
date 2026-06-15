// Exercise09 - Local Functions
// A local function keeps helper logic close to the method that uses it.

for (int value = 0; value <= 5; value++)
{
    Console.WriteLine($"{value}! = {CalculateFactorial(value)}");
}

static int CalculateFactorial(int number)
{
    if (number < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(number), "Factorial requires a non-negative number.");
    }

    return Factorial(number);

    static int Factorial(int current)
    {
        return current <= 1 ? 1 : current * Factorial(current - 1);
    }
}
