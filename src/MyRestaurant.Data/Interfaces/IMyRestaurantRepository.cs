using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;

namespace MyRestaurant.Data.Interfaces
{
    public interface IMyRestaurantRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(long entity);
        T Get(Func<T, bool> expression);
        DbSet<T> Table();
        bool Any(Func<T, bool> prediction);
        PageResultModel<T> GetMultiple(PageConfiguration configuration, Func<T, bool> predicate);
        PageResultModel<T> GetMultiple(PageConfiguration configuration, Func<T, bool> predicate, string[] include);
        void InsertMultiple(IEnumerable<T> collection);
        void DeleteMultiple(IEnumerable<long> ids);
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        T Get(Func<T, bool> expression, string[] include);
        T Get<TChild>(Func<T, bool> expression, Expression<Func<T, IEnumerable<TChild>>> filter, string[] include) where TChild : class;
        IEnumerable<T> GetMultiple(Func<T, bool> predicate, string[] include);
        int Count(Func<T, bool> predicate);
    }
}
