using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;

namespace MyRestaurant.Services.Interfaces
{
    public interface IChefService
    {
        ResponseModel<PageResultModel<RestaurantChefDto>> GetChefs(PageConfiguration configuration);
        ResponseModel<RestaurantChefDto> Save(RestaurantChefDto dto);
        ResponseModel<RestaurantChefDto> Delete(long id);
        ResponseModel<RestaurantChefDto> DeleteAll(IEnumerable<long> ids);
        ResponseModel<RestaurantChefDto> Get(long id);
        ResponseModel<List<RestaurantChefDto>> GetRestaurantChefUI(long restaurantId);
    }
}
