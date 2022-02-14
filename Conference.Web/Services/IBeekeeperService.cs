using Conference.Models;

namespace Conference.Services;

public interface IBeekeeperService
{
    List<Beekeeper> Get();
    Beekeeper Get(string id);
    Beekeeper Create(Beekeeper beekeeper);
    void Update(string id, Beekeeper beekeeper);
    void Remove(string id);
}