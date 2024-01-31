using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ICorporateCustomerDal : IEntityRepository<CorporateCustomer, int>
{
}
