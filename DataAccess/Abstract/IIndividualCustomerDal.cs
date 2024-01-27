using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IIndividualCustomerDal : IEntityRepository<IndividualCustomer, int>
{
}
