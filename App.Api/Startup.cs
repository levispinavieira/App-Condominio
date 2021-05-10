using System;
using System.ComponentModel;
using App.Infra.Data.Contexts;
using App.Infra.Data.Interfaces;
using App.Infra.Data.Uow;
using App.Infra.Ioc;
using App.Infra.Ioc.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace App.Api
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
            // Add Core IoC Services
            services.AddAppInjectorServices();
            
            services.AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            
            services.AddSwaggerGen();
            services.AddCoreInfraIoCConfiguration();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<IDbAppContext, DbAppContext>(ServiceLifetime.Singleton);
            services.AddSingleton(factory => new Lazy<IDbAppContext>(factory.GetService<IDbAppContext>));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "APP Condominio");
                options.DocExpansion(DocExpansion.None);
                options.DisplayOperationId();
                options.DisplayRequestDuration();
            });
        }
    }
}