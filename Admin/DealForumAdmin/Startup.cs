using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealForum.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace DealForumAdmin
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
            services.AddControllersWithViews(o => o.EnableEndpointRouting = false);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                //options.CheckConsentNeeded = context => false; // commented this because tempdata not working when redirecting to other view
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);//You can set Time  
            });


            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(CustomFilterAttribute));
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            })
                    .SetCompatibilityVersion(CompatibilityVersion.Latest)
                    //Start (This is required for property naming convention. If not added then it will convert it to Camel Casing)
                    .AddNewtonsoftJson(options =>
                    {
                         //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                         var resolver = options.SerializerSettings.ContractResolver;
                        if (resolver != null)
                        {
                            (resolver as DefaultContractResolver).NamingStrategy = null;
                        }
                    });//End

            services.AddOptions();
            services.AddCors();

            services.AddScoped<CommonContext, CommonContext>();

            services.Configure<AppSettingsViewModel>(Configuration.GetSection("AppSettings"));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                //// Only loopback proxies are allowed by default.
                //// Clear that restriction because forwarders are enabled by explicit 
                //// configuration.
                //options.KnownNetworks.Clear();
                //options.KnownProxies.Clear();
            });

            services.AddAntiforgery(options => options.HeaderName = "MY-XSRF-TOKEN");
            //services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Area/Company/Home/Login");
            services.AddHttpContextAccessor();


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
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("areas", "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=Index}/{id?}",
                    defaults: null,
                    constraints: null,
                    dataTokens: null);
            });

            UserSession.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

        }
    }
}
