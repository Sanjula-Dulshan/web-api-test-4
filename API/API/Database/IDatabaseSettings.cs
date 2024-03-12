namespace API.Database
{
    public interface IDatabaseSettings
    {
        string StreamsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
