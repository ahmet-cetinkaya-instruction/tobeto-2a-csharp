using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITransmissionDal : IEntityRepository<Transmission, int>
    {
        // IEntityRepository<Model, int> kalıtımının örnek canlandırması:
        //public IList<Model> GetList();
        //public Model? GetById(int id);
        //public void Add(Model entity);
        //public void Update(Model entity);
        //public void Delete(Model entity);
    }

}
