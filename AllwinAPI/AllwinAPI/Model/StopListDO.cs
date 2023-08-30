namespace AllwinAPI.Model
{
    public class StopListDO : IStop
    {
        public int StopId { get; set; }
        public int RouteId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get;set; } = string.Empty;
        public string Name { get;set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
    }
}
