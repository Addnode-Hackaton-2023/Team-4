namespace AllwinAPI.Model
{
    public class CreateRouteDO
    {
        public int TownId { get; set; }
        public string RouteName { get; set; } = string.Empty;
        public List<CreateStopDO> Stops { get; set; } = new List<CreateStopDO>();

    }
}