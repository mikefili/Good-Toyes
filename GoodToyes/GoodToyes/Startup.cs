using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GoodToyes.Data;
using GoodToyes.Models;
using GoodToyes.Models.Handler;
using GoodToyes.Models.Interfaces;
using GoodToyes.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodToyes
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ApplicationProductionConnection"]));

            services.AddDbContext<GoodToyesDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ProductionConnection"]));

            services.AddScoped<IProduct, ProductManager>();
            
            //Policy requirement
            services.AddAuthorization(options =>
            {
                options.AddPolicy("spayOrNeuter", policy => policy.Requirements.Add(new SpayNeuterRequirement()));
            });

            services.AddAuthentication()
                .AddFacebook(facebook =>
                {
                    facebook.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebook.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                })
                
                .AddMicrosoftAccount(microsoftOptions =>
                {
                    microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ApplicationId"];
                    microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:Password"];
                });

            services.AddScoped<IAuthorizationHandler, SpayNeuterRequirement>();
            services.AddScoped<ICart, CartService>();
            services.AddScoped<IProduct, ProductManager>();
            services.AddScoped<IEmailSender, EmailSender>();


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
