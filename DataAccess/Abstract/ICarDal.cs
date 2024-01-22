using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ICarDal : IEntityRepository<Car, int>
{
    // CRUD - Create, Read, Update, Delete

    // IEntityRepository<Car, int> kalıtımının örnek canlandırması:
    //public void Add(Car entity);
    //public void Delete(Car entity);
    //public Car? GetById(int id);
    //public IList<Car> GetList();
    //public void Update(Car entity);
    //

    //public IList<Car> GetCarsByNameSearch(string nameSearch);
}
