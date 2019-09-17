using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using OrdersApp.Domain.Core;
using OrdersApp.Domain.Models;
using OrdersApp.Domain.Models.Exceptions;
using OrdersApp.Services.Contracts;

namespace OrdersApp.Services.DapperServices
{
    public class ProductsDapperServices : IProductsService
    {
        private string _connectionString;
        public ProductsDapperServices(IOptions<ConfigurationSettings> options)
        {
            _connectionString = options.Value.ConnectionStrings.DefaultConnection;
        }
        public async Task<int> Create(ProductDto productDto)
        {
            var sql = "INSERT INTO Customers (Name, Price, LastUpdate) " +
                      "VALUES(@name, @price, @lastUpdate)" +
                      "SELECT CAST(SCOPE_IDENTITY() as int)";

            using (var connection = new SqlConnection(_connectionString))
            {
                var ids = await connection.QueryAsync<int>(sql,
                    new
                    {
                        name = productDto.Name,
                        price = productDto.Price,
                        lastUpdate = DateTime.Now
                    });
                return ids.Single();
            }
        }

        public async Task<ProductDto> Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = $@"SELECT [Id]
                                    ,[Name]
                                    ,[Price] 
                             FROM Products WHERE Id = @id";

                var clients = await connection.QueryAsync<Product>(sql, new { id });
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

        public async Task<IEnumerable<ProductDto>> GetAlls()
        {
            using (var connextion = new SqlConnection(_connectionString))
            {
                var products = await connextion.QueryAsync<Product>(
                    "SELECT * FROM Products");
                return products.Select(product => product.ToMapper());
            }
        }

        public async Task Update(ProductDto productDto)
        {
            var sql = "UPDATE Products SET Name = @name, Price = @price, LastUpdate = @lastUpdate";
            using (var connextion = new SqlConnection(_connectionString))
            {
                await connextion.ExecuteAsync(
                    sql,
                    new
                    {
                        name = productDto.Name,
                        price = productDto.Price,
                        lastUpdate = DateTime.Now
                    });
            }
        }
    }
}
