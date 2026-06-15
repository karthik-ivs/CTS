// Exercise21 - Pattern Matching
// Type patterns let one method handle several object shapes safely.

object[] values = [42, "pattern matching", 19.75, DateTime.Today, true];

foreach (object value in values)
{
    Describe(value);
}

static void Describe(object value)
{
    if (value is string text)
    {
        Console.WriteLine($"is pattern found a string with length {text.Length}");
    }

    string result = value switch
    {
        int number => $"int doubled: {number * 2}",
        string valueText => $"string uppercase: {valueText.ToUpperInvariant()}",
        double number => $"double rounded: {Math.Round(number)}",
        DateTime date => $"date: {date:yyyy-MM-dd}",
        _ => $"unsupported type: {value.GetType().Name}"
    };

    Console.WriteLine(result);
}
