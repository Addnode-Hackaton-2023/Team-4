namespace AllwinAPI
{
    public class AppSettings
    {
        public DatabaseSettings Database { get; set; }
    }

    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
    }
}
