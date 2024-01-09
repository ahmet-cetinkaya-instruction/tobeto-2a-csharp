namespace Core.DataAccess;

public interface IEntityRepository<TEntity, TEntityId>
{
    public IList<TEntity> GetList();
    public TEntity? GetById(TEntityId id);
    public void Add(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
}
