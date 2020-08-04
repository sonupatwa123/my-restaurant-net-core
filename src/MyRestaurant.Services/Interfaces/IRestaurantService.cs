using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System;
using System.Collections.Generic;

namespace MyRestaurant.Services.Interfaces
{
   public interface IRestaurantService:IDisposable
    {
        ResponseModel<PageResultModel<RestaurantDto>> List(PageConfiguration configuration);
        ResponseModel<RestaurantDto> Save(RestaurantDto dto);
        ResponseModel<RestaurantDto> Get(long id);
        ResponseModel<RestaurantDto> Delete(long id);
        ResponseModel<RestaurantDto> DeleteAll( IEnumerable<long> ids);
        ResponseModel<IEnumerable<DropDownModel>> AllRestaurant(string userId);

        ResponseModel<List<DeliveryFeesDto>> SaveDeliveryFees(List<DeliveryFeesDto> dtoList,long restaurantId);

        ResponseModel<IEnumerable<RestaurantDto>> TopRatedRestaurants();

        ResponseModel<IEnumerable<RestaurantDto>> TopSellingRestaurants();
        ResponseModel<RestaurantDto> RestaurantInfoUI(string restaurantCode);
    }
}
