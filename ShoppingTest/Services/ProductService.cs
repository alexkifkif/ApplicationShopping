using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingTest.Services
{
    public class ProductService
    {
        public void AddProduct(string name, double price, int quantity, string place, string brand)
        {
            var product = new Product()
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Place = place,
                Brand = brand
            };
        }
    }
}
