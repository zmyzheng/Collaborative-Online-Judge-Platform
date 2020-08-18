using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServer.Api.Middlewares;
using ApiServer.Api.Validators;
using ApiServer.Core;
using ApiServer.Core.Services;
using ApiServer.Data;
using ApiServer.Services;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ApiServer.Api
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

            services.AddDbContext<ApiServerDbContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSql"), action => action.MigrationsAssembly("ApiServer.Data"))); //our migrations should be run in ApiServer.Data.

            services.AddControllers()
                .AddFluentValidation(fv => 
                {
                    fv.RegisterValidatorsFromAssemblyContaining<ProblemResourceValidator>(lifetime: ServiceLifetime.Transient); //This will automatically find any public, non-abstract types that inherit from AbstractValidator and register them with the container
                    fv.ImplicitlyValidateChildProperties = true;
                }); 

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProblemService, ProblemService>();
            // Transient vs Scoped vs Singleton
            //     You noticed that we added the dependency as Scoped. We have 3 types of dependency injection:
            //     Transient — Objects are different. One new instance is provided to every controller and every service
            //     Scoped — Objects are same through the request
            //     Singleton — Objects are the same for every request during the application lifetime
            services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "API Server",
                        Description = "A simple example ASP.NET Core Web API",
                        // TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Mingyang Zheng",
                            Email = "zhengzmy@gmail.com",
                            Url = new Uri("https://github.com/zmyzheng"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT License",
                            Url = new Uri("https://github.com/zmyzheng/Collaborative-Online-Judge-Platform/blob/master/LICENSE"),
                        }
                    });
                });
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
            c.RoutePrefix = "swagger-ui";
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Server V1");
            });

        }
    }
}
