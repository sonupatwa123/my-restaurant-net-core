using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System.Collections.Generic;

namespace MyRestaurant.Services.Interfaces
{
   public interface IOfferService
    {
        ResponseModel<PageResultModel<OfferDto>> GetOffers(PageConfiguration configuration);
        ResponseModel<OfferDto> Save(OfferDto dto);
        ResponseModel<OfferDto> Delete(long id);
        ResponseModel<OfferDto> DeleteAll(IEnumerable<long> ids);

        ResponseModel<OfferDto> Get(long id);

        ResponseModel<List<OfferDto>> GetRestaurantOffersUI(long restaurantId);
    }
}
