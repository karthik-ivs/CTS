using System;

public record Employee // Like 'C' struct but with more features
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string Department { get; init; }
}

class Program
{
    static void Main()
    {
        Employee emp1 = new Employee
        {
            Id = 1,
            Name = "Karthik",
            Department = "IT"
        };

        Employee emp2 = emp1 with
        {
            Department = "HR"
        };

        Console.WriteLine("Original Record");
        Console.WriteLine(emp1);

        Console.WriteLine();

        Console.WriteLine("Modified Copy");
        Console.WriteLine(emp2);
    }
}