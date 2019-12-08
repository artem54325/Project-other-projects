using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjectAboutProjects.DAL;
using ProjectAboutProjects.Models;

namespace ProjectAboutProjects
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
            services.AddDbContext<MySqlContext>(options=> options.UseMySQL(Configuration.GetConnectionString("mysqlConnection")));
            _ = services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MySqlContext>().AddDefaultTokenProviders();
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
                {
                    var userLangs = context.Request.Headers["Accept-Language"].ToString();
                    var firstLang = userLangs.Split(',').FirstOrDefault();
                    var defaultLang = string.IsNullOrEmpty(firstLang) ? "en-EN" : firstLang;
                    return Task.FromResult(new ProviderCultureResult(defaultLang, defaultLang));
                }));
            });

            services.AddMvcCore().AddAuthorization();
            services.AddSignalR();

            services.AddMvc().AddViewLocalization();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            var key = Encoding.UTF8.GetBytes("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1");
            JwtBearerOptions options = new JwtBearerOptions
            {
                TokenValidationParameters = {
                   ValidIssuer = "ExampleIssuer",
                   ValidAudience = "ExampleAudience",
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuerSigningKey = true,
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero
                }
            };

            //app.UseJwtBearerAuthentication(options);
            app.UseMvcWithDefaultRoute();
            app.UseMvc().UseMvcWithDefaultRoute();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseIdentity();

            var supportedCultures = new[]
            {
                new CultureInfo("en-EN"),
                new CultureInfo("ru-RU")
            };
            var localizationOptions = new RequestLocalizationOptions
            {
                //https://stackoverflow.com/questions/39006690/asp-net-core-request-localization-options
                //https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/localization?view=aspnetcore-3.1
                //https://damienbod.com/2014/03/20/web-api-localization/
                //https://docs.devexpress.com/AspNet/3847/aspnet-webforms-controls/scheduler/examples/customization/appearance/how-to-customize-resource-headers
                DefaultRequestCulture = new RequestCulture("en-EN"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            var cookieProvider = localizationOptions.RequestCultureProviders
                .OfType<CookieRequestCultureProvider>()
                .First();

            cookieProvider.CookieName = "UserCulture";

            app.UseRequestLocalization(localizationOptions);

            app.UseSignalR(routes =>
            {
                routes.MapHub<Hubs.WebRTCHub>("/videocall/WebRTCHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
