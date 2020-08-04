using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyRestaurant.Data.Interfaces;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;

namespace MyRestaurant.Data
{
    public class MyRestaurantRepository<T> : IMyRestaurantRepository<T> where T : BaseModel
    {
        private DbSet<T> table;
        private MyRestaurantContext _context;

        public MyRestaurantRepository(MyRestaurantContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public void Delete(long id)
        {
            var entity = table.AsNoTracking().FirstOrDefault(m => m.Id == id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                entity.IsDeleted = true;
            }
        }


        public T Get(Func<T, bool> expression)
        {
            return table.AsNoTracking().FirstOrDefault(expression);
        }
        public T Get(Func<T, bool> expression, string[] include)
        {
            IQueryable<T> query = table.AsNoTracking().AsQueryable();
            foreach (var inc in include)
            {
                query = query.Include(inc);
            }

            return query.AsNoTracking().FirstOrDefault(expression);
        }
        public T Get<TChild>(Func<T, bool> expression, Expression<Func<T, IEnumerable<TChild>>> filter, string[] include) where TChild : class
        {
            IQueryable<T> query = table.AsNoTracking().AsQueryable();
            foreach (var inc in include)
            {
                query = query.Include(inc);
            }
            //query = query.IncludeFilter<T, TChild>(filter);            

            return query.AsNoTracking().FirstOrDefault(expression);
        }
        public void Insert(T entity)
        {

            table.Add(entity);

        }
        public void InsertMultiple(IEnumerable<T> collection)
        {
            table.AddRange(collection);
        }

        public DbSet<T> Table()
        {
            return table;
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public bool Any(Func<T, bool> prediction)
        {
            return table.AsNoTracking().Any(prediction);
        }
        public PageResultModel<T> GetMultiple(PageConfiguration configuration, Func<T, bool> predicate)
        {
            var entity = table.AsNoTracking().Where(predicate);
            PageResultModel<T> result = new PageResultModel<T>();
            result.TotalRecords = entity.Count();
            result.PageNumber = configuration.PageNumber;
            result.TotalPages = (int)Math.Ceiling((double)entity.Count() / configuration.PageSize);
            result.Records = entity.Skip((configuration.PageNumber - 1) * configuration.PageSize).Take(configuration.PageSize).ToList();
            result.Showing = result.Records.Count();
            return result;

        }
        public PageResultModel<T> GetMultiple(PageConfiguration configuration, Func<T, bool> predicate, string[] include)
        {
            IQueryable<T> query = table.AsNoTracking().AsQueryable();
            foreach (var inc in include)
            {
                query = query.Include(inc);
            }
            var entity = query.Where(predicate);
            PageResultModel<T> result = new PageResultModel<T>();
            result.TotalRecords = entity.Count();
            result.PageNumber = configuration.PageNumber;
            result.TotalPages = (int)Math.Ceiling((double)entity.Count() / configuration.PageSize);
            result.Records = entity.Skip((configuration.PageNumber - 1) * configuration.PageSize).Take(configuration.PageSize).ToList();
            result.Showing = result.Records.Count();
            return result;

        }
        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return table.AsNoTracking().Where(predicate);
        }

        public void DeleteMultiple(IEnumerable<long> ids)
        {
            table.AsNoTracking().Where(m => ids.Contains(m.Id)).ForEachAsync(m =>
            {
                _context.Entry(m).State = EntityState.Modified;
                m.IsDeleted = true;
            });

        }
        public IEnumerable<T> GetMultiple(Func<T, bool> predicate, string[] include)
        {
            IQueryable<T> query = table.AsNoTracking().AsQueryable();
            foreach (var inc in include)
            {
                query = query.Include(inc);
            }

            return query.AsNoTracking().Where(predicate).AsEnumerable();
        }
        public int Count(Func<T, bool> predicate)
        {
            return table.Where(predicate).Count();
        }
    }
}
