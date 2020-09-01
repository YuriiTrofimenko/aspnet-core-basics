using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //1

            /* if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                string host = context.Request.Host.Value;
                string path = context.Request.Path;
                // путь запроса
                string query = context.Request.QueryString.Value;
                // параметры строки запроса
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(
                        $"<h3>Хост: {host}</h3>"
                        + $"<h3>Путь запроса: {path}</h3>"
                        + $"<h3>Параметры строки запроса: {query}</h3>"
                    );
            }); */

            //2
            /* app.Use(async (context, next) => {
                await context.Response.WriteAsync("Hello ");
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("World");
            }); */

            //3
            app.Map("/index", (appBuilder => {
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("<h1>Home</h1>");
                    // context.Response.WriteAsync("<h1>Home</h1>");
                });
            }));

            app.Map("/about", (appBuilder => {
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("<h1>About</h1>");
                });
            }));

            app.Map("/admin", (admin => {
                admin.Map("/users", (appBuilder => {
                    appBuilder.Run(async (context) =>
                    {
                        await context.Response.WriteAsync("<h1>Users list</h1>");
                    });
                }));
                admin.Map("/analytics", (appBuilder => {
                    appBuilder.Run(async (context) =>
                    {
                        await context.Response.WriteAsync("<h1>Analytics</h1>");
                    });
                }));
                admin.Run(async (context) =>
                {
                    await context.Response.WriteAsync("<h1>Admin</h1>");
                });
            }));

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("World");
            });

            //4
            /*app.UseMiddleware<TokenMiddleware>();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
            });*/

            //5
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMiddleware<RoutingMiddleware>();
        }
    }
}
