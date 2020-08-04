using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System;

namespace MyRestaurant.Services.Interfaces
{
   public interface IUserService:IDisposable
    {
        ResponseModel<UserDto> SaveUser(UserDto dto);
        ResponseModel<UserDto> GetUser(string Id);
        ResponseModel<UserDto> GetUserByUserId(string Id);

    }
}
