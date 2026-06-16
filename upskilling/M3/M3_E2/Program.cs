using System;

class Student
{
    public string Name;
}

class Program
{
    static void ChangeInt(int x)
    {
        x = 100;
    }

    static void ChangeStudent(Student s)
    {
        s.Name = "Karthik";
    }

    static void Main()
    {
        int num = 10;

        Student st = new Student();
        st.Name = "John";

        Console.WriteLine($"Before Int: {num}");
        ChangeInt(num);
        Console.WriteLine($"After Int: {num}");

        Console.WriteLine($"Before Name: {st.Name}");
        ChangeStudent(st);
        Console.WriteLine($"After Name: {st.Name}");
    }
}