using System;

class Parent
{
    public string PublicMessage = "I am Public";

    private string PrivateMessage = "I am Private";

    protected string ProtectedMessage = "I am Protected";

    public void ShowPrivateMessage()
    {
        Console.WriteLine(PrivateMessage);
    }
}

class Child : Parent
{
    public void Display()
    {
        Console.WriteLine(PublicMessage);

        Console.WriteLine(ProtectedMessage);

        // Console.WriteLine(PrivateMessage); // Error
    }
}

class Program
{
    static void Main()
    {
        Parent parent = new Parent();

        Console.WriteLine(parent.PublicMessage);

        parent.ShowPrivateMessage();

        Child child = new Child();

        child.Display();
    }
}