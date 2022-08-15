﻿namespace Application.Interfaces
{
    public interface ICoordinatesValidator
    {
        bool AreValidCoordinates(double lat1, double lon1, double lat2, double lon2);
    }
}
