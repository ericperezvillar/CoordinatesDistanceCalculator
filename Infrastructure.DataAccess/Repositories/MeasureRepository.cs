using DataModel.Measures;
using Infrastructure.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class MeasureRepository : GenericRepository<Measure>, IMeasureRepository
    {
        private readonly DbSet<Measure> _measure;

        public MeasureRepository(CalculatorContext dbContext) : base(dbContext)
        {
            _measure = dbContext.Set<Measure>();
        }

        //private void LoadDbInMemory()
        //{
        //    var measureList = new List<Measure>()
        //    {
        //        new Measure { Id = 1, Name = "Metres", Abbreviation = "m", Description = "Metres", Active = true },
        //        new Measure { Id = 1, Name = "Kilometres", Abbreviation = "km", Description = "Kilometres", Active = true },
        //        new Measure { Id = 1, Name = "Miles", Abbreviation = "mi", Description = "Miles", Active = true },
        //        new Measure { Id = 1, Name = "Feets", Abbreviation = "ft", Description = "Feets", Active = true }
        //    };

        //    Measure.AddRange(measureList);

        //    this.SaveChanges();
        //}

    }
}
