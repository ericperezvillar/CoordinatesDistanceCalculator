using Application.DTOs;
using Application.Wrappers;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDistanceService
    {
        Task<Response<DistanceCalculatorResult>> GetDistanceBetweenCoordinates(DistanceCalculatorRequest request);
    }
}
