using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        public void add(Category entity)
        {
            using (var context = new NorthwindContext())
            {
                var addedEntites = context.Entry(entity);
                addedEntites.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void delete(Category entity)
        {
            using (var context = new NorthwindContext())
            {
                var deletedEntites = context.Entry(entity);
                deletedEntites.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            using (var context = new NorthwindContext())
            {
                return context.Set<Category>().SingleOrDefault(filter);

            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            using (var context = new NorthwindContext())
            {
                return filter == null ? context.Set<Category>().ToList() : context.Set<Category>().Where(filter).ToList();

            }
        }

        public void update(Category entity)
        {
            using (var context = new NorthwindContext())
            {
                var updateEntites = context.Entry(entity);
                updateEntites.State = EntityState.Modified;
                context.SaveChanges();

            }

        }
    }
}

