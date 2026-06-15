// Exercise20 - LINQ
// Where filters a sequence; Select projects each item into a new shape.

List<Order> orders =
[
    new(1, "Asha", 1200m),
    new(2, "Bala", 450m),
    new(3, "Charu", 2500m)
];

var premiumOrders = orders
    .Where(order => order.TotalAmount >= 1000m)
    .Select(order => new
    {
        order.OrderId,
        Customer = order.CustomerName,
        Amount = order.TotalAmount
    });

foreach (var order in premiumOrders)
{
    Console.WriteLine($"Order {order.OrderId}: {order.Customer} spent {order.Amount:C}");
}

internal sealed record Order(int OrderId, string CustomerName, decimal TotalAmount);
