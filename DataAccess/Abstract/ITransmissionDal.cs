using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ITransmissionDal : IEntityRepository<Transmission, int>
{
    // CRUD - Create, Read, Update, Delete

    // IEntityRepository<Transmission, int> kalıtımının örnek canlandırması:
    //public void Add(Transmission entity);
    //public void Delete(Transmission entity);
    //public Transmission? GetById(int id);
    //public IList<Transmission> GetList();
    //public void Update(Transmission entity);
    //

    //public IList<Transmission> GetTransmissionsByNameSearch(string nameSearch);
}
