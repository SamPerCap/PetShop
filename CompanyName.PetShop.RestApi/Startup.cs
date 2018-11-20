using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.DomainService;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using PetShop.Core.Entity;
using System;
using CompanyName.PetShop.RestApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CompanyName.PetShop.RestApi.Data;
using TodoApi.Data;

namespace CompanyName.PetShop.RestApi
{
    public class Startup
    {


        private IConfiguration _conf { get; }
        private IHostingEnvironment _env { get; set; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _conf = configuration;
            _env = env;
            JwtSecurityKey.SetSecret("A secret that needs to be at least 16 characters long");
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();
        } 

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSecurityKey.Key,
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => 
                    builder.WithOrigins("http://localhost:4200").AllowAnyHeader()
                        .AllowAnyMethod());
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("https://angularonfirebasepetshop.firebaseapp.com").AllowAnyHeader()
                        .AllowAnyMethod());
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:55344").AllowAnyHeader()
                      .AllowAnyMethod());
            });

            if (_env.IsDevelopment())
            {
                services.AddDbContext<PetAppContext>(
                    opt => opt.UseSqlite("Data Source=petShopApp.db"));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<PetAppContext>(
                    opt => opt
                        .UseSqlServer(_conf.GetConnectionString("defaultConnection")));
            }
            services.AddScoped<IPetShopService, PetShopService>();
            services.AddScoped<IPetShopRepository, PetRepository>();

            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IRepository<TodoItem>, TodoItemRepository>();
           // services.AddScoped<IRepository<Owner>, OwnerRepository>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Initialize the database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetService<PetAppContext>();
                    DBInitializer.SeedDB(dbContext);
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable CORS (must precede app.UseMvc()):
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            // Use authentication
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}