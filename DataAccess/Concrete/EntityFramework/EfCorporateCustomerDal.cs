using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

internal class EfCorporateCustomerDal : ICorporateCustomerDal
{
    public CorporateCustomer Add(CorporateCustomer entity)
    {
        throw new NotImplementedException();
    }

    public CorporateCustomer Delete(CorporateCustomer entity, bool softDelete)
    {
        throw new NotImplementedException();
    }

    public CorporateCustomer? Get(Func<CorporateCustomer, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IList<CorporateCustomer> GetList(Func<CorporateCustomer, bool>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public CorporateCustomer Update(CorporateCustomer entity)
    {
        throw new NotImplementedException();
    }
}