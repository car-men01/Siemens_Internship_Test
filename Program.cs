using SieMarket.Models;
using SieMarket.Services;

// Create orders
var orders = new List<Order>
{
    new Order
    {
        OrderId = 1,
        CustomerName = "Carmen",
        Items = new List<OrderItem>
        {
            new OrderItem { ProductName = "Laptop", Quantity = 2, UnitPrice = 1200 },
            new OrderItem { ProductName = "Mouse", Quantity = 1, UnitPrice = 25 }
        }
    },
    new Order
    {
        OrderId = 2,
        CustomerName = "Mihai",
        Items = new List<OrderItem>
        {
            new OrderItem { ProductName = "Monitor", Quantity = 2, UnitPrice = 300 },
            new OrderItem { ProductName = "Keyboard", Quantity = 3, UnitPrice = 100 },
            new OrderItem { ProductName = "Mouse", Quantity = 1, UnitPrice = 25 }
        }
    },
    new Order
    {
        OrderId = 3,
        CustomerName = "Carmen",
        Items = new List<OrderItem>
        {
            new OrderItem { ProductName = "Headphones", Quantity = 1, UnitPrice = 150 },
            new OrderItem { ProductName = "Mouse", Quantity = 1, UnitPrice = 25 }
        }
    },
    new Order
    {
        OrderId = 4,
        CustomerName = "Alex",
        Items = new List<OrderItem>
        {
            new OrderItem { ProductName = "Phone", Quantity = 4, UnitPrice = 1400 },
            new OrderItem { ProductName = "TV", Quantity = 1, UnitPrice = 3000 },
            new OrderItem { ProductName = "Type C Cable", Quantity = 1, UnitPrice = 40 }
        }
    } 
};



var service = new StoreService(orders);

// Display the final price of the orders
Console.WriteLine($"Total price for Order 1: {orders[0].CalculateTotalPrice()}");
Console.WriteLine($"Total price for Order 2: {orders[1].CalculateTotalPrice()}");
Console.WriteLine($"Total price for Order 3: {orders[2].CalculateTotalPrice()}\n");

// Display the top spending customer
Console.WriteLine("Top spending customer:");
Console.WriteLine(service.GetTopSpendingCustomer());

// Display the popular products
Console.WriteLine("\nPopular products:");
var popular = service.GetPopularProducts();
foreach (var (product, quantity) in popular)
    Console.WriteLine($"{product}: {quantity}");
