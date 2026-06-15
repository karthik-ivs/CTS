// Exercise12 - Auto Properties and Backing Fields
// Name is an auto-property; Price uses a backing field so validation can run.

Product product = new() { Name = "Notebook", Price = 75.50m };
Console.WriteLine(product);

try
{
    product.Price = -10m;
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Validation blocked invalid price: {ex.Message}");
}

internal sealed class Product
{
    private decimal _price;

    public string Name { get; set; } = string.Empty;

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Price cannot be negative.");
            }

            _price = value;
        }
    }

    public override string ToString() => $"{Name}: {Price:C}";
}
