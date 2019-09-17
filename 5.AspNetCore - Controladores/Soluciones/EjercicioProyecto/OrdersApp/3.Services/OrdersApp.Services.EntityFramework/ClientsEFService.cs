using OrdersApp.Domain.Core;
using OrdersApp.Domain.Data;
using OrdersApp.Domain.Models;
using OrdersApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersApp.Domain.Models.Exceptions;

namespace OrdersApp.Services.EntityFramework
{
    public class ClientsEFService : IClientsService
    {
        private readonly OrdersAppContext _context;
        public ClientsEFService(OrdersAppContext context)
        {
            _context = context;
        }


        public async Task<int> Create(ClientDto clientDto)
        {
            var client = new Client();
            Update(client, clientDto);

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client.Id;
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

        public async Task<IEnumerable<ClientDto>> GetAllsAsync()
        {
            var clients = await _context.Clients.ToListAsync();
            return clients.Select(client => client.ToMapper());
        }

        public async Task Update(ClientDto clientDto)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(c => c.Id == clientDto.Id);
            Update(client, clientDto);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrder(int orderId)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(c => c.Id == orderId);
            client.Orders.Add(new Order()
            {
                Id = orderId
            });
            await _context.SaveChangesAsync();
        }

        private void Update(Client client, ClientDto clientDto)
        {
            client.Update(
                clientDto.Name,
                clientDto.Surname,
                clientDto.Age,
                clientDto.Email,
                clientDto.Gender);
        }
    }
}
