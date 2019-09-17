using OrdersApp.Domain.Core;
using OrdersApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApp.Services.Contracts
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientDto>> GetAlls();
        Task<ClientDto> Get(int id);
        Task<ClientDto> Get(string name);
        Task<int> Create(ClientDto client);
        Task Update(ClientDto client);
    }
}
