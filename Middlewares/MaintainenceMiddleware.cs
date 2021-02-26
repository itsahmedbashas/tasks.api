using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Tasks.API.Middlewares
{
    public class MaintainenceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public MaintainenceMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task Invoke(HttpContext context)
        {
            // when application is in maintainence then we need too send response from here
            if (_config["ApplicationMaintainence:status"] == "YES")
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("APPLICATION IN MAINTAINENCE");
            }
            else
            {
                // else case we can pass to other middle ware
                await _next(context);
            }
        }
    }
}