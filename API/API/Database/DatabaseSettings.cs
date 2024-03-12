namespace API.Database
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string StreamsCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
