using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyRestaurant.Data.Interfaces;
using MyRestaurant.Model.Entities;

namespace MyRestaurant.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        MyRestaurantContext _context;
        private Hashtable _repositories;
        public UnitOfWork(DbContextOptions dbContextOptions)
        {
            _context = new MyRestaurantContext(dbContextOptions);
        }
        
        public void Dispose()
        {
            _context = null;
        }

        public IMyRestaurantRepository<T> Repository<T>() where T : BaseModel
        {
            if (_repositories == null)
                _repositories = new Hashtable();
            var type = typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(MyRestaurantRepository<>);
                var repositoryInstance =
                    Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IMyRestaurantRepository<T>)_repositories[type];
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
        public void Save()
        {

            _context.SaveChanges();
        }
    }
}
