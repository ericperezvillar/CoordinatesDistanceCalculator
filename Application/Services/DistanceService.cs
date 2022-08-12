using Application.DTOs;
using Application.Enums;
using Application.Helpers;
using Application.Interfaces;
using Application.Wrappers;
using CoreLog.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DistanceService : IDistanceService
    {
        private readonly ICoreLogger _coreLogger;

        public DistanceService(ICoreLogger coreLogger)
        {
            _coreLogger = coreLogger;
        }

        public async Task<Response<DistanceCalculatorResult>> GetDistanceBetweenCoordinates(DistanceCalculatorRequest request)
        {
            try
            {
                var result = new DistanceCalculatorResult();

                return new SuccessResponse<DistanceCalculatorResult>(result);

            }
            catch (Exception ex)
            {
                return new ErrorHandler<DistanceCalculatorResult>(_coreLogger).LogError("Failed to get distance between coordinates", ex, request);
            }
        }

        private double CalculateDistance(double latitud1,
                               double longitud1,
                               double latitud2,
                               double longitud2,
                               MeasuringUnit measuringUnit)
        {

            // Converts from degrees to radians.           
            var lat1 = toRadians(latitud1);
            var lon1 = toRadians(longitud1);
            var lat2 = toRadians(latitud2);
            var lon2 = toRadians(longitud2);

            // Haversine formula
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Radius of earth in
            // kilometers. Use 3956
            // for miles
            double r = 6371;

            // calculate the result
            return (c * r);
        }
    }
}
