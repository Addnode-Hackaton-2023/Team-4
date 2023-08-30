namespace AllwinAPI.Db.DbModel
{
    public class StopInRoute
    {
        public int StopId { get; set; }
        public int RouteId { get; set; }
        public int StopOrder { get; set; }
        public Route Route { get; set; } = new Route();
        public Stop Stop { get; set; } = new Stop();

    }
}
