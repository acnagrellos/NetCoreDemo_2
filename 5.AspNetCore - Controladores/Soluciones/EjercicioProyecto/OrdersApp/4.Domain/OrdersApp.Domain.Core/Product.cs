using System;
using System.Collections;
using System.Collections.Generic;

namespace OrdersApp.Domain.Core
{
    public class Product
    {
        private Product()
        {

        }
        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
            LastUpdate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public DateTime LastUpdate { get; private set; }

        public void Update(string name, double price)
        {
            Name = name;
            Price = price;
            LastUpdate = DateTime.Now;
        }
    }
}
