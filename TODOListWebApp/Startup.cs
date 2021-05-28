using System.IO;
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
                    string page = await File.ReadAllTextAsync("Pages/index.html");
                    await context.Response.WriteAsync(page);
                });

                endpoints.MapGet("/signup", async context =>
                {
                    string page = await File.ReadAllTextAsync("Pages/signup.html");
                    await context.Response.WriteAsync(page);
                });

                endpoints.MapGet("/login", async context => 
                {
                    string page = await File.ReadAllTextAsync("Pages/login.html");
                    await context.Response.WriteAsync(page);
                });

                endpoints.MapGet("/about", async context =>
                {
                    string page = await File.ReadAllTextAsync("Pages/about.html");
                    await context.Response.WriteAsync(page);
                });

                endpoints.MapGet("/notes", async context =>
                {
                    string page = await File.ReadAllTextAsync("Pages/notes.html");
                    await context.Response.WriteAsync(page);
                });
            });
        }
    }
}
