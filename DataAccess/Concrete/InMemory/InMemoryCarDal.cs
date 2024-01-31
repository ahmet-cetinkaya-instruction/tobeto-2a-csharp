using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryCarDal : InMemoryEntityRepositoryBase<Car, int>, ICarDal
{
    protected override int generateId()
    {
        int nextId = Entities.Count == 0 
            ? 1 
            : Entities.Max(e => e.Id) + 1;
        return nextId;
    }

    // InMemoryEntityRepositoryBase<Car, int> kalıtımın örnek uygulaması:
    //private readonly HashSet<Car> _entities = new();
    //public void Add(Car entity)
    //{
    //    entity.CreatedAt = DateTime.UtcNow;
    //    _entities.Add(entity);
    //}
    //public void Delete(Car entity)
    //{
    //    entity.DeletedAt = DateTime.UtcNow;
    //}
    //public Car? GetById(int id)
    //{
    //    Car? entity = _entities.FirstOrDefault(
    //        e => e.Id.Equals(id) && e.DeletedAt.HasValue == false
    //    );
    //    return entity;
    //}
    //public IList<Car> GetList()
    //{
    //    IList<Car> entities = _entities.Where(e => e.DeletedAt.HasValue == false).ToList();
    //    return entities;
    //}
    //public void Update(Car entity)
    //{
    //    entity.UpdateAt = DateTime.UtcNow;
    //}

    //public IList<Car> GetCarsByNameSearch(string nameSearch)
    //{
    //    throw new NotImplementedException();
    //}
}
