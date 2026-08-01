using System;
class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        List<Product> order1Products = new List<Product>
        {
            new Product("Laptop", "P001", 999.99, 1),
            new Product("Mouse", "P002", 25.50, 2),
            new Product("Keyboard", "P003", 45.00, 1)
        };
        Order order1 = new Order(order1Products, customer1);

        Address address2 = new Address("45 Rue de Paris", "Paris", "Ile-de-France", "France");
        Customer customer2 = new Customer("Marie Curie", address2);

        List<Product> order2Products = new List<Product>
        {
            new Product("Headphones", "P004", 89.99, 1),
            new Product("Webcam", "P005", 59.99, 2)
        };
        Order order2 = new Order(order2Products, customer2);

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}\n");
        }
    }
}