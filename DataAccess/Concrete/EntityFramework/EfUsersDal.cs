using DataAccess.Abstract;
using Entities.Concrete;
using static Class1;

namespace DataAccess.Concrete.EntityFramework;

internal class EfUsersDal : IUsersDal
{
    public Users Add(Users entity)
    {
        throw new NotImplementedException();
    }

    public Users Delete(Users entity, bool softDelete)
    {
        throw new NotImplementedException();
    }

    public Users? Get(Func<Users, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IList<Users> GetList(Func<Users, bool>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public Users Update(Users entity)
    {
        throw new NotImplementedException();
    }
}