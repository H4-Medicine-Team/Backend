using MedicineApi.Data.Interfaces;
using AutoMapper;
using DataAccess.Dtos;
using MedicineApi.Managers;
using MedicineApi.Models.UserLoginModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MedicineApi
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

            // Compile app settings
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            // Add automapper profiles. Scan for profiles in the current assembly
            var mapCfg = new MapperConfiguration(mc =>
            {
                mc.AddMaps(Assembly.GetExecutingAssembly());
            });
            services.AddSingleton(mapCfg.CreateMapper());

            // Db connection context
            services.AddDbContext<MedicineContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("MedicineDbContext"))
            );

            // Managers
            services.AddScoped<IMedicineCardManager, FmkMedicineCardManagerMock>();
            services.AddScoped<IUserManager<UserLoginInfo>, UserManager<UserLoginInfo>>();
            services.AddScoped<IDosageManager, DosageManager>();
            services.AddScoped<IMedicineDkManager, MedicineDkManager>();
            // Intergration service
            services.AddScoped<MedicineDkCaller>();
            services.AddScoped<MedicineDkDTOConverter>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicineApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicineApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
