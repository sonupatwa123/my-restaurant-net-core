using System;
using System.Collections.Generic;
using System.Linq;
using MyRestaurant.Data.Interfaces;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using MyRestaurant.Models.Constants;
using MyRestaurant.Models.Helpers;
using MyRestaurant.Services.Interfaces;

namespace MyRestaurant.Business.Service
{
    public class ChefService : IChefService
    {
        private IUnitOfWork _unitOfWork;
        public ChefService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseModel<RestaurantChefDto> Delete(long id)
        {
            ResponseModel<RestaurantChefDto> result = new ResponseModel<RestaurantChefDto>();
            try
            {
                _unitOfWork.Repository<RestaurantChef>().Delete(id);
                _unitOfWork.Save();
                result.IsSuccess = true;
                result.SuccessCode = CommonConstants.SuccessCode.ChefDeleted;
            }
            catch (Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }

        public ResponseModel<RestaurantChefDto> DeleteAll(IEnumerable<long> ids)
        {
            ResponseModel<RestaurantChefDto> result = new ResponseModel<RestaurantChefDto>();
            try
            {
                _unitOfWork.Repository<RestaurantChef>().DeleteMultiple(ids);
                _unitOfWork.Save();
                result.IsSuccess = true;
                result.SuccessCode = CommonConstants.SuccessCode.AllOfferDeleted;
            }
            catch (Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }

        public ResponseModel<RestaurantChefDto> Get(long id)
        {
            ResponseModel<RestaurantChefDto> result = new ResponseModel<RestaurantChefDto>();
            try
            {
                string[] include = new string[] { "Restaurant", "ChefCuisines.Cuisine" };
                var entity = _unitOfWork.Repository<RestaurantChef>().Get(m => m.Id == id && !m.IsDeleted, include);
                if (entity != null)
                {
                    string[] offerIgnore = new string[] { "CreatedDate", "UpdatedDate", "CreatedById", "UpdatedById", "ChefCuisines" };
                    var dto = Mapper<RestaurantChef, RestaurantChefDto>.Map(entity, new RestaurantChefDto(), offerIgnore);
                    if (entity.ChefCuisines != null && entity.ChefCuisines.Count > 0)
                    {
                        dto.ChefCuisines = entity.ChefCuisines.Where(m => !m.IsDeleted).Select(m => new ChefCuisineDto
                        {
                            Cuisine=m.Cuisine,
                            CuisineId = m.CuisineId,
                            Id=m.Id,
                            RestaurantChefId = m.RestaurantChefId
                        }).ToList();
                    }
                    result.IsSuccess = true;
                    result.ResponseObject = dto;
                }
                else
                {
                    result.IsFailed = true;
                    result.ErrorCode = CommonConstants.ErrorCode.InvalidId;
                }

            }
            catch (Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }

        public ResponseModel<PageResultModel<RestaurantChefDto>> GetChefs(PageConfiguration configuration)
        {
            ResponseModel<PageResultModel<RestaurantChefDto>> result = new ResponseModel<PageResultModel<RestaurantChefDto>>();
            PageResultModel<RestaurantChefDto> chefs = new PageResultModel<RestaurantChefDto>();

            try
            {
                Func<RestaurantChef, bool> expression = m => (configuration.ShowDeleted ? (m.IsDeleted || !m.IsDeleted) : !m.IsDeleted);
                string[] include = new string[] { "Restaurant" };
                string[] excludeMapping = new string[] { "RestaurantChefs", "ChefCuisines" };
                if (!string.IsNullOrEmpty(configuration.Search))
                {
                    DateTime searchDate = new DateTime();
                    DateTime.TryParse(configuration.Search, out searchDate);
                    if (searchDate != new DateTime())
                    {
                        expression = m => (configuration.ShowDeleted ? (m.IsDeleted || !m.IsDeleted) : !m.IsDeleted)
                             && ((m.FirstName + " " + m.LastName).Contains(configuration.Search));
                    }
                    else
                    {
                        expression = m => (configuration.ShowDeleted ? (m.IsDeleted || !m.IsDeleted) : !m.IsDeleted)
                        && ((m.FirstName + " " + m.LastName).Contains(configuration.Search) || m.Restaurant.RestaurantName.Contains(configuration.Search));
                    }
                }
                var records = _unitOfWork.Repository<RestaurantChef>().GetMultiple(configuration, expression, include);
                foreach (var item in records.Records)
                {
                    RestaurantChefDto dto = new RestaurantChefDto();
                    dto = Mapper<RestaurantChef, RestaurantChefDto>.Map(item, dto, excludeMapping);
                    chefs.Records.Add(dto);
                }
                chefs.TotalPages = records.TotalPages;
                chefs.TotalRecords = records.TotalRecords;
                chefs.PageNumber = records.PageNumber;
                chefs.Showing = records.Showing;
                result.IsSuccess = true;
                result.ResponseObject = chefs;
            }
            catch (Exception ex)
            {

                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }

        public ResponseModel<List<RestaurantChefDto>> GetRestaurantChefUI(long restaurantId)
        {
            ResponseModel<List<RestaurantChefDto>> result = new ResponseModel<List<RestaurantChefDto>>();
            PageConfiguration configuration = new PageConfiguration()
            {
                PageNumber = 1,
                PageSize = 4
            };
            string[] include = new string[] { "ChefCuisines.Cuisine" };
            string[] excludeMapping = new string[] { "RestaurantChef","ChefCuisines" };
            try
            {
                var entity = _unitOfWork.Repository<RestaurantChef>().GetMultiple(configuration, m => m.RestaurantId == restaurantId
                   && !m.IsDeleted&&(m.ChefRating>=3&&m.ChefRating<=5),include).Records;
                List<RestaurantChefDto> records = new List<RestaurantChefDto>();
                foreach (var chef in entity)
                {
                    var dto = Mapper<RestaurantChef, RestaurantChefDto>.Map(chef, new RestaurantChefDto(),excludeMapping);
                    dto.ChefCuisines = chef.ChefCuisines.Where(m => !m.IsDeleted).Select(m => new ChefCuisineDto {
                        Id = m.Id,
                        Cuisine = m.Cuisine,
                        RestaurantChefId = m.RestaurantChefId
                    }).ToList();                    
                    records.Add(dto);
                }
                result.ResponseObject = records;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }

        public ResponseModel<RestaurantChefDto> Save(RestaurantChefDto dto)
        {
            ResponseModel<RestaurantChefDto> result = new ResponseModel<RestaurantChefDto>();
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    RestaurantChef entity = new RestaurantChef();
                    string[] exclude = new string[] { "MenuItems", "OfferItems", "CreatedDate", "UpdatedDate", "CreatedById", "UpdatedById", "ChefCuisines" };
                    Mapper<RestaurantChefDto, RestaurantChef>.Map(dto, entity, exclude);

                    if (dto.Id > 0)
                    {
                        entity = _unitOfWork.Repository<RestaurantChef>().Get(m => m.Id == dto.Id);
                        Mapper<RestaurantChefDto, RestaurantChef>.Map(dto, entity, exclude);
                        _unitOfWork.Repository<RestaurantChef>().Update(entity);

                        result.SuccessCode = CommonConstants.SuccessCode.ChefUpdated;

                    }
                    else
                    {
                        _unitOfWork.Repository<RestaurantChef>().Insert(entity);
                        result.SuccessCode = CommonConstants.SuccessCode.ChefSaved;
                    }
                    _unitOfWork.Save();
                    dto.Id = entity.Id;
                    if (dto.ChefCuisines != null && dto.ChefCuisines.Count > 0)
                    {
                        List<ChefCuisine> offerItems = new List<ChefCuisine>();
                        foreach (var item in dto.ChefCuisines)
                        {
                            item.RestaurantChefId = dto.Id;
                        }
                        SaveChefCuisines(dto.ChefCuisines);
                    }

                    result.IsSuccess = true;
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    result.IsFailed = true;
                    result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
                }
            }
            return result;
        }
        private void SaveChefCuisines(IEnumerable<ChefCuisineDto> cuisines)
        {
            List<ChefCuisine> itemToSave = new List<ChefCuisine>();
            List<ChefCuisine> itemToUpdate = new List<ChefCuisine>();
            foreach (var item in cuisines)
            {
                var offerItem = Mapper<ChefCuisineDto, ChefCuisine>.Map(item, new ChefCuisine());

                if (offerItem.Id > 0)
                {
                    offerItem = _unitOfWork.Repository<ChefCuisine>().Get(m => m.Id == item.Id);
                    offerItem.IsDeleted = item.IsDeleted;
                    _unitOfWork.Repository<ChefCuisine>().Update(offerItem);
                }
                else
                {
                    itemToSave.Add(offerItem);
                }
            }
            _unitOfWork.Repository<ChefCuisine>().InsertMultiple(itemToSave);
            _unitOfWork.Save();
        }
    }
}
