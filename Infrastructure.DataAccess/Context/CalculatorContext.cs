using DataModel.Measures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options)
        {
            LoadDbInMemory();
        }

        public DbSet<Measure> Measure { get; set; }

        public void LoadDbInMemory()
        {
            var measureList = new List<Measure>()
            {
                new Measure { Id = 1, Name = "Metres", Abbreviation = "m", Description = "Metres", Active = true },
                new Measure { Id = 2, Name = "Kilometres", Abbreviation = "km", Description = "Kilometres", Active = true },
                new Measure { Id = 3, Name = "Miles", Abbreviation = "mi", Description = "Miles", Active = true },
                new Measure { Id = 4, Name = "Feets", Abbreviation = "ft", Description = "Feets", Active = true }
            };

            Measure.AddRange(measureList);

            this.SaveChanges();
        }
    }
}
