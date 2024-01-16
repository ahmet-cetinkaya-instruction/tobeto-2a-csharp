using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;
internal class EfTransmissionDal : ITransmissionDal
{
    public void Add(Transmission entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Transmission entity)
    {
        throw new NotImplementedException();
    }

    //public IList<Transmission> GetTransmissionsByNameSearch(string nameSearch)
    //{
    //    throw new NotImplementedException();
    //}

    public Transmission? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Transmission> GetList()
    {
        throw new NotImplementedException();
    }

    public void Update(Transmission entity)
    {
        throw new NotImplementedException();
    }
}
