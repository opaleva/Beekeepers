namespace Notifications.Models;

public interface IBeekeeperStoreDatabaseSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    string ParticipantsCollectionName { get; set; }
}