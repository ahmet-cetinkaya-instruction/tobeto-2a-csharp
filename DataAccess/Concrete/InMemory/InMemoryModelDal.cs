using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryModelDal : InMemoryEntityRepositoryBase<Model, int>, IModelDal
{
    protected override int generateId()
    {
        int nextId = _entities.Count == 0
            ? 1
            : _entities.Max(e => e.Id) + 1;
        return nextId;
    }

    // InMemoryEntityRepositoryBase<Model, int> kalıtımın örnek uygulaması:
    //private readonly HashSet<Model> _entities = new();
    //public void Add(Model entity)
    //{
    //    entity.CreatedAt = DateTime.UtcNow;
    //    _entities.Add(entity);
    //}
    //public void Delete(Model entity)
    //{
    //    entity.DeletedAt = DateTime.UtcNow;
    //}
    //public Model? GetById(int id)
    //{
    //    Model? entity = _entities.FirstOrDefault(
    //        e => e.Id.Equals(id) && e.DeletedAt.HasValue == false
    //    );
    //    return entity;
    //}
    //public IList<Model> GetList()
    //{
    //    IList<Model> entities = _entities.Where(e => e.DeletedAt.HasValue == false).ToList();
    //    return entities;
    //}
    //public void Update(Model entity)
    //{
    //    entity.UpdateAt = DateTime.UtcNow;
    //}

    //public IList<Model> GetModelsByNameSearch(string nameSearch)
    //{
    //    throw new NotImplementedException();
    //}
}
