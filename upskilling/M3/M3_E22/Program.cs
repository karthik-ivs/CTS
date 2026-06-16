using System;

class Program
{
    static (int, string) GetStudent()
    {
        return (101, "Karthik");
    }

    static void Main()
    {
        (int id, string name) = GetStudent();

        Console.WriteLine($"ID   : {id}");
        Console.WriteLine($"Name : {name}");
    }
}