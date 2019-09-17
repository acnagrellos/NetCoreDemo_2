using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace OrdersApp.Domain.Data.Extensions
{
    public class DapperBase
    {
        private readonly string _connectionString;
        public DapperBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection Connection => new SqlConnection(_connectionString);

        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var connection = Connection)
                {
                    await connection.OpenAsync();
                    return await getData(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    $"{GetType().FullName}.WithConnection() experienced a SQL exception (not a timeout)", ex);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
