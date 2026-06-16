using System;
using System.Collections.Generic;
using System.Linq;

class Order
{
    public int OrderId { get; set; }

    public string CustomerName { get; set; }

    public double TotalAmount { get; set; }
}

class Program
{
    static void Main()
    {
        List<Order> orders = new List<Order>
        {
            new Order
            {
                OrderId = 1,
                CustomerName = "Karthik",
                TotalAmount = 1500
            },

            new Order
            {
                OrderId = 2,
                CustomerName = "Rahul",
                TotalAmount = 500
            },

            new Order
            {
                OrderId = 3,
                CustomerName = "Anil",
                TotalAmount = 2500
            }
        };

        var result =
            orders
            .Where(o => o.TotalAmount > 1000)
            .Select(o => new
            {
                o.OrderId,
                o.CustomerName
            });

        foreach (var item in result)
        {
            Console.WriteLine(
                $"OrderId: {item.OrderId}, Customer: {item.CustomerName}");
        }
    }
}