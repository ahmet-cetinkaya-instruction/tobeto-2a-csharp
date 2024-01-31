using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

internal class EfCustomersDal : ICustomersDal
{
    public Customers Add(Customers entity)
    {
        throw new NotImplementedException();
    }

    public Customers Delete(Customers entity, bool softDelete)
    {
        throw new NotImplementedException();
    }

    public Customers? Get(Func<Customers, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IList<Customers> GetList(Func<Customers, bool>? predicate = null)
    {
        throw new NotImplementedException();
    }


    public Customers Update(Customers entity)
    {
        throw new NotImplementedException();
    }
}