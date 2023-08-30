namespace AllwinAPI.Model
{
    public class CreateRouteDO
    {
        public int TownId { get; set; }
        public string RouteName { get; set; } = string.Empty;
        public List<StopListDO> Stops { get; set; } = new List<StopListDO>();

    }
}