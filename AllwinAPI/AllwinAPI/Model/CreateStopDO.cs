namespace AllwinAPI.Model
{
    public class CreateStopDO
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
    }
}
