// Exercise10 - Constructors
// The default constructor sets fallback values; the parameterized one accepts real data.

Car defaultCar = new();
Car customCar = new("Toyota", "Corolla", 2024);

defaultCar.Display();
customCar.Display();

internal sealed class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car()
    {
        Make = "Unknown";
        Model = "Unknown";
        Year = DateTime.Now.Year;
    }

    public Car(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public void Display() => Console.WriteLine($"{Year} {Make} {Model}");
}
