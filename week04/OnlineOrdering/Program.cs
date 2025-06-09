using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1
        Address address1 = new Address("123 Maple St", "Seattle", "WA", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B101", 12.99m, 2));
        order1.AddProduct(new Product("Pen Set", "P202", 5.50m, 3));

        // Order 2
        Address address2 = new Address("456 King Rd", "London", "Greater London", "UK");
        Customer customer2 = new Customer("Bob Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Journal", "J303", 8.25m, 1));
        order2.AddProduct(new Product("Backpack", "BP404", 27.99m, 1));
        order2.AddProduct(new Product("Water Bottle", "WB505", 10.50m, 2));

        // Display orders
        Order[] orders = { order1, order2 };
        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"Order #{orderNumber++}");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
            Console.WriteLine(new string('-', 40));
        }
    }
}

