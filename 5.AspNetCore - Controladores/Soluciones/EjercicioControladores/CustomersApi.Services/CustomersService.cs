using CustomersApi.Services.Configuration;
using CustomersApi.Services.Domain;
using CustomersApi.Services.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersApi.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IList<Customer> _customers;
        private readonly int _itemPerPage;

        public CustomersService(IOptions<AppSettingsModel> options)
        {
            this._customers = new List<Customer>()
            {
                new Customer(1, "Pepe", "Lopez", 24, "pepe@gmail.com", Gender.Male),
                new Customer(2, "Laura", "Sanchez", 24, "laura@gmail.com", Gender.Female),
                new Customer(3, "Carlos", "Perez", 24, "carlos@gmail.com", Gender.Male),
                new Customer(4, "Rosa", "Garcia", 24, "rosa@gmail.com", Gender.Female)
            };
            _itemPerPage = options.Value.CustomersPerPage;
        }

        public async Task<int> Create(CustomerDto customerDto)
        {
            var newId = 1;
            if (_customers.Count() > 0)
            {
                newId = _customers.Max(clientEntity => clientEntity.Id) + 1;
            }

            var customer = new Customer();
            customer.SetId(newId);
            UpdateClient(customer, customerDto);
            _customers.Add(customer);
            return customer.Id;
        }

        public async Task<CustomerDto> Get(int id)
        {
            return _customers.FirstOrDefault(client => client.Id == id).ToMapper();
        }

        public async Task<IEnumerable<CustomerDto>> GetItemsPerPage(int page)
        {
            return _customers.Skip(_itemPerPage * page)
                             .Take(_itemPerPage)
                             .Select(customer => customer.ToMapper());
        }

        public async Task<int> Count()
        {
            return this._customers.Count;
        }

        public async Task<IEnumerable<CustomerDto>> GetAlls()
        {
            return _customers.Select(client => client.ToMapper());
        }

        public async Task Update(CustomerDto customerDto)
        {
            var customerEntity = _customers.FirstOrDefault(c => c.Id == customerDto.Id);
            if (customerEntity != null)
            {
                UpdateClient(customerEntity, customerDto);
            }
            else
            {
                throw new Exception("No se ha encontrado el cliente");
            }
        }

        public async Task Delete(int id)
        {
            var entityToRemove = _customers.FirstOrDefault(client => client.Id == id);
            if (entityToRemove != null)
            {
                _customers.Remove(entityToRemove);
            }
            else
            {
                throw new Exception("No se ha encontrado el cliente");
            }
        }

        private void UpdateClient(Customer customer, CustomerDto customerDto)
        {
            customer.Update(
                customerDto.Name,
                customerDto.Surname,
                customerDto.Age,
                customerDto.Email,
                customerDto.Gender);
        }
    }
}
