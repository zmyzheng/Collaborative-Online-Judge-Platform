using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using ApiServer.Services;
using Microsoft.AspNetCore.Http;

namespace ApiServer.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try 
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HanleExceptionAsync(context, ex);
            }
        }

        private async Task HanleExceptionAsync(HttpContext context, Exception ex)
        {
            switch (ex)
            {
                case RestException re:
                    context.Response.StatusCode = (int) re.Code;
                    break;
                case Exception e:
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(
                new { code = context.Response.StatusCode, message = ex.Message }
            );

            await context.Response.WriteAsync(result);
        }
    }
}