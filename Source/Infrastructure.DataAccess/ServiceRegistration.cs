using Infrastructure.DataAccess.Interfaces;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessLayer(this IServiceCollection services)
        {           
            //var options = new DbContextOptionsBuilder<CalculatorContext>()
            //          .UseInMemoryDatabase(Guid.NewGuid().ToString())
            //          .Options;
            //var context = new CalculatorContext(options);

            services.AddDbContext<CalculatorContext>(opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddScoped<CalculatorContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IMeasureRepository, MeasureRepository>();
            services.AddScoped<IGeometricFigureRepository, GeometricFigureRepository>();
            services.AddScoped<IGeometricFigureMeasureRepository, GeometricFigureMeasureRepository>();

            //using var context = new CalculatorContext(options);

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

        }
    }
}
