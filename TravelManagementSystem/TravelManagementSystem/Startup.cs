using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagementSystem.Models;
using TravelManagementSystem.Repositories;
using TravelManagementSystem.ViewModel;

namespace TravelManagementSystem
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
            services.AddControllers();

            //Add dependency injection
            services.AddDbContext<TravelManagementSystemContext>(
               options => options.UseSqlServer(Configuration.GetConnectionString("constr"))
                   );

            //add dependency injection for post repository --rashmi
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProjectTableRepository, ProjectTableRepository>();
            services.AddScoped<IRequestTableRepository, RequestTableRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRequestFormDetailsRepo, RequestFormDetailsRepo>();


            //register a JWT authentication schema
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
           options.TokenValidationParameters = new TokenValidationParameters



        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
        };
    }
    );
            services.AddMvc();

            services.AddControllers().AddNewtonsoftJson(

                options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                }
                );

            services.AddCors();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
          options.WithOrigins("http://localhost:4200")
          .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
