namespace AllwinAPI.Db.DbModel
{
    public class Stop
    {
        public int StopId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Adress { get; set; } = String.Empty;
        public float TownId { get; set; }
        public float Latitude { get; set; }
        public int Longitude { get; set; }
        public string ContactPerson { get; set; } = String.Empty;
        public string ContactPhone { get; set; } = String.Empty;
        public Town Town { get; set; } = new Town();
        public List<StopInRoute> Routes { get; set; } = new List<StopInRoute>();
        public List<JobStop> JobStops { get; set; } = new List<JobStop>();

    }
}
