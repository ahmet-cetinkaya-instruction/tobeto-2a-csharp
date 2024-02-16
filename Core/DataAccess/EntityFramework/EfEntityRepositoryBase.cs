using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    // T => Type
    public class EfEntityRepositoryBase<TEntity, TEntityId, TContext> : IEntityRepository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TContext : DbContext
    {
        private readonly TContext Context;

        public EfEntityRepositoryBase(TContext context)
        {
            this.Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity, bool isSoftDelete = true)
        {
            entity.DeletedAt = DateTime.UtcNow;
            // Context.Entry(entity).State = EntityState.Modified;

            if (!isSoftDelete)
                Context.Remove(entity);

            Context.SaveChanges();
            return entity;
        }

        public TEntity? Get(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IList<TEntity> GetList(Func<TEntity, bool>? predicate = null)
        {
            IQueryable<TEntity> entities = Context.Set<TEntity>();
            if (predicate is not null)
                entities = entities.Where(predicate).AsQueryable();

            return entities.ToList();
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdateAt = DateTime.UtcNow;
            Context.Update(entity);
            Context.SaveChanges();
            return entity;
        }
    }
}
