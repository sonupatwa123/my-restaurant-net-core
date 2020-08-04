using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System;
using System.Collections.Generic;

namespace MyRestaurant.Services.Interfaces
{
   public interface IUtilityService:IDisposable
    {
        ResponseModel<IEnumerable<CountryDto>> GetCountries();
        ResponseModel<IEnumerable<StateDto>> GetStates(long countryId);
        ResponseModel<IEnumerable<CityDto>> GetCities(long stateId);
        ResponseModel<CityDto> SaveCity(CityDto dto);
    }
}
