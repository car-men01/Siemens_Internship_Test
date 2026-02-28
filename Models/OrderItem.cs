namespace SieMarket.Models;

public class OrderItem
{
    public required string ProductName { get; set;}
    public int Quantity { get; set;}
    public double UnitPrice { get; set;}
}
