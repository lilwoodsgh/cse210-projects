using System;
using System.Collections.Generic;

namespace OnlineOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create products
            Product product1 = new Product("Datastick", "P001", 1000, 1);
            Product product2 = new Product("Pendrive", "P002", 25, 2);
            Product product3 = new Product("HDMI cable", "P003", 50, 1);
            Product product4 = new Product("Data Cable", "P004", 300, 1);

            // Create addresses
            Address address1 = new Address("123 Main St", "Texas", "TX", "USA");
            Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

            // Create customers
            Customer customer1 = new Customer("Curtis Smith", address1);
            Customer customer2 = new Customer("Judy Brown", address2);

            // Create orders
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);

            // Display order details
            Console.WriteLine("Order 1:");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

            Console.WriteLine("Order 2:");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
        }
    }

    public class Product
    {
        private string name;
        private string productId;
        private double price;
        private int quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public double GetTotalCost()
        {
            return price * quantity;
        }

        public string GetName()
        {
            return name;
        }

        public string GetProductId()
        {
            return productId;
        }
    }

    public class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }

        public bool IsInUSA()
        {
            return address.IsInUSA();
        }
    }

    public class Address
    {
        private string streetAddress;
        private string city;
        private string stateOrProvince;
        private string country;

        public Address(string streetAddress, string city, string stateOrProvince, string country)
        {
            this.streetAddress = streetAddress;
            this.city = city;
            this.stateOrProvince = stateOrProvince;
            this.country = country;
        }

        public bool IsInUSA()
        {
            return country.ToLower() == "usa";
        }

        public string GetFullAddress()
        {
            return $"{streetAddress}\n{city}, {stateOrProvince}\n{country}";
        }
    }

    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var product in products)
            {
                total += product.GetTotalCost();
            }

            if (customer.IsInUSA())
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
            string packingLabel = "";
            foreach (var product in products)
            {
                packingLabel += $"{product.GetName()} (ID: {product.GetProductId()})\n";
            }
            return packingLabel;
        }

        public string GetShippingLabel()
        {
            return $"{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
        }
    }
}
