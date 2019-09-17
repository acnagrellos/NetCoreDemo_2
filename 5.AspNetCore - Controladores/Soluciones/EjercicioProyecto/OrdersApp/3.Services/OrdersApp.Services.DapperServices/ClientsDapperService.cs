using Microsoft.Extensions.Options;
using OrdersApp.Domain.Models;
using OrdersApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using OrdersApp.Domain.Core;

namespace OrdersApp.Services.DapperServices
{
    public class ClientsDapperService : IClientsService
    {
        private string _sqlConn;
        public ClientsDapperService(IOptions<ConfigurationSettings> options)
        {
            _sqlConn = options.Value.ConnectionStrings.DefaultConnection;
        }

        public Task<int> Create(ClientDto client)
        {
            throw new NotImplementedException();
        }

        public async Task<ClientDto> Get(string clientId)
        {
            var sql = $"SELECT Name, Surname FROM Customers WHERE Id = @id";
            using (var sqlConnection = new SqlConnection(_sqlConn))
            {
                var customers = await sqlConnection.QueryAsync<ClientDto>(
                    sql, new { id = clientId });
                return customers.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<ClientDto>> GetAllsAsync()
        {
            var sql = "SELECT Name, Surname FROM Customers";
            using (var sqlConnection = new SqlConnection(_sqlConn))
            {
                var customers = await sqlConnection.QueryAsync<ClientDto>(sql);
                return customers;
            }
        }

        public Task Update(ClientDto client)
        {
            throw new NotImplementedException();
        }
    }
}
