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
    public class OfferService : IOfferService
    {
        private IUnitOfWork _unitOfWork;
        public OfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseModel<OfferDto> Delete(long id)
        {
            ResponseModel<OfferDto> result = new ResponseModel<OfferDto>();
            try
            {
                _unitOfWork.Repository<Offer>().Delete(id);
                _unitOfWork.Save();
                result.IsSuccess = true;
                result.SuccessCode = CommonConstants.SuccessCode.OfferDeleted;
            }
            catch (Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }

        public ResponseModel<OfferDto> DeleteAll(IEnumerable<long> ids)
        {
            ResponseModel<OfferDto> result = new ResponseModel<OfferDto>();
            try
            {
                _unitOfWork.Repository<Offer>().DeleteMultiple(ids);
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

        public ResponseModel<PageResultModel<OfferDto>> GetOffers(PageConfiguration configuration)
        {
            ResponseModel<PageResultModel<OfferDto>> result = new ResponseModel<PageResultModel<OfferDto>>();
            PageResultModel<OfferDto> offers = new PageResultModel<OfferDto>();

            try
            {
                Func<Offer, bool> expression = m => (configuration.ShowDeleted ? (m.IsDeleted || !m.IsDeleted) : !m.IsDeleted);
                if (!string.IsNullOrEmpty(configuration.Search))
                {
                    DateTime searchDate = new DateTime();
                    DateTime.TryParse(configuration.Search, out searchDate);
                    if (searchDate != new DateTime())
                    {
                        expression = m => (configuration.ShowDeleted ? (m.IsDeleted || !m.IsDeleted) : !m.IsDeleted)
                             && (m.OfferStartDate == searchDate || m.OfferEndDate == searchDate);
                    }
                    else
                    {
                        expression = m => (configuration.ShowDeleted ? (m.IsDeleted || !m.IsDeleted) : !m.IsDeleted)
                        && (m.OfferName.ToLower().Contains(configuration.Search.ToLower())
                        && m.OfferDescription.ToLower().Contains(configuration.Search.ToLower()));
                    }
                }
                var records = _unitOfWork.Repository<Offer>().GetMultiple(configuration, expression);
                foreach (var item in records.Records)
                {
                    OfferDto dto = new OfferDto();
                    dto = Mapper<Offer, OfferDto>.Map(item, dto);
                    offers.Records.Add(dto);
                }
                offers.TotalPages = records.TotalPages;
                offers.TotalRecords = records.TotalRecords;
                offers.PageNumber = records.PageNumber;
                offers.Showing = records.Showing;
                result.IsSuccess = true;
                result.ResponseObject = offers;
            }
            catch (Exception ex)
            {

                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }

        public ResponseModel<OfferDto> Save(OfferDto dto)
        {
            ResponseModel<OfferDto> result = new ResponseModel<OfferDto>();
            using (var trans = _unitOfWork.BeginTransaction())
            {
                try
                {
                    Offer entity = new Offer();
                    string[] exclude = new string[] { "MenuItems","OfferItems","CreatedDate","UpdatedDate","CreatedById","UpdatedById" };
                    Mapper<OfferDto, Offer>.Map(dto, entity,exclude);

                    if (dto.Id > 0)
                    {
                        entity = _unitOfWork.Repository<Offer>().Get(m => m.Id == dto.Id);
                        Mapper<OfferDto, Offer>.Map(dto, entity, exclude);
                        _unitOfWork.Repository<Offer>().Update(entity);

                        result.SuccessCode = CommonConstants.SuccessCode.OfferUpdated;

                    }
                    else
                    {
                        _unitOfWork.Repository<Offer>().Insert(entity);
                        result.SuccessCode = CommonConstants.SuccessCode.OfferSaved;
                    }
                    _unitOfWork.Save();
                    dto.Id = entity.Id;
                    if (dto.OfferItems.Count > 0)
                    {
                        List<OfferItemDto> offerItems = new List<OfferItemDto>();
                        foreach (var item in dto.OfferItems)
                        {
                            item.OfferId = dto.Id;
                        }
                        SaveOfferItems(dto.OfferItems);
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

        public ResponseModel<OfferDto> Get(long id)
        {
            ResponseModel<OfferDto> result = new ResponseModel<OfferDto>();
            try
            {
                string[] include = new string[] { "OfferItems.MenuItem","Restaurant" };
                var entity = _unitOfWork.Repository<Offer>().Get(m => m.Id == id && !m.IsDeleted, include);
                if (entity != null)
                {
                    string[] offerIgnore = new string[] { "CreatedDate", "UpdatedDate", "CreatedById", "UpdatedById", "OfferItems","Offers" };
                    var dto = Mapper<Offer, OfferDto>.Map(entity, new OfferDto(), offerIgnore);
                    dto.Restaurant = Mapper<Restaurant, RestaurantDto>.Map(entity.Restaurant, new RestaurantDto(), offerIgnore);
                    dto.OfferItems = entity.OfferItems.Where(m=>!m.IsDeleted).Select(m => new OfferItemDto
                    {
                        Id = m.Id,
                        MenuItemId = m.MenuItemId,
                        ItemName=m.MenuItem.ItemName
                        
                    }).ToList();
                    result.IsSuccess = true;
                    result.ResponseObject = dto;
                }
                else {
                    result.IsFailed = true;
                    result.ErrorCode = CommonConstants.ErrorCode.InvalidId;
                }

            }
            catch(Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }
        private void SaveOfferItems(IEnumerable<OfferItemDto> offerItems)
        {
            List<OfferItem> itemToSave = new List<OfferItem>();
            List<OfferItem> itemToUpdate = new List<OfferItem>();            
            foreach (var item in offerItems)
            {
                var offerItem = Mapper<OfferItemDto, OfferItem>.Map(item, new OfferItem());

                if (offerItem.Id > 0)
                {
                    offerItem = _unitOfWork.Repository<OfferItem>().Get(m => m.Id == item.Id);
                    offerItem.IsDeleted = item.IsDeleted;
                    offerItem.MenuItemId = item.MenuItemId;
                    _unitOfWork.Repository<OfferItem>().Update(offerItem);
                }else
                {
                    itemToSave.Add(offerItem);
                }
            }
            _unitOfWork.Repository<OfferItem>().InsertMultiple(itemToSave);

            _unitOfWork.Save();
        }

        public ResponseModel<List<OfferDto>> GetRestaurantOffersUI(long restaurantId)
        {
            ResponseModel<List<OfferDto>> result = new ResponseModel<List<OfferDto>>();
            PageConfiguration configuration = new PageConfiguration() {
                PageNumber = 1,
                PageSize = 4
            };            
            string[] excludeMapping = new string[] { "Offers","CreatedDate","UpdatedDate","CreatedById","UpdatedById","Restaurant" };
            try
            {
                var entity = _unitOfWork.Repository<Offer>().GetMultiple(configuration, m => m.RestaurantId == restaurantId
                   && (m.OfferStartDate) <=DateTime.Now.Date
                   && (m.OfferEndDate) >= DateTime.Now.Date
                   && !m.IsDeleted).Records;
                List<OfferDto> records = new List<OfferDto>();
                foreach(var offer in entity)
                {
                    var dto = Mapper<Offer, OfferDto>.Map(offer, new OfferDto(),excludeMapping);                    
                    records.Add(dto);
                }
                result.ResponseObject = records;
                result.IsSuccess = true;
            }
            catch(Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
           
        }
    }
}
