using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IBrandDal : IEntityRepository<Brand, int>
{
    // CRUD - Create, Read, Update, Delete

    // IEntityRepository<Brand, int> kalıtımının örnek canlandırması:
    //public void Add(Brand entity);
    //public void Delete(Brand entity);
    //public Brand? GetById(int id);
    //public IList<Brand> GetList();
    //public void Update(Brand entity);
    //

    //public IList<Brand> GetBrandsByNameSearch(string nameSearch);
}
