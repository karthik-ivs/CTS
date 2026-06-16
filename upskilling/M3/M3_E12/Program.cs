using System;

class Product
{
    public string Name { get; set; }

    private double _price;

    public double Price
    {
        get
        {
            return _price;
        }
        set
        {
            if (value >= 0)
                _price = value;
            else
                Console.WriteLine("Price cannot be negative.");
        }
    }
}

class Program
{
    static void Main()
    {
        Product p = new Product();

        p.Name = "Laptop";

        p.Price = 50000;

        Console.WriteLine($"Name : {p.Name}");
        Console.WriteLine($"Price: {p.Price}");

        Console.WriteLine();

        p.Price = -1000;

        Console.WriteLine($"Price After Validation: {p.Price}");
    }
}