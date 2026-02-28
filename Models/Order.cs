namespace SieMarket.Models;

public class Order
{
    public int OrderId { get; set;}
    public required string CustomerName { get; set;}
    public List<OrderItem> Items { get; set;} = new List<OrderItem>();

    // Calculates the total price of an order, applying a 10% discount if the total exceeds 500
    public double CalculateTotalPrice()
    {
        double total = 0;
        foreach (var item in Items)
        {
            total += item.UnitPrice * item.Quantity;
        }
        if (total > 500)
        {
            var discount = total * 0.10; // 10% discount
            total -= discount;
        }
        return total;
    }
}
