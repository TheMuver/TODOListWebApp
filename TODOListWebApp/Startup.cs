using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TODOListWebApp.Repository;

namespace TODOListWebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INoteRepository, NoteMySqlDb>();
            services.AddSingleton<IUserRepository, UserMySqlDb>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    
                });

                endpoints.MapGet("/auth", async context =>
                {

                });

                endpoints.MapGet("/about", async context =>
                {

                });

                endpoints.MapGet("/notes", async context =>
                {

                });
            });
        }
    }
}
