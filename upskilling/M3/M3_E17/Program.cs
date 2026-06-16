#nullable enable

using System;

class Contact
{
    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }
}

class Program
{
    static void Main()
    {
        Contact? contact = null;

        Console.WriteLine(contact?.Name?.ToUpper());

        contact = new Contact
        {
            Name = "Karthik",
            PhoneNumber = "9876543210"
        };

        Console.WriteLine(contact?.Name?.ToUpper());

        contact.Name = null;

        Console.WriteLine(contact?.Name?.ToUpper() ?? "Name Not Available");
    }
}