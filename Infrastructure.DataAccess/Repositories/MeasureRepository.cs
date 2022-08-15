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
    }
}
