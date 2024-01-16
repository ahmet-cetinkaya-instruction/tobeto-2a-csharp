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

    //public IList<Fuel> GetFuelsByNameSearch(string nameSearch)
    //{
    //    throw new NotImplementedException();
    //}

    public Fuel? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Fuel> GetList()
    {
        throw new NotImplementedException();
    }

    public void Update(Fuel entity)
    {
        throw new NotImplementedException();
    }
}
