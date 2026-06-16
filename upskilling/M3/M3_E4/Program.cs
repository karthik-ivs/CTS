using System;

class Student
{
    public string Name { get; set; }
}

class Program
{
    static void Main()
    {
        var number = 100;

        var text = "Hello";

        Student student = new()
        {
            Name = "Karthik"
        };

        Console.WriteLine(number);
        Console.WriteLine(number.GetType());

        Console.WriteLine(text);
        Console.WriteLine(text.GetType());

        Console.WriteLine(student.Name);
        Console.WriteLine(student.GetType());
    }
}