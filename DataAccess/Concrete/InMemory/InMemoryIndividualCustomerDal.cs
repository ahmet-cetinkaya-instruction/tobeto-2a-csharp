using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryIndividualCustomerDal : InMemoryEntityRepositoryBase<IndividualCustomer, int>, IIndividualCustomerDal
{
    protected override int generateId()
    {
        int nextId = Entities.Count == 0
            ? 1
            : Entities.Max(e => e.Id) + 1;
        return nextId;
    }
}