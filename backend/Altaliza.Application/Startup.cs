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
using Microsoft.OpenApi.Models;
using Altaliza.Domain.Repositories;
using Altaliza.Domain.Services;
using Altaliza.Infra.Context;
using Altaliza.Infra.Repositories;
using Altaliza.Application.Dtos;

namespace Altaliza.Application
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
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = (context) =>
                    {
                        var response = new ApiResponseDto<object>
                        {
                            Type = "error",
                            Status = 400,
                            Errors = context.ModelState
                                .Where(e => e.Value.Errors.Count > 0)
                                .ToDictionary(kvp => kvp.Key.ToLower(), kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList())
                        };

                        return new BadRequestObjectResult(response);
                    };
                });

            services.AddDbContext<MySqlContext>();

            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IVehicleCategoryRepository, VehicleCategoryRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ICharacterVehicleRepository, CharacterVehicleRepository>();

            services.AddScoped<CharacterService, CharacterService>();
            services.AddScoped<VehicleCategoryService, VehicleCategoryService>();
            services.AddScoped<VehicleService, VehicleService>();
            services.AddScoped<CharacterVehicleService, CharacterVehicleService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Altaliza", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Altaliza v1"));
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
