using System;

class Student
{
    public required string Name { get; set; }

    public required int RollNumber { get; set; }

    public string Course { get; set; } = "C#";
}

class Program
{
    static void Main()
    {
        Student student = new Student
        {
            Name = "Karthik",
            RollNumber = 101
        };

        Console.WriteLine($"Name: {student.Name}");
        Console.WriteLine($"Roll No: {student.RollNumber}");
        Console.WriteLine($"Course: {student.Course}");
    }
}