using Core.DataAccess;

namespace DataAccess.Abstract;

public interface ICustomersDal : IEntityRepository<Customers, int>
{
    new Customers Add(Customers entity);
    void Add(Concrete.EntityFramework.Customers customersToAdd);
    void Add(Customers customersToAdd);
}
