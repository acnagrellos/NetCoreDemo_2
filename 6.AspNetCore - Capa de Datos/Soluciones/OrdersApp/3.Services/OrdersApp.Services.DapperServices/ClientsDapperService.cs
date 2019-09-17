using Dapper;
using Microsoft.Extensions.Options;
using OrdersApp.Domain.Core;
using OrdersApp.Domain.Models;
using OrdersApp.Domain.Models.Exceptions;
using OrdersApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApp.Services.DapperServices
{
    public class ClientsDapperService : IClientsService
    {
        private string _connectionString;
        public ClientsDapperService(IOptions<ConfigurationSettings> options)
        {
            _connectionString = options.Value.ConnectionStrings.DefaultConnection;
        }

        public async Task<int> Create(ClientDto clientDto)
        {
            var sql = $@"INSERT INTO Customers (Name, Surname, Age, Email, Gender, LastUpdate) 
                         VALUES(@name, @surname, @age, @email, @gender, @lastUpdate) 
                         SELECT CAST(SCOPE_IDENTITY() as int)";

            using (var connection = new SqlConnection(_connectionString))
            {
                var ids = await connection.QueryAsync<int>(sql, 
                    new
                    {
                        name = clientDto.Name,
                        surname = clientDto.Surname,
                        age = clientDto.Age,
                        email = clientDto.Email,
                        gender = clientDto.Gender,
                        lastUpdate = DateTime.Now
                    });
                return ids.Single();
            }
        }

        public async Task<ClientDto> Get(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = $@"SELECT [Id]
                     ,[Fullname] as Name
                     ,[Surname]
                     ,[Age]
                     ,[Email]
                     ,[Gender] FROM Customers WHERE Fullname = @name";

                var clients = await connection.QueryAsync<Client>(sql, name);
                var client = clients.FirstOrDefault();
                if (client != null)
                {
                    return client.ToMapper();
                }
                else
                {
                    throw new NotFoundException();
                }
            }
        }

        public async Task<ClientDto> Get(int id)
        {
            using (var connextion = new SqlConnection(_connectionString))
            {
                var clients = await connextion.QueryAsync<Client>(
                    $@"SELECT [Id]
                     ,[Name]
                     ,[Surname]
                     ,[Age]
                     ,[Email]
                     ,[Gender] FROM Customers WHERE Id = @id", new { id });
                var client = clients.FirstOrDefault();
                if (client != null)
                {
                    return client.ToMapper();
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public async Task<IEnumerable<ClientDto>> GetAlls()
        {
            using (var connextion = new SqlConnection(_connectionString))
            {
                var clients = await connextion.QueryAsync<Client>(
                    "SELECT * FROM Customers");
                return clients.Select(c => c.ToMapper());
            }
        }

        public async Task Update(ClientDto client)
        {
            var sql = "UPDATE Customers SET Name = @name, Surname = @surname, Age = @age, Email = @email, Gender = @gender, LastUpdate = @lastUpdate";
            using (var connextion = new SqlConnection(_connectionString))
            {
                await connextion.ExecuteAsync(
                    sql, 
                    new
                    {
                        name = client.Name,
                        surname = client.Surname,
                        age = client.Age,
                        email = client.Email,
                        gender = client.Gender,
                        lastUpdate = DateTime.Now
                    });
            }
        }
    }
}
