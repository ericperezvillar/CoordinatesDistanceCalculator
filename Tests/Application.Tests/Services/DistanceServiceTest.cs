using Application.DTOs;
using Application.Enums;
using Application.Interfaces;
using Application.Services;
using CoreLog.Interfaces;
using DataModel;
using DataModel.GeometricFigures;
using DataModel.Measures;
using Infrastructure.DataAccess.Interfaces;
using Moq;
using System;
using Xunit;

namespace Application.Tests.Services
{
    public class DistanceServiceTest
    {
        private Mock<ICoreLogger> _coreLogger;
        private Mock<IMeasureCache> _measureCache;
        private Mock<IGeometricFigureMeasureRepository> _geometricFigureMeasureRepository;
        private Mock<ICoordinatesValidator> _coordinatesValidator;
        private Mock<IHaversineCalculator> _haversineCalculator;
        private IDistanceService _distanceService;
        
        public DistanceServiceTest()
        {
            _coreLogger = new Mock<ICoreLogger>();
            _measureCache = new Mock<IMeasureCache>();
            _haversineCalculator = new Mock<IHaversineCalculator>();
            _geometricFigureMeasureRepository = new Mock<IGeometricFigureMeasureRepository>();
            _coordinatesValidator = new Mock<ICoordinatesValidator>();

            _distanceService = new DistanceService(_coreLogger.Object, _measureCache.Object, _haversineCalculator.Object, _geometricFigureMeasureRepository.Object, _coordinatesValidator.Object);
        }

        [Fact]
        public void GetDistanceBetweenCoordinates_HappyPath()
        {
            var request = new DistanceCalculatorRequest()
            {
                FirstCoordinate = new GeoCoordinate() { Latitud = 53.297975, Longitud = -6.372663 },
                SecondCoordinate = new GeoCoordinate() { Latitud = 41.385101, Longitud = -81.440440},
                MeasuringUnit = MeasuringUnitKeys.Kilometres
            };

            var measure = new Measure() { Id = 1, Abbreviation = "km", Name = "Kilometres" };
            var geometricFigure = new GeometricFigure() { Id = 1, Name = "Earth" };
            var geometricFigureMeasure = new GeometricFigureMeasure() { Id = 1, Distance = 10.54, Measure = measure, GeometricFigure = geometricFigure };
            double distanceSphere = 35.10;

            _coordinatesValidator.Setup(x => x.AreValidCoordinates(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>())).Returns(true);
            _measureCache.Setup(x => x.GetMeasureByNameAsync(It.IsAny<string>())).ReturnsAsync(measure);
            _geometricFigureMeasureRepository.Setup(x => x.GetEarthMeasure(It.IsAny<int>())).ReturnsAsync(geometricFigureMeasure);
            _haversineCalculator.Setup(x => x.GetDistanceSphere(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>())).Returns(distanceSphere);

            var resultBetweenCoordinates = Math.Round(distanceSphere * geometricFigureMeasure.Distance, 2);

            var result = _distanceService.GetDistanceBetweenCoordinates(request);
            Assert.True(result.Result.Succeeded);
            Assert.Equal(resultBetweenCoordinates, result.Result.Data.Distance);
        }

        [Fact]
        public void GetDistanceBetweenCoordinates_InvalidResponse_CoordinatesInvalid()
        {
            var request = new DistanceCalculatorRequest()
            {
                FirstCoordinate = new GeoCoordinate() { Latitud = 95, Longitud = -6.372663 },
                SecondCoordinate = new GeoCoordinate() { Latitud = 41.385101, Longitud = -81.440440 },
                MeasuringUnit = MeasuringUnitKeys.Kilometres
            };

            _coordinatesValidator.Setup(x => x.AreValidCoordinates(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>())).Returns(false);
          
            var result = _distanceService.GetDistanceBetweenCoordinates(request);
            Assert.False(result.Result.Succeeded);
        }
    }
}
