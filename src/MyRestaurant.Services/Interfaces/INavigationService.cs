using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System;

namespace MyRestaurant.Services.Interfaces
{
   public interface INavigationService:IDisposable
    {
        ResponseModel<PageResultModel<PageDto>> Navigations(PageConfiguration configuration);
        ResponseModel<PageDto> SaveNavigation(PageDto dto);
        ResponseModel<PageDto> DeleteNavigation(long id);
        ResponseModel<PageDto> GetNavigation(long id);
    }
}
