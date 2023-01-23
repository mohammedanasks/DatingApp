using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Error;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public IHostEnvironment _env { get; }

        public ExceptionHandlingMiddleware(RequestDelegate next,ILogger<ExceptionHandlingMiddleware>logger,IHostEnvironment env) 
        {
            _env = env;
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType="application/json";
                context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;

                var Response = _env.IsDevelopment()
                ? new ApiException(context.Response.StatusCode,ex.Message,ex.StackTrace?.ToString())
                : new ApiException(context.Response.StatusCode,ex.Message,"Internal Server Error ");

                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json =JsonSerializer.Serialize(Response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}