// <copyright file="Startup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar
{
    using System.Collections.Generic;
    using AutoMapper;
    using FluentValidation;
    using FuegoDeQuasar.Common.Infrastructure;
    using FuegoDeQuasar.Features.Common.IntelligenceService;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration of the project.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Services container.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMediatR(typeof(Startup).Assembly);

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FuegoDeQuasar", Version = "v1" });
                c.CustomSchemaIds((type) => type.FullName);
            });

            services.AddValidatorsFromAssemblies(new List<System.Reflection.Assembly> { typeof(Startup).Assembly }, ServiceLifetime.Transient);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            services.AddSingleton<IIntelligenceService, IntelligenceService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">app.</param>
        /// <param name="env">env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FuegoDeQuasar v1"));
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
