using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System.Collections.Generic;

namespace MyRestaurant.Services.Interfaces
{
   public interface IMenuService
    {
        ResponseModel<MenuDto> Save(MenuDto dto);
        ResponseModel<PageResultModel<MenuDto>> List(PageConfiguration configuration);
        ResponseModel<MenuDto> Delete(long id);
        ResponseModel<MenuItemDto> DeleteItem(long id);
        ResponseModel<MenuItemDto> SaveMenuItem(MenuItemDto item);
        ResponseModel<IEnumerable<MenuItemDto>> SaveMenuItems(IEnumerable<MenuItemDto> items);

        ResponseModel<IEnumerable<MenuDto>> DeleteMenus(IEnumerable<long> ids);
        ResponseModel<IEnumerable<DeliveryTypeDto>> GetDeliveryTypes();
        ResponseModel<IEnumerable<MenuCategoryDto>> GetMenuCategories();
        ResponseModel<IEnumerable<DropDownModel>> GetMenuItemsByRestaurantId(long restaurantId);

        ResponseModel<IEnumerable<MenuItemDto>> GetTopItems();
        ResponseModel<IEnumerable<DropDownModel>> GetCuisinesDropDown();
        ResponseModel<IEnumerable<MenuItemDto>> GetTopItems(long restaurantid);
        ResponseModel<List<MenuDto>> GetRestaurantMenus(long restaurantid);
    }
}
