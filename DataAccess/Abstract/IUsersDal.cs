using Core.DataAccess;
using Entities.Concrete;
using static Class1;

namespace DataAccess.Abstract;

public interface IUsersDal : IEntityRepository<Users, int>
{
}
