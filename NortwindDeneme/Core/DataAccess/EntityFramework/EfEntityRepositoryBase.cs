using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext,new()
    {

        public void add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntites = context.Entry(entity);
                addedEntites.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntites = context.Entry(entity);
                deletedEntites.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntites = context.Entry(entity);
                updateEntites.State = EntityState.Modified;
                context.SaveChanges();
            }
        }


    }
}
