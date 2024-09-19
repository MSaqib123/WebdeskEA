using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Domain.ServiceMiddlwares
{

    public class CustomExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorizedAccessException ex)
            {
                context.Response.Redirect($"/Settings/Error/Error?statusCode=403&errorMessage={Uri.EscapeDataString(ex.Message)}");

            }
            catch (Exception ex)
            {
                context.Response.Redirect($"/Settings/Error/Error?statusCode=500&errorMessage={Uri.EscapeDataString(ex.Message)}");
            }
        }
    }
}
