namespace AllwinAPI.Model
{
    public class JobDO
    {
        public int JobId { get; set; }
        public int RouteId { get; set; }
        public string RouteName { get; set; } = string.Empty;
        public string TownName { get; set; } = string.Empty;
        public DateTime? ETA { get; set; }
        public double? LatestLatitude { get; set; }
        public double? LatestLongitude { get; set; }
        public double LoadedWeight { get; set; }
<<<<<<< Updated upstream
        public List<StopCompleteDO> Stops { get; set; } = new List<StopCompleteDO>();
=======
        public List<JobStopDO> JobStops { get; set; } = new List<JobStopDO>();
>>>>>>> Stashed changes
    }
}