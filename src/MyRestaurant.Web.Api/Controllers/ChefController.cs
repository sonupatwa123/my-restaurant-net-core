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
    [Route("api/chef")]
    public class ChefController : ControllerBase
    {
        private IChefService _service;
        public ChefController(IChefService Service)
        {
            _service = Service;
        }

        [HttpPost]
        [Route("chefs")]
        public async Task<IActionResult> GetOffers(PageConfiguration configuration)
        {
            var result = _service.GetChefs(configuration);
            result = MessageHelper<PageResultModel<RestaurantChefDto>>.GetResponse(result);

            return Ok(result);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(RestaurantChefDto dto)
        {
            var result = new ResponseModel<RestaurantChefDto>();
            if (!ModelState.IsValid)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InvalidModel;
            }
            else
            {
                result = _service.Save(dto);
            }
            result = MessageHelper<RestaurantChefDto>.GetResponse(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{chefId}")]
        public async Task<IActionResult> Delete([FromRoute]long chefId)
        {
            var result = _service.Delete(chefId);
            result = MessageHelper<RestaurantChefDto>.GetResponse(result);

            return Ok(result);
        }
        [HttpPost]
        [Route("DeleteAll")]
        public async Task<IActionResult> DeleteAll(IEnumerable<long> ids)
        {
            var result = _service.DeleteAll(ids);
            result = MessageHelper<RestaurantChefDto>.GetResponse(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetOffer([FromRoute]long id)
        {
            var result = _service.Get(id);
            result = MessageHelper<RestaurantChefDto>.GetResponse(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("restaurant/{restaurantid}/chefs")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRestaurantOffersUI([FromRoute]long restaurantid)
        {
            var result = _service.GetRestaurantChefUI(restaurantid);
            result = MessageHelper<List<RestaurantChefDto>>.GetResponse(result);

            return Ok(result);
        }
    }
}
