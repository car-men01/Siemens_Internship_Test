using SieMarket.Models;

namespace SieMarket.Services;

public class StoreService
{
    private readonly List<Order> _orders;

    public StoreService(List<Order> orders)
    {
        _orders = orders;
    }

    // Returns the name of the customer who has spent the most money across all their orders
    public string GetTopSpendingCustomer()
    {
        Dictionary<string, double> customerSpending = new Dictionary<string, double>();
        foreach (var order in _orders)        {
            double totalPrice = order.CalculateTotalPrice();
            if (customerSpending.ContainsKey(order.CustomerName))
            {
                customerSpending[order.CustomerName] += totalPrice; 
            }
            else
            {
                customerSpending[order.CustomerName] = totalPrice;
            }
        }
        return customerSpending.OrderByDescending(c => c.Value).FirstOrDefault().Key;
    }

    // Returns a dictionary of popular products and their total quantity sold
    // The popularity is determined by the top 5 selling products across all orders
    public Dictionary<string, int> GetPopularProducts()
    {
        Dictionary<string, int> productPopularity = new Dictionary<string, int>();
        foreach (var order in _orders)
        {
            foreach (var item in order.Items)
            {
                if (productPopularity.ContainsKey(item.ProductName))
                {
                    productPopularity[item.ProductName] += item.Quantity;
                }
                else
                {
                    productPopularity[item.ProductName] = item.Quantity;
                }
            }
        }
        productPopularity = productPopularity.OrderByDescending(p => p.Value)
                                             .Take(5)
                                             .ToDictionary(p => p.Key, p => p.Value);
        return productPopularity;
    }
}
