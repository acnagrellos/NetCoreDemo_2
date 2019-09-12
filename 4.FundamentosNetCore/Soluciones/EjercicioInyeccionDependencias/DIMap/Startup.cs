using DIMap.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DIMap
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRandomNumberService, RandomNumberService>();
            services.AddScoped<IRandomNumberServiceScoped, RandomNumberService>();
            services.AddSingleton<IRandomNumberServiceSingleton, RandomNumberService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Map("/equals", appbuilder =>
                {
                    appbuilder.Run(async (context) =>
                    {
                        var randomService = context.RequestServices.GetService(typeof(IRandomNumberServiceSingleton)) as IRandomNumberServiceSingleton;
                        var randomService2 = context.RequestServices.GetService(typeof(IRandomNumberServiceSingleton)) as IRandomNumberServiceSingleton;
                        await context.Response.WriteAsync($"RandomNumber1: {randomService.GetRandomNumber()}. RandomNumber2: {randomService2.GetRandomNumber()}");
                    });
                })
                .Map("/different", appbuilder =>
                {
                    appbuilder.Run(async (context) =>
                    {
                        var randomService = context.RequestServices.GetService(typeof(IRandomNumberService)) as IRandomNumberService;
                        var randomService2 = context.RequestServices.GetService(typeof(IRandomNumberService)) as IRandomNumberService;
                        await context.Response.WriteAsync($"RandomNumber1: {randomService.GetRandomNumber()}. RandomNumber2: {randomService2.GetRandomNumber()}");
                    });
                })
                .Run(async (context) =>
                {
                    var randomService = context.RequestServices.GetService(typeof(IRandomNumberServiceScoped)) as IRandomNumberServiceScoped;
                    var randomService2 = context.RequestServices.GetService(typeof(IRandomNumberServiceScoped)) as IRandomNumberServiceScoped;
                    await context.Response.WriteAsync($"RandomNumber1: {randomService.GetRandomNumber()}. RandomNumber2: {randomService2.GetRandomNumber()}");
                });
        }
    }
}
