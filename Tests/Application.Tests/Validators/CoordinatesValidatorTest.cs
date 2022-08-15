using Application.Interfaces;
using Application.Validators;
using Xunit;

namespace Application.Tests.Validators
{
    public class CoordinatesValidatorTest
    {
        private ICoordinatesValidator _coordinatesValidator;

        public CoordinatesValidatorTest()
        {
            _coordinatesValidator = new CoordinatesValidator();
        }

        [Theory]
        [InlineData(50.51544, -20.15476, 84.542146, -5.25677)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(89, 179, -89, -179)]
        public void AreValidCoordinates_HappyCase(double lat1, double lon1, double lat2, double lon2)
        {
            var result = _coordinatesValidator.AreValidCoordinates(lat1, lon1, lat2, lon2);
            Assert.True(result);
        }

        [Theory]
        [InlineData(10, -20.15476, 91, -5.25677)]
        [InlineData(10, 10, 180, 10)]
        [InlineData(89, 179, -89, -181)]
        public void AreValidCoordinates_ReturnFalse(double lat1, double lon1, double lat2, double lon2)
        {
            var result = _coordinatesValidator.AreValidCoordinates(lat1, lon1, lat2, lon2);
            Assert.False(result);
        }
    }
}
