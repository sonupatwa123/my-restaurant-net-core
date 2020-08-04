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
    [Route("api/offer")]
    public class OfferController : ControllerBase
    {
        private IOfferService _service;

        public OfferController(IOfferService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Offers")]
        public async Task<IActionResult> GetOffers(PageConfiguration configuration)
        {
            var result = _service.GetOffers(configuration);
            result = MessageHelper<PageResultModel<OfferDto>>.GetResponse(result);
           
            return Ok(result);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(OfferDto dto)
        {
            var result = new ResponseModel<OfferDto>();
            if (!ModelState.IsValid)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InvalidModel;
            }
            else
            {
                result = _service.Save(dto);
            }
            result = MessageHelper<OfferDto>.GetResponse(result);

            return Ok(result);
        }  

        [HttpDelete]
        [Route("Delete/{offerId}")]
        public async Task<IActionResult> Delete([FromRoute]long offerId)
        {
            var result = _service.Delete(offerId);
            result = MessageHelper<OfferDto>.GetResponse(result);

            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteAll")]
        public async Task<IActionResult> DeleteAll(IEnumerable<long> ids)
        {
            var result = _service.DeleteAll(ids);
            result = MessageHelper<OfferDto>.GetResponse(result);

            return Ok(result); 
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetOffer([FromRoute]long id)
        {
            var result = _service.Get(id);
            result = MessageHelper<OfferDto>.GetResponse(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("restaurant/{restaurantid}/offers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRestaurantOffersUI([FromRoute]long restaurantid) {
            var result=_service.GetRestaurantOffersUI(restaurantid);
            result = MessageHelper<List<OfferDto>>.GetResponse(result);

            return Ok(result);
        }
    }
}
