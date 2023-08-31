namespace AllwinAPI.Db.DbModel
{
    public class Job
    {
        public int JobId { get; set; }
        public int RouteId { get; set; }
        public DateTime? ETA { get; set; }
        public double? LatestLatitude { get; set; }
        public double? LatestLongitude { get; set; }
        public Route Route { get; set; } = new Route();
        public List<JobStop> JobStops { get; set; } = new List<JobStop>();
    }
}
