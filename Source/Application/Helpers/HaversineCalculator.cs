using Application.Interfaces;
using System;

namespace Application.Helpers
{
    public class HaversineCalculator : IHaversineCalculator
    {
        public double GetDistanceSphere(double lat1, double lon1, double lat2, double lon2)
        {
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            return 2 * Math.Asin(Math.Sqrt(a));
        }
    }
}
