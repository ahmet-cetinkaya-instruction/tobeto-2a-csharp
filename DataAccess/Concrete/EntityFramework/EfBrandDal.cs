using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;
internal class EfBrandDal : IBrandDal
{
    public void Add(Brand entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Brand entity)
    {
        throw new NotImplementedException();
    }

    //public IList<Brand> GetBrandsByNameSearch(string nameSearch)
    //{
    //    throw new NotImplementedException();
    //}

    public Brand? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Brand> GetList()
    {
        throw new NotImplementedException();
    }

    public void Update(Brand entity)
    {
        throw new NotImplementedException();
    }
}
