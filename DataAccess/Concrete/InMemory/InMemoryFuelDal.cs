﻿using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryFuelDal : InMemoryEntityRepositoryBase<Fuel, int>, IFuelDal
{
    protected override int generateId()
    {
        int nextId = _entities.Count == 0 
            ? 1 
            : _entities.Max(e => e.Id) + 1;
        return nextId;
    }

    // InMemoryEntityRepositoryBase<Brand, int> kalıtımın örnek uygulaması:
    //private readonly HashSet<Brand> _entities = new();
    //public void Add(Brand entity)
    //{
    //    entity.CreatedAt = DateTime.UtcNow;
    //    _entities.Add(entity);
    //}
    //public void Delete(Brand entity)
    //{
    //    entity.DeletedAt = DateTime.UtcNow;
    //}
    //public Brand? GetById(int id)
    //{
    //    Brand? entity = _entities.FirstOrDefault(
    //        e => e.Id.Equals(id) && e.DeletedAt.HasValue == false
    //    );
    //    return entity;
    //}
    //public IList<Brand> GetList()
    //{
    //    IList<Brand> entities = _entities.Where(e => e.DeletedAt.HasValue == false).ToList();
    //    return entities;
    //}
    //public void Update(Brand entity)
    //{
    //    entity.UpdateAt = DateTime.UtcNow;
    //}

    //public IList<Brand> GetBrandsByNameSearch(string nameSearch)
    //{
    //    throw new NotImplementedException();
    //}
}
