using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OrdersApp.Api.Core;
using OrdersApp.ApiTests.Services;
using OrdersApp.Services.Contracts;

namespace OrdersApp.ApiTests
{
    public class TestStartup
    {
        public IConfiguration Configuration { get; }
        public TestStartup()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<ICustomersService, CustomersServiceMock>()
                .AddOrdersAppApiServices()
                .AddMvcCore()
                .AddJsonFormatters()
                .AddJsonOptions(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder application, IHostingEnvironment environment)
        {
            application.UseMvc();
        }
    }
}
