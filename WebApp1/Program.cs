using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace WebApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1
            //CreateWebHostBuilder(args).Build().Run();

            //2
            /*var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                //.UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            host.Run();*/

            //3
            using (var host = WebHost.Start("http://localhost:8080"
                , context => context.Response.WriteAsync("Hello World!")))
            {
                Console.WriteLine("App has been started");
                host.WaitForShutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
