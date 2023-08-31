namespace AllwinAPI.Model
{
    public class JobStopDO
    {
        public int JobId { get; set; }
        public int StopId { get; set; }
        public bool IsCompleted { get; set; }
        public double? LoadedWeight { get; set; }
        public string DeviationComment { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = String.Empty;
        public string ContactPhone { get; set; } = String.Empty;
    }
}
