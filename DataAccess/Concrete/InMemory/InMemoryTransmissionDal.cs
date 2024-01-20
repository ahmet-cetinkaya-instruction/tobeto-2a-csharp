using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory;

public class InMemoryTransMissionDal : InMemoryEntityRepositoryBase<Transmission, int>, ITransmissionDal
{
    protected override int generateId()
    {
        int nextId = _entities.Count == 0 ? 1 : _entities.Max(e => e.Id) + 1;
        return nextId;
    }
}
