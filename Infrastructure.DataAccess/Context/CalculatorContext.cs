using DataModel.GeometricFigures;
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

        public DbSet<GeometricFigure> GeometricFigure { get; set; }

        public DbSet<GeometricFigureMeasure> GeometricFigureMeasure { get; set; }

        public void LoadDbInMemory()
        {
            var measureList = new List<Measure>()
            {
                new Measure { Id = 1, Name = "Metres", Abbreviation = "m", Description = "Metres", Active = true },
                new Measure { Id = 2, Name = "Kilometres", Abbreviation = "km", Description = "Kilometres", Active = true },
                new Measure { Id = 3, Name = "Miles", Abbreviation = "mi", Description = "Miles", Active = true },
                new Measure { Id = 4, Name = "Feets", Abbreviation = "ft", Description = "Feets", Active = true }
            };

            var geometricFigureList = new List<GeometricFigure>()
            {
                new GeometricFigure { Id = 1, Name = "Earth", Description = "Earth" }
            };

            var geometricFigureMeasureList = new List<GeometricFigureMeasure>()
            {
                new GeometricFigureMeasure { Id = 1, GeometricFigure = geometricFigureList[0], Measure = measureList[0], Distance = 6371000 },
                new GeometricFigureMeasure { Id = 2, GeometricFigure = geometricFigureList[0], Measure = measureList[1], Distance = 6371 },
                new GeometricFigureMeasure { Id = 3, GeometricFigure = geometricFigureList[0], Measure = measureList[2], Distance = 3958.8 },
                new GeometricFigureMeasure { Id = 4, GeometricFigure = geometricFigureList[0], Measure = measureList[3], Distance = 20902000 },
            };

            Measure.AddRange(measureList);
            GeometricFigure.AddRange(geometricFigureList);
            GeometricFigureMeasure.AddRange(geometricFigureMeasureList);

            this.SaveChanges();
        }
    }
}
