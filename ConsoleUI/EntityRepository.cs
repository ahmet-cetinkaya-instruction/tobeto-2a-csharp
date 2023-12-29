using Newtonsoft.Json;

namespace ConsoleUI;

internal class EntityRepository
{
    internal void UpdateEntity(Entity entity)
    {
        entity.LastUpdatedAt = DateTime.UtcNow;
        Console.WriteLine(JsonConvert.SerializeObject(entity));
    }
}
