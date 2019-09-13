using OrdersApp.Domain.Core;
using OrdersApp.Domain.Models;
using OrdersApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApp.Services.MemoryServices
{
    public class ClientsMemoryService : IClientsService
    {
        private readonly List<Client> _clients = new List<Client>();
        public async Task<int> Create(ClientDto clientDto)
        {
            var newId = 1;
            if (_clients.Count() > 0)
            {
                newId = _clients.Max(clientEntity => clientEntity.Id) + 1;
            }

            var client = new Client();
            client.Id = newId;
            UpdateClient(client, clientDto);
            _clients.Add(client);
            return client.Id;
        }

        public async Task<ClientDto> Get(int id)
        {
            return _clients.FirstOrDefault(client => client.Id == id).ToMapper();
        }

        public async Task<IEnumerable<ClientDto>> GetAlls()
        {
            return _clients.Select(client => client.ToMapper());
        }

        public async Task Update(ClientDto clientDto)
        {
            var clientEntity = _clients.FirstOrDefault(c => c.Id == clientDto.Id);
            if (clientEntity != null)
            {
                UpdateClient(clientEntity, clientDto);
            }
            else
            {
                throw new Exception("No se ha encontrado el cliente");
            }
        }

        private void UpdateClient(Client client, ClientDto clientDto)
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
