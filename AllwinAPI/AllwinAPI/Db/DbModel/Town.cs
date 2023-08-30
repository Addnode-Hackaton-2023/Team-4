namespace AllwinAPI.Db.DbModel
{
    public class Town
    {
        public int TownId { get; set; }
        public string TownName { get; set; } = String.Empty;
        public List<Route> Routes { get; set; } = new List<Route>();

    }
}
