namespace Notifications.Models;

public class BeekeeperStoreDatabaseSettings : IBeekeeperStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = String.Empty;
    public string DatabaseName { get; set; } = String.Empty;
    public string ParticipantsCollectionName { get; set; } = String.Empty;
}