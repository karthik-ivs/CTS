// Exercise18 - required Modifier
// required tells the compiler that callers must initialize the property.

Student student = new()
{
    Id = 1,
    Name = "Rahul",
    Course = "C# and ADO.NET"
};

Console.WriteLine($"Student: {student.Id}, {student.Name}, {student.Course}");
Console.WriteLine("If Name or Course is omitted during initialization, the compiler reports an error.");

internal sealed class Student
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Course { get; init; }
}
