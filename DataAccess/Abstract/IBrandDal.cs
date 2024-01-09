using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IBrandDal : IEntityRepository<Brand, int>
{
    // CRUD - Create, Read, Update, Delete
    //public IList<Brand> GetBrandsByNameSearch(string nameSearch);
}
