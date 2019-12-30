using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectAboutProjects.DAL;
using ProjectAboutProjects.Models;
using RouteDataRequestCultureProvider = ProjectAboutProjects.DAL.RouteDataRequestCultureProvider;

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
            services.AddDbContext<MySqlContext>(options=> options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            _ = services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MySqlContext>().AddDefaultTokenProviders();
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvcCore().AddAuthorization();
            services.AddSignalR();

            services.AddMvc().AddViewLocalization();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("tr-TR"),
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new[]{ new RouteDataRequestCultureProvider{
                    IndexOfCulture=1,
                    IndexofUICulture=1
                }};
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(options => //CookieAuthenticationOptions
                 {
                     options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                 });

            //services.Configure<RouteOptions>(options =>
            //{
            //    options.ConstraintMap.Add("culture", typeof(LanguageRouteConstraint));
            //});

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

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            //app.UseJwtBearerAuthentication(options);
            //app.UseMvcWithDefaultRoute();
            app.UseMvc().UseMvcWithDefaultRoute();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseIdentity();

            //app.UseAuthentication();    // аутентификация
            //app.UseAuthorization();     // авторизация

            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("ru")
            };
            //var localizationOptions = new RequestLocalizationOptions
            //{
            //    //https://stackoverflow.com/questions/39006690/asp-net-core-request-localization-options
            //    //https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/localization?view=aspnetcore-3.1
            //    //https://damienbod.com/2014/03/20/web-api-localization/
            //    //https://docs.devexpress.com/AspNet/3847/aspnet-webforms-controls/scheduler/examples/customization/appearance/how-to-customize-resource-headers
            //    DefaultRequestCulture = new RequestCulture("en"),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures
            //};

            //var cookieProvider = localizationOptions.RequestCultureProviders
            //    .OfType<CookieRequestCultureProvider>()
            //    .First();

            //app.UseRequestLocalization(localizationOptions);

            //cookieProvider.CookieName = "UserCulture";

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
