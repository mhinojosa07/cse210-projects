using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        decimal shipping = _customer.LivesInUSA() ? 5 : 35;
        return total + shipping;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Product product in _products)
        {
            sb.AppendLine($"{product.Name} (ID: {product.ProductId})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }
}
