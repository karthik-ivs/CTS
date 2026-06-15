#nullable enable
// Exercise16 - Nullable References
// ? marks nullable references, ?. safely accesses members, and ?? supplies a fallback.

Person? missingPerson = null;
Person presentPerson = new() { Name = "Meera", Email = null };

PrintPerson(missingPerson);
PrintPerson(presentPerson);

static void PrintPerson(Person? person)
{
    string name = person?.Name ?? "No name available";
    string email = person?.Email?.ToLowerInvariant() ?? "No email available";

    Console.WriteLine($"Name: {name}");
    Console.WriteLine($"Email: {email}\n");
}

internal sealed class Person
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}
