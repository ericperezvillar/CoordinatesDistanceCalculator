using Application.DTOs;
using Application.Enums;
using Application.Helpers;
using Application.Interfaces;
using Application.Wrappers;
using CoreLog.Interfaces;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Threading.Tasks;
using Utilities;

namespace Application.Services
{
    public class DistanceService : IDistanceService
    {
        private readonly ICoreLogger _coreLogger;
        private readonly IMeasureCache _measureCache;
        private readonly IGeometricFigureMeasureRepository _geometricFigureMeasureRepository;
        private readonly ICoordinatesValidator _coordinatesValidator;
        private readonly IHaversineCalculator _haversineCalculator;

        public DistanceService(ICoreLogger coreLogger, IMeasureCache measureCache, IHaversineCalculator haversineCalculator, IGeometricFigureMeasureRepository geometricFigureMeasureRepository, ICoordinatesValidator coordinatesValidator)
        {
            _coreLogger = coreLogger;
            _measureCache = measureCache;
            _haversineCalculator = haversineCalculator;
            _geometricFigureMeasureRepository = geometricFigureMeasureRepository;
            _coordinatesValidator = coordinatesValidator;
        }

        public async Task<Response<DistanceCalculatorResult>> GetDistanceBetweenCoordinates(DistanceCalculatorRequest request)
        {
            try
            {
                _coreLogger.Info("GetDistanceBetweenCoordinates running");

                if(!_coordinatesValidator.AreValidCoordinates(request.FirstCoordinate.Latitud, request.FirstCoordinate.Longitud, request.SecondCoordinate.Latitud, request.SecondCoordinate.Longitud))
                    return new InvalidResponse<DistanceCalculatorResult>(new string[] { "Coordinates are not valid." });

                // Get from cache the Measure value
                var measure = request.MeasuringUnit == null ? await _measureCache.GetMeasureByNameAsync(MeasuringUnitKeys.Kilometres.ToString()) : await _measureCache.GetMeasureByNameAsync(request.MeasuringUnit.ToString());

                // For simplicity, I calculate the distance between coordinates only in the Earth.
                // It could be extended to more planets. In this case, we will need to have an extra parameter for the GeometricFigure.
                // This is something to be more generic and getting/setting  the GeometricFigure before calling 
                var earthMeasureByUnit = await _geometricFigureMeasureRepository.GetEarthMeasure(measure.Id);

                if(earthMeasureByUnit == null)
                    return new InvalidResponse<DistanceCalculatorResult>(new string[] { "Earth measure wasn't found." });

                // Converts from degrees to radians.           
                var lat1 = DataFormatConvertor.ConvertToRadians(request.FirstCoordinate.Latitud);
                var lon1 = DataFormatConvertor.ConvertToRadians(request.FirstCoordinate.Longitud);
                var lat2 = DataFormatConvertor.ConvertToRadians(request.SecondCoordinate.Latitud);
                var lon2 = DataFormatConvertor.ConvertToRadians(request.SecondCoordinate.Longitud);

                // Distance on a sphere: The Haversine Formula
                var distance = _haversineCalculator.GetDistanceSphere(lat1, lon1, lat2, lon2);

                var resultBetweenCoordinates = (distance * earthMeasureByUnit.Distance);

                var result = new DistanceCalculatorResult() { Distance = Math.Round(resultBetweenCoordinates, 2), Measure = measure };

                return new SuccessResponse<DistanceCalculatorResult>(result);

            }
            catch (Exception ex)
            {
                return new ErrorHandler<DistanceCalculatorResult>(_coreLogger).LogError("Failed to get distance between coordinates", ex, request);
            }
        }
    }
}
