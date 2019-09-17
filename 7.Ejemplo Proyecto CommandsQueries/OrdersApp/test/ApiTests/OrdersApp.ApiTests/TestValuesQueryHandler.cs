using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using OrdersApp.Api.Configuration;
using OrdersApp.ApiTests.Extensions;
using OrdersApp.Domain.Core;
using OrdersApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace OrdersApp.ApiTests
{
    public class TestValuesQueryHandler
    {
        private readonly HttpClient userHttpCient;
        private readonly TestServer server;
        private readonly string _baseCustomersUri;

        public TestValuesQueryHandler()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<TestStartup>());
            userHttpCient = server.CreateClient();
            _baseCustomersUri = $"{ApiConstants.BaseUri}/{ApiConstants.CustomerUri}";
        }

        [Fact]
        public async Task get_customers_empty()
        {
            var response = await userHttpCient.GetAsync(_baseCustomersUri);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(responseString);

            Assert.Empty(customers.ToList());
        }

        [Fact]
        public async Task add_customer()
        {
            var customerDto = new CustomerDto
            {
                Name = "Prueba",
                Surname = "Prueba",
                Age = 15,
                Email = "prueba@plainconcepts.com",
                Gender = Gender.Male
            };

            var response = await userHttpCient.PostJsonAsync(_baseCustomersUri, customerDto);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var id = JsonConvert.DeserializeObject<int>(responseString);

            Assert.Equal(1, id);
        }
    }
}
