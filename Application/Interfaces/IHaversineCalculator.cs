namespace Application.Interfaces
{
    public interface IHaversineCalculator
    {
        double GetDistanceSphere(double lat1, double lon1, double lat2, double lon2);
    }
}
