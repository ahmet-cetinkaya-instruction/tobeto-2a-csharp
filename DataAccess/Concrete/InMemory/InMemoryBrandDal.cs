using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryBrandDal : InMemoryEntityRepositoryBase<Brand, int>, IBrandDal
{
    //public IList<Brand> GetBrandsByNameSearch(string nameSearch)
    //{
    //    throw new NotImplementedException();
    //}
}
