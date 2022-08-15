using Infrastructure.DataAccess.Interfaces;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessLayer(this IServiceCollection services)
        {           
            services.AddDbContext<CalculatorContext>(opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddScoped<CalculatorContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IMeasureRepository, MeasureRepository>();
            services.AddScoped<IGeometricFigureRepository, GeometricFigureRepository>();
            services.AddScoped<IGeometricFigureMeasureRepository, GeometricFigureMeasureRepository>();
        }
    }
}
