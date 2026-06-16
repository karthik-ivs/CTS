using System;
using System.IO;
using System.Text.Json;

class User
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string Email { get; set; }
}

class Program
{
    static void Main()
    {
        User user = new User
        {
            Name = "Karthik",
            Age = 22,
            Email = "karthik@gmail.com"
        };

        string json =
            JsonSerializer.Serialize(user,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText("user.json", json);

        Console.WriteLine("JSON Saved");

        string jsonFromFile =
            File.ReadAllText("user.json");

        User loadedUser =
            JsonSerializer.Deserialize<User>(jsonFromFile);

        Console.WriteLine();

        Console.WriteLine($"Name  : {loadedUser.Name}");
        Console.WriteLine($"Age   : {loadedUser.Age}");
        Console.WriteLine($"Email : {loadedUser.Email}");
    }
}