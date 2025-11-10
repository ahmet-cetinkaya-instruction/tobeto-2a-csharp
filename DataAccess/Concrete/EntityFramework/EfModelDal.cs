using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfModelDal : EfEntityRepositoryBase<Model, int, RentACarContext>, IModelDal
{
    public EfModelDal(RentACarContext context) : base(context)
    {
    }
}
