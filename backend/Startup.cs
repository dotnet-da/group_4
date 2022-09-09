using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Middleware;
using backend.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Org.BouncyCastle.Math.EC.Multiplier;

namespace backend
{
    public class Startup
    {
        ///<summary>
        ///Constructor 
        ///</summary>
        /// <param name="configuration">Selected configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        ///<summary> This method gets called by the runtime. Use this method to add services to the container.</summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ToolContext>(optionsAction => optionsAction.UseMySQL(Configuration.GetConnectionString("database_001")));
            services.AddScoped<ToolContext>();

            services.AddControllers();
        }

        ///<summary> This method gets called by the runtime. Use this method to configure the HTTP request pipeline. </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var toolContext = serviceScope.ServiceProvider.GetService<ToolContext>();
                
                //toolContext.Database.EnsureDeleted();
                toolContext.Database.EnsureCreated();
            }
        }
    }
}