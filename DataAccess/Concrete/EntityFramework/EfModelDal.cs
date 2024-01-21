using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;
internal class EfModelDal : IModelDal
{
    public void Add(Model entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Model entity)
    {
        throw new NotImplementedException();
    }

    //public IList<Model> GetModelsByNameSearch(string nameSearch)
    //{
    //    throw new NotImplementedException();
    //}

    public Model? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Model> GetList()
    {
        throw new NotImplementedException();
    }

    public void Update(Model entity)
    {
        throw new NotImplementedException();
    }
}
