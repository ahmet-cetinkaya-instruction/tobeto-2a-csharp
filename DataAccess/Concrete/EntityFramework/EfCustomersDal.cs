using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework;

internal class EfCustomersDal : ICustomersDal
{
    public Customers Add(Customers entity)
    {
        throw new NotImplementedException();
    }

    public global::Customers Add(global::Customers entity)
    {
        throw new NotImplementedException();
    }
    public Customers Delete(Customers entity, bool softDelete)
    {
        throw new NotImplementedException();
    }

    public global::Customers Delete(global::Customers entity, bool isSoftDelete = true)
    {
        throw new NotImplementedException();
    }

    public Customers? Get(Func<Customers, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public global::Customers? Get(Func<global::Customers, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IList<Customers> GetList(Func<Customers, bool>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public IList<global::Customers> GetList(Func<global::Customers, bool>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public Customers Update(Customers entity)
    {
        throw new NotImplementedException();
    }

    public global::Customers Update(global::Customers entity)
    {
        throw new NotImplementedException();
    }

    void ICustomersDal.Add(Customers customersToAdd)
    {
        throw new NotImplementedException();
    }
}