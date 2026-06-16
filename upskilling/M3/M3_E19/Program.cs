using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> students = new List<string>();

        students.Add("Karthik");
        students.Add("Rahul");
        students.Add("Anil");

        students.Remove("Rahul");

        Console.WriteLine("Students:");

        foreach (string student in students)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine();

        Dictionary<int, string> employees =
            new Dictionary<int, string>();

        employees.Add(101, "John");
        employees.Add(102, "David");
        employees.Add(103, "Mike");

        employees.Remove(102);

        Console.WriteLine("Employees:");

        foreach (KeyValuePair<int, string> emp in employees)
        {
            Console.WriteLine($"{emp.Key} : {emp.Value}");
        }
    }
}