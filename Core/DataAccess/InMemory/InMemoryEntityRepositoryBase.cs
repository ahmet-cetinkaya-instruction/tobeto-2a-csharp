using Core.Entities;

namespace Core.DataAccess.InMemory;

public class InMemoryEntityRepositoryBase<TEntity, TEntityId>
    : IEntityRepository<TEntity, TEntityId>
    where TEntity : class, IEntity<TEntityId>, new()
{
    private readonly HashSet<TEntity> _entities = new();

    public void Add(TEntity entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        _entities.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
    }

    public TEntity? GetById(TEntityId id)
    {
        TEntity? entity = _entities.FirstOrDefault(
            e => e.Id.Equals(id) && e.DeletedAt.HasValue == false
        );
        return entity;
    }

    public IList<TEntity> GetList()
    {
        IList<TEntity> entities = _entities.Where(e => e.DeletedAt.HasValue == false).ToList();
        return entities;
    }

    public void Update(TEntity entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
    }
}
