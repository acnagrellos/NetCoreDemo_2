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
    public class ClientsEFService : IClientsService
    {
        private readonly OrdersAppContext _context;
        public ClientsEFService(OrdersAppContext context)
        {
            _context = context;
        }

        public async Task<int> Create(ClientDto client)
        {
            var clientEntity = new Client();
            client.UpdateClient(clientEntity);
            await _context.Clients.AddAsync(clientEntity);
            await _context.SaveChangesAsync();
            return clientEntity.Id;
        }

        public async Task<ClientDto> Get(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client != null)
            {
                return client.ToMapper();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public async Task<ClientDto> Get(string name)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Name == name);
            if (client != null)
            {
                return client.ToMapper();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public async Task<IEnumerable<ClientDto>> GetAlls()
        {
            var clients = await _context.Clients.ToListAsync();
            return clients.Select(c => c.ToMapper());
        }

        public async Task Update(ClientDto clientDto)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == clientDto.Id);
            if (client != null)
            {
                clientDto.UpdateClient(client);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
