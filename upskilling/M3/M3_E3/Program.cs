class Person(string firstName, int age)
{
    public string FirstName { get; set; } = firstName;
    public int Age { get; set; } = age;

    public void Display()
    {
        Console.WriteLine($"Name: {FirstName}");
        Console.WriteLine($"Age: {Age}");
    }
}

class Program
{
    static void Main()
    {
        Person p = new Person("Karthik", 22);
        p.Display();
    }
}