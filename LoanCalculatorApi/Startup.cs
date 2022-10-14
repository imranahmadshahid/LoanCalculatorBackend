using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculatorApi.Middleware;
using LoanCalulatorCore.Infrastructure;
using LoanCalulatorCore.Model;
using LoanCalulatorCore.Services;
using Microsoft.OpenApi.Models;

namespace LoanCalculatorApi
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
            services.AddSwaggerGen(s=>s.SwaggerDoc("v1",new OpenApiInfo()
            {
                Version = "V1",
                Title = "Loan Calculator"
            }));
            services.AddTransient<HouseLoan>();
            services.AddCors();
            services.AddTransient<Func<LoanTypes, ILoan>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case LoanTypes.HouseLoan:
                        return serviceProvider.GetService<HouseLoan>();

                    default:
                        throw new Exception("No Implementation available");
                }
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
            app.UseRouting();
            app.ConfigureExceptionHandler();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
