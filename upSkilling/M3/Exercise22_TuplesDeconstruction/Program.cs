// Exercise22 - Tuples
// A tuple can return multiple values without creating a separate class.

(int id, string name) = GetEmployee();

Console.WriteLine($"Employee id: {id}");
Console.WriteLine($"Employee name: {name}");

static (int, string) GetEmployee()
{
    return (501, "Nisha");
}
