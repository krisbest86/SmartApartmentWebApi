using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstraction;
using Microsoft.AspNetCore.Http;

namespace SmartApartmentApi.Middlewares
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILog _logger;

        public ErrorHandler(RequestDelegate next, ILog logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}: {ex.StackTrace}");
                context.Response.StatusCode = 500;
            }
        }
    }
}
