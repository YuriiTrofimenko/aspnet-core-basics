using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApp3.Services;

namespace WebApp3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            //2
            services.AddTransient<IMessageSender, EmailMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //1
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //2
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageSender messageSender)
        {
            //1
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                //1
                //await context.Response.WriteAsync("Hello World!");
                //2
                await context.Response.WriteAsync(messageSender.Send());
            });
        }
    }
}
