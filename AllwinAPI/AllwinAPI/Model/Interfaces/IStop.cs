namespace AllwinAPI.Model
{
    public interface IStop
    {
        int StopId { get; set; }
        int RouteId { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        string Name { get; set; }
        string Adress { get; set; }
    }
}
