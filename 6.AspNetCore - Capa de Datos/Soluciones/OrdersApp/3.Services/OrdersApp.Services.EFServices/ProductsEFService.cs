using Microsoft.EntityFrameworkCore;
using OrdersApp.Domain.Core;
using OrdersApp.Domain.Data;
using OrdersApp.Domain.Models;
using OrdersApp.Domain.Models.Exceptions;
using OrdersApp.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApp.Services.EFServices
{
    public class ProductsEFService : IProductsService
    {
        private readonly OrdersAppContext _context;
        public ProductsEFService(OrdersAppContext context)
        {
            _context = context;
        }

        public async Task<int> Create(ProductDto productDto)
        {
            var productEntity = new Product();
            productDto.UpdateProduct(productEntity);
            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();
            return productEntity.Id;
        }

        public async Task<ProductDto> Get(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                return product.ToMapper();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAlls()
        {
            var products = await _context.Products.ToListAsync();
            return products.Select(c => c.ToMapper());
        }

        public async Task Update(ProductDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productDto.Id);
            if (product != null)
            {
                productDto.UpdateProduct(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
