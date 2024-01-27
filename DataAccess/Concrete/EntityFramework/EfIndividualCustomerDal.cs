using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

internal class EfIndividualCustomerDal : IIndividualCustomerDal
{
    public IndividualCustomer Add(IndividualCustomer entity)
    {
        throw new NotImplementedException();
    }

    public IndividualCustomer Delete(IndividualCustomer entity, bool softDelete)
    {
        throw new NotImplementedException();
    }

    public IndividualCustomer? Get(Func<IndividualCustomer, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IList<IndividualCustomer> GetList(Func<IndividualCustomer, bool>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public IndividualCustomer Update(IndividualCustomer entity)
    {
        throw new NotImplementedException();
    }
}