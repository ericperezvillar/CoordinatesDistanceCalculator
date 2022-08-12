using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace WebApi.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddCustomerSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Distance Calculator Documentation",
                    Version = "v1",
                    Description = "Program to calculate the distance between two coordinates",
                    Contact = new OpenApiContact
                    {
                        Name = "Eric Perez Villar",
                        Email = "ericperezvillar@gmail.com"
                    }
                });

                c.DescribeAllParametersInCamelCase();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                                
                // We do this to view the comments for the Swagger Json and UI
                c.IncludeXmlComments(xmlPath);

            });

            services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }
    }
}
