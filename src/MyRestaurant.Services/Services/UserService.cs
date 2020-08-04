using MyRestaurant.Data.Interfaces;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using MyRestaurant.Models.Helpers;
using MyRestaurant.Services.Interfaces;

namespace MyRestaurant.Business.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitofwork)
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = unitofwork;
            }
        }
        
        public void Dispose()
        {
           // _unitOfWork = null;
        }

        public ResponseModel<UserDto> SaveUser(UserDto dto)
        {
            ResponseModel<UserDto> response = new ResponseModel<UserDto>();
            if (!_unitOfWork.Repository<User>().Any(m => m.EmailAddress == dto.EmailAddress))
            {
                var entity = Mapper<UserDto, User>.Map(dto, new User());

                if (dto.Id > 0)
                {
                    _unitOfWork.Repository<User>().Update(entity);
                }
                else
                {
                    _unitOfWork.Repository<User>().Insert(entity);
                }
                _unitOfWork.Save();
                dto.Id = entity.Id;
                response.SuccessCode = "101";
                response.ResponseObject = dto;
            }
            else
            {
                response.ErrorCode = "101";
            }
            return response;
        }

        public ResponseModel<UserDto> GetUser(string Id)
        {
            ResponseModel<UserDto> response = new ResponseModel<UserDto>();
            var entity = _unitOfWork.Repository<User>().Get(a => a.Id == long.Parse(Id));
            response.ResponseObject = Mapper<User, UserDto>.Map(entity, new UserDto(), new string[] { "Orders", "Feedbacks", "AspNetUser", "CreatedDate", "UpdatedDate" });
            return response;
        }
        public ResponseModel<UserDto> GetUserByUserId(string Id)
        {
            ResponseModel<UserDto> response = new ResponseModel<UserDto>();
            var entity = _unitOfWork.Repository<User>().Get(a => a.UserId == Id);
            response.ResponseObject = Mapper<User, UserDto>.Map(entity, new UserDto(), new string[] { "Orders", "Feedbacks", "AspNetUser", "CreatedDate", "UpdatedDate" });
            return response;
        }
    }
}
