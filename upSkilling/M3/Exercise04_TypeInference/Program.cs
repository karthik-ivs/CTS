// Exercise04 - Type Inference
// var lets the compiler infer the type; target-typed new() uses the left-side type.

var count = 42;
var title = "C# Type Inference";
var amount = 125.75m;
Product product = new("Keyboard", 1499.00m);

PrintValue("count", count);
PrintValue("title", title);
PrintValue("amount", amount);
PrintValue("product", product);

static void PrintValue<T>(string name, T value)
{
    Console.WriteLine($"{name}: {value}");
    Console.WriteLine($"Inferred type: {typeof(T).FullName}\n");
}

internal sealed record Product(string Name, decimal Price);
