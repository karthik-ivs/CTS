// Exercise24 - JSON Serialization
// System.Text.Json converts objects to JSON and back again.

using System.Text.Json;

User user = new() { Name = "Leela", Age = 29, Email = "leela@example.com" };
string filePath = Path.Combine(AppContext.BaseDirectory, "user.json");

JsonSerializerOptions options = new() { WriteIndented = true };
string json = JsonSerializer.Serialize(user, options);
File.WriteAllText(filePath, json);

string savedJson = File.ReadAllText(filePath);
User? restoredUser = JsonSerializer.Deserialize<User>(savedJson);

Console.WriteLine("Serialized JSON:");
Console.WriteLine(savedJson);
Console.WriteLine("\nDeserialized object:");
Console.WriteLine($"{restoredUser?.Name}, {restoredUser?.Age}, {restoredUser?.Email}");

internal sealed class User
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Email { get; set; } = string.Empty;
}
