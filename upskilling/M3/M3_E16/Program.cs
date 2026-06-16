#nullable enable

using System;

class Person
{
    public string? Name { get; set; }

    public string? Email { get; set; }
}

class Program
{
    static void Main()
    {
        Person? person = null;

        string name = person?.Name ?? "No Name Available";

        Console.WriteLine(name);

        person = new Person
        {
            Name = "Karthik",
            Email = null
        };

        Console.WriteLine(person?.Name);

        Console.WriteLine(person?.Email ?? "Email Not Provided");
    }
}