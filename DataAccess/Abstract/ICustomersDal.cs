using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ICustomersDal : IEntityRepository<Customers, int>
{
    Customers Add(Customers entity);
    void Add(Customers customersToAdd);
}
