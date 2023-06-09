using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sync_Task1.Models;
using Sync_Task1.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sync_Task1
{
    public class Startup
    {
        IConfiguration Config;

        public Startup(IConfiguration config)
        {
            Config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ITask1Repo<Bug>, BugDbRepo>();
            services.AddScoped<ITask1Repo<Developer>, DeveloperDbRepo>();
            services.AddScoped<ITask1Repo<Solution>, SolutionDbRepo>();
            services.AddDbContext<Task1DbContext>(option => 
            {
                option.UseSqlServer(Config.GetConnectionString("SqlConnec"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"defualt",
                    pattern: "{controller=Home}/{action=Index}/{id?}");      
            });
        }
    }
}
