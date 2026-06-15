// Exercise06 - Array Iteration
// The same array is visited with for, foreach, while, and do-while loops.

int[] numbers = [2, 4, 6, 8, 10, 12];

Console.WriteLine("for loop, skipping 6 with continue:");
for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] == 6)
    {
        continue;
    }

    Console.WriteLine(numbers[i]);
}

Console.WriteLine("\nforeach loop, stopping at 10 with break:");
foreach (int number in numbers)
{
    if (number == 10)
    {
        break;
    }

    Console.WriteLine(number);
}

Console.WriteLine("\nwhile loop:");
int index = 0;
while (index < numbers.Length)
{
    Console.WriteLine(numbers[index]);
    index++;
}

Console.WriteLine("\ndo-while loop:");
index = 0;
do
{
    Console.WriteLine(numbers[index]);
    index++;
} while (index < numbers.Length);
