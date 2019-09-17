using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersApp.Api.Core;
using OrdersApp.Domain.Models;
using OrdersApp.Services.Contracts;
using OrdersApp.Services.MemoryServices;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;

namespace OrdersApp.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            services.Configure<ConfigurationSettings>(configuration)
                .AddSingleton<IClientsService, ClientsMemoryService>()
                .AddSingleton<IProductsService, ProductsMemoryService>()
                .AddSwaggerGen(gen =>
                {
                    gen.SwaggerDoc("v1",
                        new Info
                        {
                            Title = "OrdersApp",
                            Version = "1"
                        });
                    gen.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                })
                .AddOrdersAppApiServices()
                .AddMvc();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(cors => cors
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials())
                .UseHttpsRedirection()
                .UseMiddleware<ErrorMiddleware>()
                .UseSwagger()
                .UseSwaggerUI(swaggerOptions =>
                {
                    swaggerOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    swaggerOptions.RoutePrefix = string.Empty;
                    
                })
                .UseMvc();
        }
    }
}
