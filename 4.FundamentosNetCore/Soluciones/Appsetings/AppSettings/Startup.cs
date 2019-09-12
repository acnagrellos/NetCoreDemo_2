using AppSettings.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AppSettings
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ConfigurationSettings>(Configuration);
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            IOptions<ConfigurationSettings> options)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Mi cadena de conexion es: {options.Value.ConnectionString}");
            });
        }
    }
}
