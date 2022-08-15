using DataModel.Measures;
using Infrastructure.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
{
    public class GeometricFigureMeasureRepository : GenericRepository<GeometricFigureMeasure>, IGeometricFigureMeasureRepository
    {
        private readonly DbSet<GeometricFigureMeasure> _geometricFigureMeasure;

        public GeometricFigureMeasureRepository(CalculatorContext dbContext) : base(dbContext)
        {
            _geometricFigureMeasure = dbContext.Set<GeometricFigureMeasure>();
        }
        
        public async Task<GeometricFigureMeasure> GetEarthMeasure(int measureId)
        {            
            return await _geometricFigureMeasure.Where(x => x.GeometricFigure.Name == "Earth" && x.Measure.Id == measureId).FirstOrDefaultAsync();
        }

    }
}
