using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using MyRestaurant.Model.Entities;

namespace MyRestaurant.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        IMyRestaurantRepository<T> Repository<T>() where T : BaseModel;
        IDbContextTransaction BeginTransaction();
    }
}
