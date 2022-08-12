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

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IMeasureRepository, MeasureRepository>();

            //using var context = new CalculatorContext(options);

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //context.AddRange(
            //    new Measure { Id = 1, Name = "Metres", Abbreviation = "m", Description = "Metres", Active = true },
            //    new Measure { Id = 1, Name = "Kilometres", Abbreviation = "km", Description = "Kilometres", Active = true },
            //    new Measure { Id = 1, Name = "Miles", Abbreviation = "mi", Description = "Miles", Active = true },
            //    new Measure { Id = 1, Name = "Feets", Abbreviation = "ft", Description = "Feets", Active = true });

            //context.SaveChanges();
        }
    }
}
