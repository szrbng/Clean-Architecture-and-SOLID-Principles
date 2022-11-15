using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC
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
            services.AddControllersWithViews()
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
               .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddHttpContextAccessor();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new PathString("/users/login");
            });

            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:44363"));

            services.AddHttpClient<BaseClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44363");
                client.DefaultRequestHeaders.Add("Accept", "application/json");

            })
             .ConfigurePrimaryHttpMessageHandler(() =>
             {

                 var handler = new SocketsHttpHandler
                 {

                     UseCookies = false,
                     UseProxy = false,
                     AllowAutoRedirect = false,

                 };

                 return handler;
             })
             .SetHandlerLifetime(Timeout.InfiniteTimeSpan);

            services.AddSingleton<JsonSerializer>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            //services.AddScoped<ILeaveAllocationService, LeaveAllocationsService>();
            //services.AddScoped<ILeaveRequestService, LeaveRequestService>();

            services.AddSingleton<ILocalStorageService, LocalStorageService>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
