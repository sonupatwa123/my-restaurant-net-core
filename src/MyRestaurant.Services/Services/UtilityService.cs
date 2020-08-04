using System;
using System.Collections.Generic;
using MyRestaurant.Data.Interfaces;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using MyRestaurant.Models.Constants;
using MyRestaurant.Models.Helpers;
using MyRestaurant.Services.Interfaces;

namespace MyRestaurant.Business.Service
{
    public class UtilityService : IUtilityService
    {
        private IUnitOfWork _unitOfWork;
        public UtilityService(IUnitOfWork unitofwork)
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = unitofwork;
            }
        }

        public void Dispose()
        {
            _unitOfWork = null;
        }

        public ResponseModel<IEnumerable<CityDto>> GetCities(long stateId)
        {

            ResponseModel<IEnumerable<CityDto>> response = new ResponseModel<IEnumerable<CityDto>>();
            try
            {
                string[] exclude = new string[] { "CreatedDate","UpdatedDate","CreatedById","UpdatedById","IsDeleted"};
                var cities = _unitOfWork.Repository<City>().GetAll(m => !m.IsDeleted&&m.StateId==stateId);
                List<CityDto> responseObject = new List<CityDto>();
                foreach (var city in cities)
                {
                    responseObject.Add(Mapper<City, CityDto>.Map(city, new CityDto(), exclude));
                }
                response.IsSuccess = true;
                response.ResponseObject = responseObject;
            }
            catch(Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public ResponseModel<IEnumerable<CountryDto>> GetCountries()
        {
            ResponseModel<IEnumerable<CountryDto>> response = new ResponseModel<IEnumerable<CountryDto>>();
            try
            {
                string[] exclude = new string[] { "CreatedDate","UpdatedDate","CreatedById","UpdatedById","IsDeleted"};
                var countries = _unitOfWork.Repository<Country>().GetAll(m => !m.IsDeleted);
                List<CountryDto> responseObject = new List<CountryDto>();
                foreach (var country in countries)
                {
                    responseObject.Add(Mapper<Country, CountryDto>.Map(country, new CountryDto(), exclude));
                }
                response.IsSuccess = true;
                response.ResponseObject = responseObject;
            }
            catch(Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public ResponseModel<IEnumerable<StateDto>> GetStates(long countryId)
        {
            ResponseModel<IEnumerable<StateDto>> response = new ResponseModel<IEnumerable<StateDto>>();
            try
            {
                string[] exclude = new string[] { "CreatedDate","UpdatedDate","CreatedById","UpdatedById","IsDeleted"};
                var states = _unitOfWork.Repository<State>().GetAll(m => !m.IsDeleted&&m.CountryId==countryId);
                List<StateDto> responseObject = new List<StateDto>();
                foreach (var state in states)
                {
                    responseObject.Add(Mapper<State, StateDto>.Map(state, new StateDto(), exclude));
                }
                response.IsSuccess = true;
                response.ResponseObject = responseObject;
            }
            catch(Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public ResponseModel<CityDto> SaveCity(CityDto dto)
        {
            ResponseModel<CityDto> response = new ResponseModel<CityDto>();
            try
            {
                var city = Mapper<CityDto, City>.Map(dto, new City());
                _unitOfWork.Repository<City>().Insert(city);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.SuccessCode = CommonConstants.SuccessCode.CitySaved;
                dto.Id = city.Id;
                response.ResponseObject = dto;
            }
            catch(Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }
    }
}
