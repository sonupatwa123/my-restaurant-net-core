using MyRestaurant.Data.Interfaces;
using MyRestaurant.Services.Interfaces;
using System;

namespace MyRestaurant.Business.Service
{
    public class PaymentService : IPaymentService
    {
        private IUnitOfWork _unitOfWork;
        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
