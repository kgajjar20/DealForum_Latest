using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealForumAPI.Common;
using DealForumAPI.Common.LogTracking;
using DealForumAPI.DB;
using DealForumAPI.Interface;
using DealForumAPI.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using RestApi.Example.Utils.Swagger;

namespace DealForumAPI
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
            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
            services.AddControllers(o => o.EnableEndpointRouting = false);
            services.Configure<ApiBehaviorOptions>(opts => opts.SuppressModelStateInvalidFilter = true);

            services.AddSingleton(Configuration);

            services.AddMvc(options =>
            {
            })
             .SetCompatibilityVersion(CompatibilityVersion.Latest)
              //Start (This is required for property naming convention. If not added then it will convert it to Camel Casing)
              .AddNewtonsoftJson(options =>
              {
                  var resolver = options.SerializerSettings.ContractResolver;
                  if (resolver != null)
                  {
                      (resolver as DefaultContractResolver).NamingStrategy = null;
                  }
              });//End

            services.AddDbContext<DealForumContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DealForumDBConnection")));
            services.AddTransient<DealForumContext>();
            services.AddCors();

            services.AddScoped<IApiLogTrackingRepo, LogTrackingRepo>();
            services.AddScoped<IActionTracking, ActionTracking>();
            services.AddScoped<IException, ExceptionTracking>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IAdminLogin, AdminLoginRepository>();
            services.AddScoped<IAdminRole, AdminRoleRepository>();
            services.AddScoped<IAdminStore, AdminStoreRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<ICoupon, CouponRepository>();
            services.AddScoped<IDeal, DealRepository>();
            services.AddScoped<IAdminForum, AdminForumRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(Options =>
           {
               Options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });



            services
                .AddApiVersionWithExplorer()
                .AddSwaggerOptions()
                .AddSwaggerGen();

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwaggerDocuments();
            app.UseHttpsRedirection();


            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
                DefaultContentType = "application/yaml",
                //FileProvider = new PhysicalFileProvider(
                //    Path.Combine(env.WebRootPath, "yaml")),
                //RequestPath = new PathString("/yaml")
            });

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<APIRequestResponseRewindMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "defaultAPI",
                    pattern: "{controller=Home}/{action=Index}/{id?}",
                    defaults: null,
                    constraints: null,
                    dataTokens: null);
            });

        }
    }
}
