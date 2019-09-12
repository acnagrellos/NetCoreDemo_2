using CustomersApi.Services;
using CustomersApi.Services.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CustomersApi
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettingsModel>(Configuration)
                    .AddSwaggerGen(gen =>
                    {
                        gen.SwaggerDoc("v1", new Info
                        {
                            Title = "MiApi",
                            Version = "1"
                        });
                    })
                    .AddSingleton<ICustomersService, CustomersService>()
                    .AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                    c.SwaggerEndpoint("swagger/v1/swagger.json", "My Api");
                    c.RoutePrefix = "";
               })
               .UseMvc();
        }
    }
}
