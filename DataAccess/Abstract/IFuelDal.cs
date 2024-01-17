using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IFuelDal : IEntityRepository<Fuel, int>
{
    // CRUD - Create, Read, Update, Delete

    // IEntityRepository<Full, int> kalıtımının örnek canlandırması:
    //public void Add(Full entity);
    //public void Delete(Full entity);
    //public Full? GetById(int id);
    //public IList<Full> GetList();
    //public void Update(Full entity);
    //

    //public IList<Full> GetFullsByNameSearch(string nameSearch);
}
