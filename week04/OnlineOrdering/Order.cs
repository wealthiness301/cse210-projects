using System.Collections.Generic;
using System.Text;
public class Order
{
    private List<Product> _products;
    private Customer _customer;
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }
        if (_customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }
        return total;
    }
    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");

        foreach (var product in _products)
        {
            sb.AppendLine(product.GetPackingLabel());
        }
        return sb.ToString();
    }
    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Shipping Label:");
        sb.AppendLine(_customer.GetName());
        sb.AppendLine(_customer.GetAddress().GetFullAddress());
        return sb.ToString();
    }
}