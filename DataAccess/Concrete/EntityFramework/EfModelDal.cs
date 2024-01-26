using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfModelDal : IModelDal
{
    private readonly RentACarContext _context;

    public EfModelDal(RentACarContext context)
    {
        _context = context;
    }

    public Model Add(Model entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        //_context.Entry(entity).State = EntityState.Added;
        _context.Models.Add(entity);

        _context.SaveChanges(); // Unit of Work
        return entity;
    }

    public Model Delete(Model entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.UtcNow;
        // _context.Entry(entity).State = EntityState.Modified;

        if (!isSoftDelete)
            _context.Models.Remove(entity);

        _context.SaveChanges();
        return entity;
    }

    public Model? Get(Func<Model, bool> predicate)
    {
        Model? model = _context.Models.FirstOrDefault(predicate); // örn. FirstOrDefault() metodu veritabanına sorguyu çalıştırır.
        return model;
    }

    public IList<Model> GetList(Func<Model, bool>? predicate = null)
    {
        IQueryable<Model> query = _context.Set<Model>();
        if (predicate != null)
            query = query.Where(predicate).AsQueryable();

        return query.ToList(); // örn. ToList() metodu veritabanına sorguyu çalıştırır.
    }

    public Model Update(Model entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        _context.Models.Update(entity);

        _context.SaveChanges();
        return entity;
    }
}
