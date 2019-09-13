using OrdersApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersApp.Domain.Models
{
    public static class ProductsExtensions
    {
        public static ProductDto ToMapper(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
