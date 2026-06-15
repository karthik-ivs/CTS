// Exercise13 - Records and init
// init properties are set during creation; with creates a changed copy.

Employee original = new() { Id = 101, Name = "Asha", Department = "Finance" };
Employee updated = original with { Department = "Analytics" };

Console.WriteLine($"Original: {original}");
Console.WriteLine($"Updated copy: {updated}");

internal sealed record Employee
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Department { get; init; } = string.Empty;
}
