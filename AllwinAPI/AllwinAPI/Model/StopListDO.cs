namespace AllwinAPI.Model
{
    public class StopListDO : IStop
    {
        public int StopId { get; set; }
        public int RouteId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
    }
}
