using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;
internal class EfCarDal : ICarDal
{
    public void Add(Car entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Car entity)
    {
        throw new NotImplementedException();
    }

    public Car Delete(Car entity, bool isSoftDelete = true)
    {
        throw new NotImplementedException();
    }

    public Car? Get(Func<Car, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public Car? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Car> GetList()
    {
        throw new NotImplementedException();
    }

    public IList<Car> GetList(Func<Car, bool>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public void Update(Car entity)
    {
        throw new NotImplementedException();
    }

    Car IEntityRepository<Car, int>.Add(Car entity)
    {
        throw new NotImplementedException();
    }

    Car IEntityRepository<Car, int>.Update(Car entity)
    {
        throw new NotImplementedException();
    }
}
