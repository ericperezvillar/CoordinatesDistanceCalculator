using DataModel.Measures;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMeasureCache
    {
        Task<Measure> GetMeasureByNameAsync(string name);
    }
}
