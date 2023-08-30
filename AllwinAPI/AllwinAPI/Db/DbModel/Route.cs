namespace AllwinAPI.Db.DbModel
{
    public class Route
    {
        public int RouteId { get; set; }
        public int TownId { get; set; }
        public string RouteName { get; set; } = String.Empty;
        public Town Town { get; set; } = new Town();

    }
}
