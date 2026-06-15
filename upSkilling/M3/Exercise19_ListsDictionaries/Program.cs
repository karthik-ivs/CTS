// Exercise19 - Lists and Dictionaries
// List<T> stores ordered items; Dictionary<TKey,TValue> stores key-value pairs.

List<string> cities = ["Chennai", "Bengaluru"];
cities.Add("Hyderabad");
cities.Remove("Bengaluru");

Console.WriteLine("Cities:");
foreach (string city in cities)
{
    Console.WriteLine(city);
}

Dictionary<int, string> employees = new()
{
    [101] = "Anu",
    [102] = "Vikram"
};
employees.Add(103, "Farah");
employees.Remove(102);

Console.WriteLine("\nEmployees:");
foreach (KeyValuePair<int, string> employee in employees)
{
    Console.WriteLine($"{employee.Key}: {employee.Value}");
}
