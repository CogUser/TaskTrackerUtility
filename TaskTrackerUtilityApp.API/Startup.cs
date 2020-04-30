using System.Runtime.Serialization;
using System.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaskTrackerUtilityApp.API.Data;
using TaskTrackerUtilityApp.API.Models;
using TaskTrackerUtilityApp.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TaskTrackerUtilityApp.API.Models.DataManager;
using TaskTrackerUtilityApp.API.Models.Repository;
using AutoMapper;

namespace TaskTrackerUtilityApp.API
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
            services.ConfigureSqlContext(Configuration);
            services.AddScoped<IDataRepository<User>, UserManager>();
            services.AddScoped<IDataRepository<Role>, RoleManager>();
            services.AddScoped<ITaskAttachmentRepository, TaskAttachmentRepository>();
            services.AddScoped<ITaskMaintenanceDataRepository, TaskMaintenanceManager>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSwaggerGen(c =>
             c.SwaggerDoc(name: "v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Task Tracker API", Version = "v1" }));
            services.AddControllers();
            services.ConfigureCors();  
            services.AddAutoMapper(typeof(TaskAttachmentRepository).Assembly);        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors( x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
 
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint(url:"/swagger/v1/swagger.json", name:"My API V1"));

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
