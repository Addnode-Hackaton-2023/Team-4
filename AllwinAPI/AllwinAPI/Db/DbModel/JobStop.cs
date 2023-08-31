namespace AllwinAPI.Db.DbModel
{
    public class JobStop
    {
        public int JobStopId { get; set; }
        public int JobId { get; set; }
        public int StopOrder { get; set; }
        public int StopId { get; set; }
        public double? LoadedWeight { get; set; }
        public string? DeviationComment { get; set; }
        public bool Completed { get; set; }
        public Stop Stop { get; set; } = new Stop();
        public Job Job { get; set; } = new Job();

    }
}
