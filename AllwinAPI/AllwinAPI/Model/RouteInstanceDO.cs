namespace AllwinAPI.Model
{
    public class RouteInstanceDO
    {
        public int RouteInstanceId { get; set; }
        public string RouteName { get; set; } = string.Empty;
        public DateTime ETA { get; set; }
        public double LatestLatitude { get; set; }
        public double LatestLongitude { get; set; }
        public double LoadedWeight { get; set; }
    }
}