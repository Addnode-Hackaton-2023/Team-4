namespace AllwinAPI.Model
{
    public interface IStop
    {
        int StopId { get; set; }
        int RouteId { get; set; }
        float Latitude { get; set; }
        float Longitude { get; set; }
        string Name { get; set; }
        string Adress { get; set; }
    }
}
