using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersApp.Api.Core
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddOrdersAppApiServices(this IServiceCollection services)
        {
            services
                .AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.ApiVersionReader = new HeaderApiVersionReader("x-apiversion");
                })
                .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            return services;
        }

        public static IApplicationBuilder UseOrdersAppApi(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseMvc();
            return appBuilder;
        }
    }
}
