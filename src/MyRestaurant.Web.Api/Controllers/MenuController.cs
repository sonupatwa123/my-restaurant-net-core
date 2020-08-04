using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using MyRestaurant.Services.Interfaces;
using MyRestaurant.Web.Api.Helpers;

namespace MyRestaurant.Web.Api.Controllers
{
    [Route("api/menu")]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private IMenuService _service;
        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("List")]
        public async Task<IActionResult> GetMenus(PageConfiguration configuration)
        {
            var response = _service.List(configuration);

            return Ok(response);
        }

        [Route("Save")]
        public async Task<IActionResult> Save(MenuDto dto)
        {
            var response = _service.Save(dto);

            return Ok();
        }

        [Route("SaveItem")]
        public async Task<IActionResult> SaveMenuItem(MenuItemDto dto)
        {
            var response = _service.SaveMenuItem(dto);

            return Ok(response);

        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteMenu([FromRoute]long id)
        {
            var response = _service.Delete(id);

            return Ok(response);
        }

        [HttpPost]
        [Route("DeleteMenus")]
        public async Task<IActionResult> DeleteMenus(IEnumerable<long> ids)
        {
            var response = _service.DeleteMenus(ids);

            return Ok(response);
        }

        [HttpGet]
        [Route("DeliveryTypes")]
        public async Task<IActionResult> GetDeliveryTypes()
        {
            var response = _service.GetDeliveryTypes();

            return Ok(response);
        }

        [HttpGet]
        [Route("MenuCategory")]
        public async Task<IActionResult> GetMenuCategory()
        {
            var response = _service.GetMenuCategories();

            return Ok(response);
        }

        [HttpGet]
        [Route("menuitemdropdown/{restaurantId}")]
        public async Task<IActionResult> MenuItemByRestaurant(long restaurantId)
        {
            var result = _service.GetMenuItemsByRestaurantId(restaurantId);
            result = MessageHelper<IEnumerable<DropDownModel>>.GetResponse(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("cuisinedropdown")]
        public async Task<IActionResult> CuisineDropDown()
        {
            var result = _service.GetCuisinesDropDown();
            result = MessageHelper<IEnumerable<DropDownModel>>.GetResponse(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("topmenuitems")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTopMenuItems()
        {
            var result = _service.GetTopItems();
            result = MessageHelper<IEnumerable<MenuItemDto>>.GetResponse(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("moreitemfromrestaurant/{restaurantid}")]
        [AllowAnonymous]
        public async Task<IActionResult> MoreItemOfRestaurant([FromRoute]long restaurantid)
        {
            var result = _service.GetTopItems(restaurantid);
            result = MessageHelper<IEnumerable<MenuItemDto>>.GetResponse(result);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("restaurantmenu/{restaurantid}")]
        public async Task<IActionResult> RestaurantMenu([FromRoute]long restaurantid)
        {
            ResponseModel<List<MenuDto>> result = _service.GetRestaurantMenus(restaurantid);
            result = MessageHelper<List<MenuDto>>.GetResponse(result);

            return Ok(result);

        }
    }
}
