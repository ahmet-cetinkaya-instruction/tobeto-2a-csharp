using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryTransmissionDal : InMemoryEntityRepositoryBase<Transmission, int>, ITransmissionDal
{
    protected override int generateId()
    {
        int nextId = _entities.Count == 0 
            ? 1 
            : _entities.Max(e => e.Id) + 1;
        return nextId;
    }

    // InMemoryEntityRepositoryBase<Transmission, int> kalıtımın örnek uygulaması:
    //private readonly HashSet<Transmission> _entities = new();
    //public void Add(Transmission entity)
    //{
    //    entity.CreatedAt = DateTime.UtcNow;
    //    _entities.Add(entity);
    //}
    //public void Delete(Transmission entity)
    //{
    //    entity.DeletedAt = DateTime.UtcNow;
    //}
    //public Transmission? GetById(int id)
    //{
    //    Transmission? entity = _entities.FirstOrDefault(
    //        e => e.Id.Equals(id) && e.DeletedAt.HasValue == false
    //    );
    //    return entity;
    //}
    //public IList<Transmission> GetList()
    //{
    //    IList<Transmission> entities = _entities.Where(e => e.DeletedAt.HasValue == false).ToList();
    //    return entities;
    //}
    //public void Update(Transmission entity)
    //{
    //    entity.UpdateAt = DateTime.UtcNow;
    //}

    //public IList<Transmission> GetTransmissionsByNameSearch(string nameSearch)
    //{
    //    throw new NotImplementedException();
    //}
}
