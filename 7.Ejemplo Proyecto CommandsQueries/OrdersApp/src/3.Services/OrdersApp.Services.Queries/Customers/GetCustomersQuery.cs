using Dapper;
using Microsoft.Extensions.Options;
using OrdersApp.Domain.Data;
using OrdersApp.Domain.Data.Extensions;
using OrdersApp.Domain.Models;
using OrdersApp.Services.Contracts.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApp.Services.Queries
{
    public class GetCustomersQuery : DapperBase, IGetCustomersQuery
    {
        public GetCustomersQuery(IOptions<ConfigurationSettings> optionsAccessor) 
            : base(optionsAccessor.Value.ConnectionStrings.DefaultConnection)
        { }

        public async Task<IEnumerable<CustomerDto>> Execute()
        {
            var sql = $"SELECT Id, Name, Surname, Age, Email, Gender FROM {DatabaseConstants.CustomerTable}";

            return await WithConnection(connection => connection.QueryAsync<CustomerDto>(sql));
        }
    }
}
