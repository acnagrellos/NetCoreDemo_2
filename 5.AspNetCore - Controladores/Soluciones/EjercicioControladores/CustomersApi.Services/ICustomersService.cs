using CustomersApi.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersApi.Services
{
    public interface ICustomersService
    {
        Task<int> Create(CustomerDto customerDto);
        Task<CustomerDto> Get(int id);
        Task<IEnumerable<CustomerDto>> GetItemsPerPage(int page);
        Task<int> Count();
        Task<IEnumerable<CustomerDto>> GetAlls();
        Task Update(CustomerDto customerDto);
        Task Delete(int id);
    }
}
