using MyRestaurant.Data.Interfaces;
using MyRestaurant.Services.Interfaces;
using System;

namespace MyRestaurant.Business.Service
{
    public class ContactService : IContactService
    {
        IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
