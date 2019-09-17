using System;
using Microsoft.AspNetCore.Http;
using OrdersApp.Domain.Models.Exceptions;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace OrdersApp.Host
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private List<Tuple<Type, HttpStatusCode>> _exceptions;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
            _exceptions = new List<Tuple<Type, HttpStatusCode>>
            {
                new Tuple<Type, HttpStatusCode>(typeof(NotFoundException), HttpStatusCode.NotFound),
                new Tuple<Type, HttpStatusCode>(typeof(PreConditionFailedModelException), HttpStatusCode.PreconditionFailed),
            };
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                if (_exceptions.Any(tuple => tuple.Item1 == e.GetType()))
                {
                    var element = _exceptions.First(tuple => tuple.Item1 == e.GetType());
                    context.Response.StatusCode = (int)element.Item2;
                }

                throw;
            }
        }
    }
}
