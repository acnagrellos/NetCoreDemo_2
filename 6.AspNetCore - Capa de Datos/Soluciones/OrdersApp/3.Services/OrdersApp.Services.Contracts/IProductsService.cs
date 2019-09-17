using OrdersApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.Services.Contracts
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDto>> GetAlls();
        Task<ProductDto> Get(int id);
        Task<int> Create(ProductDto client);
        Task Update(ProductDto client);
    }
}
