using System;

class Program
{
    static void Main(string[] args)
    {
        Address addr1 = new Address("123 Maple St", "Rexburg", "ID", "USA");
        Customer cust1 = new Customer("Alice Johnson", addr1);
        Address addr2 = new Address("45 Queen St", "London", "Greater London", "UK");
        Customer cust2 = new Customer("Bob Smith", addr2);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "P001", 800, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25, 2));

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Headphones", "P003", 100, 1));
        order2.AddProduct(new Product("Keyboard", "P004", 50, 1));
        order2.AddProduct(new Product("Monitor", "P005", 200, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}\n");
    }
}