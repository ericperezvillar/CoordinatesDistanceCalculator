using Application.Interfaces;

namespace Application.Validators
{
    public class CoordinatesValidator : ICoordinatesValidator
    {
        public bool AreValidCoordinates(double lat1, double lon1, double lat2, double lon2)
        {
            return IsValidLatitud(lat1) && IsValidLatitud(lat2) && IsValidLongitud(lon1) && IsValidLongitud(lon2);
        }

        // Latitud goes from 90 to -90
        private bool IsValidLatitud(double latitud)
        {
            return latitud <= 90 && latitud >= -90;
        }

        // Latitud goes from 180 to -180 , but it nevers touch it
        private bool IsValidLongitud(double longitud)
        {
            return longitud < 180 && longitud > -180;
        }
    }
}
