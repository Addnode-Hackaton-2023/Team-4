namespace AllwinAPI.Model
{
    public class StopDO
    {
        public int routeId { get; set; }
        public int stopId { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
    }
}