using System;
using MyRestaurant.Data.Interfaces;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using MyRestaurant.Models.Constants;
using MyRestaurant.Models.Helpers;
using MyRestaurant.Services.Interfaces;

namespace MyRestaurant.Business.Service
{
    public class NavigationService : INavigationService
    {
        IUnitOfWork _unitOfWork;
        public NavigationService(IUnitOfWork unitofwork)
        {

            if (_unitOfWork == null)
            {
                _unitOfWork = unitofwork;
            }
        }

        public ResponseModel<PageDto> DeleteNavigation(long id)
        {
            ResponseModel<PageDto> result = new ResponseModel<PageDto>();
            try
            {
                _unitOfWork.Repository<Page>().Delete(id);
                _unitOfWork.Save();
                result.IsSuccess = true;
                result.SuccessCode = CommonConstants.SuccessCode.NavigationDeleted;
            }
            catch(Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }

        public void Dispose()
        {
            _unitOfWork = null;
        }

        public ResponseModel<PageDto> GetNavigation(long id)
        {
            ResponseModel<PageDto> result = new ResponseModel<PageDto>();
            try
            {
                string[] ignore = new string[] { "UpdatedDate", "CreatedDate" };
                var data = _unitOfWork.Repository<Page>().Get(m => m.Id == id);
                result.ResponseObject = Mapper<Page, PageDto>.Map(data, new PageDto(),ignore);
                result.IsSuccess = true; 
            }
            catch(Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }

        public ResponseModel<PageResultModel<PageDto>> Navigations(PageConfiguration configuration)
        {
            ResponseModel<PageResultModel<PageDto>> response = new ResponseModel<PageResultModel<PageDto>>();
            PageResultModel<PageDto> navigationRecords = new PageResultModel<PageDto>();
            try
            {
                response.IsSuccess = true;
                Func<Page, bool> expression = m =>(configuration.ShowDeleted ? (m.IsDeleted || !m.IsDeleted) : !m.IsDeleted);
                if (!string.IsNullOrEmpty(configuration.Search))
                {
                    expression = m => (configuration.ShowDeleted ? (m.IsDeleted || !m.IsDeleted) : !m.IsDeleted) &&
                    (m.Name.ToLower().Contains(configuration.Search.ToLower())||
                    m.Url.ToLower().Contains(configuration.Search.ToLower())||
                    m.ControllerName.ToLower().Contains(configuration.Search.ToLower())||
                    m.ActionName.ToLower().Contains(configuration.Search.ToLower())
                    );
                }
                var records = _unitOfWork.Repository<Page>().GetMultiple(configuration, expression);
                foreach (var item in records.Records)
                {
                    PageDto dto = new PageDto();
                    dto = Mapper<Page, PageDto>.Map(item, dto);
                    navigationRecords.Records.Add(dto);
                }
                navigationRecords.TotalPages = records.TotalPages;
                navigationRecords.TotalRecords = records.TotalRecords;
                navigationRecords.PageNumber = records.PageNumber;
                navigationRecords.Showing = records.Showing;
                response.ResponseObject = navigationRecords;
            }
            catch(Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public ResponseModel<PageDto> SaveNavigation(PageDto dto)
        {
            ResponseModel<PageDto> response = new ResponseModel<PageDto>();

            try
            {
                Page entity = Mapper<PageDto, Page>.Map(dto, new Page());

                if (entity.Id == 0)
                {
                    _unitOfWork.Repository<Page>().Insert(entity);
                    response.SuccessCode = CommonConstants.SuccessCode.NavigationSaved;
                }
                else
                {
                    entity = _unitOfWork.Repository<Page>().Get(m => m.Id == dto.Id);
                    Mapper<PageDto, Page>.Map(dto, entity);
                    _unitOfWork.Repository<Page>().Update(entity);
                    response.SuccessCode = CommonConstants.SuccessCode.NavigationUpdated;
                }
                _unitOfWork.Save();

                dto.Id = entity.Id;
                response.ResponseObject = dto;
                response.IsSuccess = true;
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
