using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        Console.WriteLine("FOR LOOP");

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == 20)
                continue;

            Console.WriteLine(numbers[i]);
        }

        Console.WriteLine("\nFOREACH LOOP");

        foreach (int num in numbers)
        {
            if (num == 40)
                break;

            Console.WriteLine(num);
        }

        Console.WriteLine("\nWHILE LOOP");

        int j = 0;

        while (j < numbers.Length)
        {
            Console.WriteLine(numbers[j]);
            j++;
        }

        Console.WriteLine("\nDO-WHILE LOOP");

        int k = 0;

        do
        {
            Console.WriteLine(numbers[k]);
            k++;
        }
        while (k < numbers.Length);
    }
}