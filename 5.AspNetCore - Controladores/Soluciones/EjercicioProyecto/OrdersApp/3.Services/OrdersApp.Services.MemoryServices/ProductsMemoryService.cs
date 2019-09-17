using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdersApp.Domain.Core;
using OrdersApp.Domain.Models;
using OrdersApp.Domain.Models.Exceptions;
using OrdersApp.Services.Contracts;

namespace OrdersApp.Services.MemoryServices
{
    public class ProductsMemoryService : IProductsService
    {
        private readonly List<Product> _products;

        public ProductsMemoryService()
        {
            _products = new List<Product>();
        }

        public async Task<int> Create(ProductDto productDto)
        {
            var newId = 1;
            if (_products.Count() > 0)
            {
                newId = _products.Max(p => p.Id) + 1;
            }

            var product = new Product(newId, productDto.Name, productDto.Price);
            _products.Add(product);
            return product.Id;
        }

        public async Task<ProductDto> Get(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAlls()
        {
            return _products.Select(p => p.ToMapper()).ToList();
        }

        public async Task Update(ProductDto productDto)
        {
            var productEntity = _products.FirstOrDefault(p => p.Id == productDto.Id);
            if (productEntity != null)
            {
                productEntity.Update(productDto.Name, productDto.Price);
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
