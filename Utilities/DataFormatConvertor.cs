using System;

namespace Utilities
{
    public static class DataFormatConvertor
    {
        public static double ConvertToRadians(double angleIn10thofaDegree)
        {
            // Angle in 10th of a degree
            return (angleIn10thofaDegree * Math.PI) / 180;
        }
    }
}
