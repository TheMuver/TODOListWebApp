using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;

using TODOListWebApp.Repository;

namespace TODOListWebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INoteRepository, NoteInMemoryDb>();
            services.AddSingleton<IUserRepository, UserInMemoryDb>();
			services
				.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options => options.LoginPath = new PathString("/login"));
			services.AddAuthorization();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            { 
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
			app.UseAuthentication();
			app.UseAuthorization();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action}");
            });
        }
    }
}
