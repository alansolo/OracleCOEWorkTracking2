using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OracleCOEWorkTracking.Data;
using OracleCOEWorkTracking.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Server.IISIntegration;
using OracleCOEWorkTracking.Controllers;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Antiforgery;

namespace OracleCOEWorkTracking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["connectionStrings:add:WorkTrackingConnectionString:connectionString"];

            services.AddDbContext<WorkTrackingContext>(options => options.UseSqlServer(connection));

            services.AddAutoMapper();

            services.AddScoped<IDBContextRepository, DBContextRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            services.AddAuthentication(IISDefaults.AuthenticationScheme);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSpaStaticFiles();

            app.UseMvc();

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            //app.Use(async (context, next) =>
            //{
            //    string path = context.Request.Path.Value;
            //    if (path != null && !path.ToLower().Contains("/api"))
            //    {
            //        // XSRF-TOKEN used by angular in the $http if provided
            //        var tokens = antiforgery.GetAndStoreTokens(context);
            //        context.Response.Cookies.Append("XSRF-TOKEN",
            //          tokens.RequestToken, new CookieOptions
            //          {
            //              HttpOnly = false,
            //              Secure = true
            //          }
            //        );
            //    }
 
            //     await next();
            //});
        }
    }
}
