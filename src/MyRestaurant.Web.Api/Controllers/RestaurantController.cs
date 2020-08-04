using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using MyRestaurant.Models.Constants;
using MyRestaurant.Services.Interfaces;
using MyRestaurant.Web.Api.Helpers;

namespace MyRestaurant.Web.Api.Controllers
{
    [Route("api/restaurant")]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantService _service;
        private IUtilityService _utilityService;
        public RestaurantController(IRestaurantService service,IUtilityService utility) {
            _service = service;
            _utilityService = utility;

        }    
        
        [Route("List")]
        [HttpPost]
        public async Task<IActionResult> List(PageConfiguration configuration)
        {
            configuration.UserId = User.Identity.Name;
            var result = _service.List(configuration);
            result = MessageHelper<PageResultModel<RestaurantDto>>.GetResponse(result); 

            return Ok(result);
        }

        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> Save(RestaurantDto dto)
        {
            ResponseModel<RestaurantDto> result = new ResponseModel<RestaurantDto>();
            if (dto.Address.CityId == -1)
            {
                var cityResponse = _utilityService.SaveCity(new CityDto
                {
                    Name = dto.Address.CityName,
                    StateId = dto.Address.StateId
                });
                if (cityResponse.IsSuccess)
                {
                    dto.Address.CityId = cityResponse.ResponseObject.Id;
                }
            }
            if (ModelState.IsValid)
            {
                dto.AspNetUserId = User.Identity.Name;
                result = _service.Save(dto);
                result = MessageHelper<RestaurantDto>.GetResponse(result);

            }
            else
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InvalidModel;
                result = MessageHelper<RestaurantDto>.GetResponse(result);
            }
            
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = _service.Delete(id);
            response = MessageHelper<RestaurantDto>.GetResponse(response);

            return Ok(response);
        }

        [HttpPost]
        [Route("DeleteAll")]
        public async Task<IActionResult> DeleteAll(IEnumerable<long> ids)
        {
            var response = _service.DeleteAll(ids);

            return Ok(response);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = _service.Get(id);
            response= MessageHelper<RestaurantDto>.GetResponse(response);

            return Ok(response);
        }

        [HttpGet]
        [Route("Restaurantdropdown")]
        public async Task<IActionResult> AllRestaurants()
        {
            var userId = User.Identity.Name;
            var result = _service.AllRestaurant(userId);
            result = MessageHelper<IEnumerable<DropDownModel>>.GetResponse(result);

            return Ok(result);
        }

        [AllowAnonymous]
        [Route("TopRatedRestaurants")]
        [HttpGet]
        public async Task<IActionResult> TopRatedRestaurants() {
            var result = _service.TopRatedRestaurants();
            result = MessageHelper<IEnumerable<RestaurantDto>>.GetResponse(result);

            return Ok(result);
        }

        [AllowAnonymous]
        [Route("TopSellingRestaurants")]
        [HttpGet]
        public async Task<IActionResult> TopSellingRestaurants()
        {
            var result = _service.TopSellingRestaurants();
            result = MessageHelper<IEnumerable<RestaurantDto>>.GetResponse(result);

            return Ok(result);
        }

        [Route("restaurantinfo/{restaurantCode}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> RestaurantInfo([FromRoute]string restaurantCode) {
            var result = _service.RestaurantInfoUI(restaurantCode);
            result = MessageHelper<RestaurantDto>.GetResponse(result);

            return Ok(result);
        }
    }
}
