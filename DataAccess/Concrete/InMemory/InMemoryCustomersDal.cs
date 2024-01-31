using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryCustomersDal : InMemoryEntityRepositoryBase<Customers, int>, ICustomersDal
{
    public void Add(Customers customersToAdd)
    {
        throw new NotImplementedException();
    }

    protected override int generateId()
    {
        int nextId = Entities.Count == 0
            ? 1
            : Entities.Max(e => e.Id) + 1;
        return nextId;
    }

   /* protected Customers Add(Customers customersToAdd)
    {
        throw new NotImplementedException();
    }*/
}