using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace TrafficManagementSystem
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync($"Erro interno: {ex.Message}");
            }
        }
    }
}
