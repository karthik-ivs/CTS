// Exercise02 - Value Types vs Reference Types
// Value types are copied when passed by value; reference type variables copy the reference.

int number = 10;
double price = 99.50;
string message = "Original string";
SampleBox box = new() { Label = "Original box" };

Console.WriteLine("Before method calls:");
PrintValues(number, price, message, box);

TryChangeInt(number);
TryChangeDouble(price);
TryChangeString(message);
ChangeBox(box);

Console.WriteLine("\nAfter method calls:");
PrintValues(number, price, message, box);

static void TryChangeInt(int value) => value = 100;

static void TryChangeDouble(double value) => value = 500.75;

static void TryChangeString(string value) => value = "Changed string";

static void ChangeBox(SampleBox value) => value.Label = "Changed box";

static void PrintValues(int number, double price, string message, SampleBox box)
{
    Console.WriteLine($"int: {number}");
    Console.WriteLine($"double: {price}");
    Console.WriteLine($"string: {message}");
    Console.WriteLine($"custom class Label: {box.Label}");
}

internal sealed class SampleBox
{
    public string Label { get; set; } = string.Empty;
}
