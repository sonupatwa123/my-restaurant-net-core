using MyRestaurant.Data.Interfaces;
using MyRestaurant.Services.Interfaces;
using System;

namespace MyRestaurant.Business.Service
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
