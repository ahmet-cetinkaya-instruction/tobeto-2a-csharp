using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;
using static Class1;

namespace DataAccess.Concrete.InMemory;

public class InMemoryUsersDal : InMemoryEntityRepositoryBase<Users, int>, IUsersDal
{
    protected override int generateId()
    {
        int nextId = Entities.Count == 0
            ? 1
            : Entities.Max(e => e.Id) + 1;
        return nextId;
    }
}