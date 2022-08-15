using DataModel.Measures;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Interfaces
{
    public interface IGeometricFigureMeasureRepository : IGenericRepository<GeometricFigureMeasure>
    {
        Task<GeometricFigureMeasure> GetEarthMeasure(int measureId);
    }
}
