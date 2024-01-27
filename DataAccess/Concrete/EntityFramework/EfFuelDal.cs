using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;
internal class EfFuelDal : IFuelDal
{
    public void Add(Fuel entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Fuel entity)
    {
        throw new NotImplementedException();
    }

    public Fuel Delete(Fuel entity, bool isSoftDelete = true)
    {
        throw new NotImplementedException();
    }

    public Fuel? Get(Func<Fuel, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public Fuel? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Fuel> GetList()
    {
        throw new NotImplementedException();
    }

    public IList<Fuel> GetList(Func<Fuel, bool>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public void Update(Fuel entity)
    {
        throw new NotImplementedException();
    }

    Fuel IEntityRepository<Fuel, int>.Add(Fuel entity)
    {
        throw new NotImplementedException();
    }

    Fuel IEntityRepository<Fuel, int>.Update(Fuel entity)
    {
        throw new NotImplementedException();
    }
}
