using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2
{

    public class TokenMiddleware
    {
        private readonly RequestDelegate mNext;

        public TokenMiddleware(RequestDelegate next)
        {
            this.mNext = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != "12345678")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                await mNext.Invoke(context);
            }
        }
    }
}
