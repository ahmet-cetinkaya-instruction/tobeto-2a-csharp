using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ICustomersDal : IEntityRepository<Customers, int>
{
    // CRUD - Create, Read, Update, Delete

    // IEntityRepository<Customers, int> kalıtımının örnek canlandırması:
    //public void Add(Customers entity);
    //public void Delete(Customers entity);
    //public Customers? GetById(int id);
    //public IList<Customers> GetList();
    //public void Update(Customers entity);
    //

    //public IList<Customers> GetCustomerssByNameSearch(string nameSearch);
}
