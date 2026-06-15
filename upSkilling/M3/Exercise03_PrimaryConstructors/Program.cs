using System;

class Person(string Name, int Age)
{ // Function like constructor
    public string name {get; set;} = Name;
    public int age {get; set;} = Age;

    public void Diaplay()
    {
        Console.WriteLine("Name: "+name);
        Console.WriteLine("Age: "+age);
    }
}

class Program
{
    static void Main(){
        Person p = new Person("IVS",20);
        p.Diaplay();
    }
}