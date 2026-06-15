// Exercise17 - Contact App
// Null-conditional chaining prevents exceptions when an object or property is null.

Contact? first = new() { Name = "Divya", PhoneNumber = "9876543210" };
Contact? second = new() { Name = null, PhoneNumber = "9000000000" };
Contact? third = null;

DisplayContactName(first);
DisplayContactName(second);
DisplayContactName(third);

static void DisplayContactName(Contact? contact)
{
    string displayName = contact?.Name?.ToUpperInvariant() ?? "Contact name is unavailable";
    Console.WriteLine(displayName);
}

internal sealed class Contact
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
}
