// Exercise03 - Primary Constructors in C# 12
// The constructor parameters appear directly in the class declaration.

Person person = new("Karthik", 24);
person.DisplayInfo();

internal sealed class Person(string name, int age)
{
    public string Name { get; } = name;
    public int Age { get; } = age;

    public void DisplayInfo()
    {
        Console.WriteLine("Person details");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
    }
}
