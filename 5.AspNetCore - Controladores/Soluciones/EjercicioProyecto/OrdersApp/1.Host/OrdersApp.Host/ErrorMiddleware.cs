using Microsoft.AspNetCore.Http;
using OrdersApp.Domain.Models.Exceptions;
using System.Net;
using System.Threading.Tasks;

namespace OrdersApp.Host
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
        }
    }
}
