using DataModel.GeometricFigures;
using Infrastructure.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class GeometricFigureRepository : GenericRepository<GeometricFigure>, IGeometricFigureRepository
    { 
        private readonly DbSet<GeometricFigure> _geometricFigure;

        public GeometricFigureRepository(CalculatorContext dbContext) : base(dbContext)
        {
            _geometricFigure = dbContext.Set<GeometricFigure>();
        }
    }
}
