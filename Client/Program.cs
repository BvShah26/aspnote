using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MultiplexApis.Data;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebhost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    DBInitializer.IntializeAsync(services, userManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, " Error Occured");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebhost(string[] args) =>
                WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
    }
}
