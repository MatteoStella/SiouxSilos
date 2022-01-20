using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Service;
using ApplicationCore.Services;
using DataSimulator.Entity;
using DataSimulator.Interface.Service;
using DataSimulator.Interfaces.Entities;
using DataSimulator.Service;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
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
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddTransient<ISilos, Silos>();

            services.AddTransient<IDataGenerator, DataGenerator>();

            services.AddTransient<ISilosService, SilosService>();
            services.AddTransient<ISilosRepository, SilosRepository>();

            services.AddTransient<IDataCheckerRepository, DataCheckerRepository>();
            services.AddTransient<IDataCheckerService, DataCheckerService>();

            services.AddTransient<IAlarmRepository, AlarmRepository>();
            services.AddTransient<IAlarmService, AlarmService>();

            services.AddTransient<IAlarmSettingRepository, AlarmSettingRepository>();
            services.AddTransient<IAlarmSettingService, AlarmSettingService>();

            services.AddTransient<IWarningSettingRepository, WarningSettingRepository>();
            services.AddTransient<IWarningSettingService, WarningSettingService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
