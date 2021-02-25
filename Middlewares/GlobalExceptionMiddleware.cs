using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Tasks.API.Errors;

namespace Tasks.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // getting error info class
                ErrorInfo errorInfo;
                // getting status code 
                var statusCode = HttpStatusCode.InternalServerError;
                // when the env is development we will log stack trace else no 
                if (env.IsDevelopment())
                {
                    errorInfo = new ErrorInfo((int)statusCode, ex.Message, ex.StackTrace);
                }
                else
                {
                    errorInfo = new ErrorInfo((int)statusCode, ex.Message);
                }
                // assign status code to request
                context.Response.StatusCode = (int)statusCode;
                // finally returning value to front end
                await context.Response.WriteAsync(errorInfo.ToString());
            }
        }
    }
}