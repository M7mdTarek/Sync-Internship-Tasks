using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sync_Task1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sync_Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*var webhost = */ CreateHostBuilder(args).Build().Run();
            //RunMigration(webhost);
            //webhost.Run();
        }

        //private static void RunMigration(IHost webhost)
        //{
        //    using (var scope = webhost.Services.CreateScope())
        //    {
        //        var db = scope.ServiceProvider.GetRequiredService<Task1DbContext>();
        //        db.Database.Migrate();
        //    }
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
