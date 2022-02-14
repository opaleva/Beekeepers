namespace Conference.Models;

public class BeekeeperStoreDatabaseSettings : IBeekeeperStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = String.Empty;
    public string DatabaseName { get; set; } = String.Empty;
    public string BeekeepersCollectionName { get; set; } = String.Empty;
}