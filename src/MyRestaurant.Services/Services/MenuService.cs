using System;
using System.Collections.Generic;
using System.Linq;
using MyRestaurant.Model.Models;
using MyRestaurant.Data.Interfaces;
using MyRestaurant.Services.Interfaces;
using MyRestaurant.Model.Entities;
using MyRestaurant.Models.Constants;
using MyRestaurant.Models.Helpers;
using Microsoft.Extensions.Configuration;

namespace MyRestaurant.Business.Service
{
    public class MenuService : IMenuService
    {
        IUnitOfWork _unitOfWork;
        IConfiguration _configuration;
        public MenuService(IUnitOfWork unitofwork, IConfiguration configuration)
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = unitofwork;
            }
            _configuration = configuration;
        }
        public ResponseModel<MenuDto> Delete(long id)
        {
            ResponseModel<MenuDto> response = new ResponseModel<MenuDto>();
            try
            {
                _unitOfWork.Repository<Menu>().Delete(id);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.SuccessCode = CommonConstants.SuccessCode.MenuDeleted;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public ResponseModel<MenuItemDto> DeleteItem(long id)
        {

            ResponseModel<MenuItemDto> response = new ResponseModel<MenuItemDto>();
            try
            {
                _unitOfWork.Repository<MenuItemDto>().Delete(id);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.SuccessCode = CommonConstants.SuccessCode.MenuItemDeleted;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public ResponseModel<IEnumerable<MenuDto>> DeleteMenus(IEnumerable<long> ids)
        {
            ResponseModel<IEnumerable<MenuDto>> response = new ResponseModel<IEnumerable<MenuDto>>();
            try
            {
                _unitOfWork.Repository<Menu>().DeleteMultiple(ids);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.SuccessCode = CommonConstants.SuccessCode.MenuDeleted;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public ResponseModel<IEnumerable<DeliveryTypeDto>> GetDeliveryTypes()
        {
            ResponseModel<IEnumerable<DeliveryTypeDto>> response = new ResponseModel<IEnumerable<DeliveryTypeDto>>();

            try
            {
                var records = _unitOfWork.Repository<DeliveryType>().GetAll(m => !m.IsDeleted);
                List<DeliveryTypeDto> deliveryTypes = new List<DeliveryTypeDto>();
                string[] ignore = new string[] { "CreatedDate", "UpdatedDate", "IsDeleted", "Orders", "MenuItems" };

                foreach (var record in records)
                {
                    deliveryTypes.Add(Mapper<DeliveryType, DeliveryTypeDto>.Map(record, new DeliveryTypeDto(), ignore));
                }
                response.IsSuccess = true;
                response.ResponseObject = deliveryTypes;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public ResponseModel<PageResultModel<MenuDto>> List(PageConfiguration configuration)
        {

            ResponseModel<PageResultModel<MenuDto>> response = new ResponseModel<PageResultModel<MenuDto>>();
            PageResultModel<MenuDto> menuRecords = new PageResultModel<MenuDto>();
            menuRecords.Records = new List<MenuDto>();
            try
            {
                response.IsSuccess = true;
                Func<Menu, bool> expression = m => !m.IsDeleted;
                if (!string.IsNullOrEmpty(configuration.Search))
                {
                    expression = m => !m.IsDeleted && (m.MenuName.Contains(configuration.Search) || m.MenuDescription.Contains(configuration.Search));
                }
                var records = _unitOfWork.Repository<Menu>().GetMultiple(configuration, expression);
                foreach (var item in records.Records)
                {
                    MenuDto dto = new MenuDto();
                    dto = Mapper<Menu, MenuDto>.Map(item, dto);
                    menuRecords.Records.Add(dto);
                }
                menuRecords.TotalPages = records.TotalPages;
                menuRecords.TotalRecords = records.TotalRecords;
                menuRecords.PageNumber = records.PageNumber;
                menuRecords.Showing = records.Showing;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }

            return response;
        }
        public ResponseModel<MenuDto> Save(MenuDto dto)
        {
            ResponseModel<MenuDto> response = new ResponseModel<MenuDto>();
            try
            {
                var entity = Mapper<MenuDto, Menu>.Map(dto, new Menu());
                if (entity.Id == 0)
                {
                    _unitOfWork.Repository<Menu>().Insert(entity);
                    if (dto.MenuItems != null && dto.MenuItems.Count() > 0)
                    {

                    }
                    _unitOfWork.Save();
                    response.SuccessCode = CommonConstants.SuccessCode.MenuSaved;


                }
                else
                {
                    _unitOfWork.Repository<Menu>().Update(entity);
                    _unitOfWork.Save();
                    response.SuccessCode = CommonConstants.SuccessCode.MenuUpdated;
                }
                dto.Id = entity.Id;
                response.ResponseObject = dto;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public ResponseModel<MenuItemDto> SaveMenuItem(MenuItemDto item)
        {
            ResponseModel<MenuItemDto> response = new ResponseModel<MenuItemDto>();

            try
            {
                var entity = Mapper<MenuItemDto, MenuItem>.Map(item, new MenuItem());
                if (entity.Id > 0)
                {
                    _unitOfWork.Repository<MenuItem>().Insert(entity);
                }
                else
                {
                    _unitOfWork.Repository<MenuItem>().Insert(entity);
                }
                _unitOfWork.Save();
                item.Id = entity.Id;
                response.IsSuccess = true;
                response.SuccessCode = CommonConstants.SuccessCode.MenuItemSaved;
                response.ResponseObject = item;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;

            }
            return response;
        }

        public ResponseModel<IEnumerable<MenuItemDto>> SaveMenuItems(IEnumerable<MenuItemDto> items)
        {
            ResponseModel<IEnumerable<MenuItemDto>> response = new ResponseModel<IEnumerable<MenuItemDto>>();
            try
            {
                List<MenuItem> menuToInsert = new List<MenuItem>();
                List<MenuItem> menuToUpdate = new List<MenuItem>();
                foreach (var item in items)
                {
                    MenuItem menuitem = new MenuItem();
                    menuitem = Mapper<MenuItemDto, MenuItem>.Map(item, menuitem);
                    if (item.Id > 0)
                    {
                        menuToUpdate.Add(menuitem);
                    }
                    else
                    {
                        menuToInsert.Add(menuitem);
                    }
                }
                _unitOfWork.Repository<MenuItem>().InsertMultiple(menuToInsert);
                foreach (var item in menuToUpdate)
                {
                    _unitOfWork.Repository<MenuItem>().Update(item);
                }
                response.IsSuccess = true;
                response.SuccessCode = CommonConstants.SuccessCode.MenuItemUpdated;


            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;

            }

            return response;
        }

        public ResponseModel<IEnumerable<MenuCategoryDto>> GetMenuCategories()
        {
            ResponseModel<IEnumerable<MenuCategoryDto>> response = new ResponseModel<IEnumerable<MenuCategoryDto>>();

            try
            {
                var records = _unitOfWork.Repository<MenuCategory>().GetAll(m => !m.IsDeleted);
                List<MenuCategoryDto> menuCatgories = new List<MenuCategoryDto>();
                string[] ignore = new string[] { "CreatedDate", "UpdatedDate", "IsDeleted", "Menus" };

                foreach (var record in records)
                {
                    menuCatgories.Add(Mapper<MenuCategory, MenuCategoryDto>.Map(record, new MenuCategoryDto(), ignore));
                }
                response.IsSuccess = true;
                response.ResponseObject = menuCatgories;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public ResponseModel<IEnumerable<DropDownModel>> GetMenuItemsByRestaurantId(long restaurantId)
        {
            ResponseModel<IEnumerable<DropDownModel>> result = new ResponseModel<IEnumerable<DropDownModel>>();

            try
            {
                string[] include = new string[] { "Menu" };
                var entity = _unitOfWork.Repository<MenuItem>().GetMultiple(m => !m.IsDeleted && m.Menu.RestaurantId == restaurantId, include);
                result.ResponseObject = entity.Select(m => new DropDownModel
                {
                    Name = m.ItemName,
                    Id = m.Id
                }).AsEnumerable();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }

        public ResponseModel<IEnumerable<MenuItemDto>> GetTopItems()
        {
            ResponseModel<IEnumerable<MenuItemDto>> result = new ResponseModel<IEnumerable<MenuItemDto>>();
            try
            {
                int topItemCount = 10;
                int.TryParse(_configuration.GetSection("MyReataurantConfiguration:TopItemCount").Value, out topItemCount);
                PageConfiguration configuration = new PageConfiguration
                {
                    PageNumber = 1,
                    PageSize = topItemCount

                };
                var menuItemRatings = _unitOfWork.Repository<Rating>()
                    .GetAll(m => (m.MenuItemId != null || m.RestaurantId != null) && m.Rate > 3 && m.Rate < 5).Select(m => new
                    {
                        RestaurantId = m.RestaurantId,
                        MenuItemId = m.MenuItemId
                    }).GroupBy(m => m.RestaurantId).Select(m => m.FirstOrDefault()).Distinct().ToList();

                List<long?> restaurantList = menuItemRatings.Select(m => m.RestaurantId).ToList();
                List<long?> menuItemList = menuItemRatings.Select(m => m.MenuItemId).ToList();


                Func<MenuItem, bool> conditions = m => !m.IsDeleted;

                if (menuItemList.Count > 0 && restaurantList.Any())
                {
                    conditions = m => !m.IsDeleted && (menuItemList.Contains(m.Id) || restaurantList.Contains(m.Menu.RestaurantId));
                }
                if (menuItemList.Any() && !restaurantList.Any())
                {
                    conditions = m => !m.IsDeleted && (menuItemList.Contains(m.Id));
                }
                if (restaurantList.Any() && !menuItemList.Any())
                {
                    conditions = m => !m.IsDeleted && (restaurantList.Contains(m.Menu.RestaurantId));
                }

                result.ResponseObject = GetItems(conditions, configuration);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsFailed = true;
            }
            return result;
        }
        public ResponseModel<IEnumerable<DropDownModel>> GetCuisinesDropDown()
        {
            ResponseModel<IEnumerable<DropDownModel>> result = new ResponseModel<IEnumerable<DropDownModel>>();
            try
            {
                var entity = _unitOfWork.Repository<Cuisine>().GetAll(m => !m.IsDeleted);
                result.ResponseObject = entity.Select(m => new DropDownModel
                {
                    Id = m.Id,
                    Name = m.Name
                });
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }
        public ResponseModel<IEnumerable<MenuItemDto>> GetTopItems(long restaurantid)
        {
            ResponseModel<IEnumerable<MenuItemDto>> result = new ResponseModel<IEnumerable<MenuItemDto>>();
            try
            {
                int topItemCount = 10;
                int.TryParse(_configuration.GetSection("MyReataurantConfiguration:TopItemCount").Value, out topItemCount);
                PageConfiguration configuration = new PageConfiguration
                {
                    PageNumber = 1,
                    PageSize = topItemCount

                };
                var menuItemRatings = _unitOfWork.Repository<Rating>()
                    .GetAll(m => (m.MenuItemId != null || m.RestaurantId != null) && m.Rate > 3 && m.Rate < 5 && m.RestaurantId == restaurantid).Select(m => new
                    {
                        RestaurantId = m.RestaurantId,
                        MenuItemId = m.MenuItemId
                    }).GroupBy(m => m.RestaurantId).Select(m => m.FirstOrDefault()).Distinct().ToList();

                List<long?> restaurantList = menuItemRatings.Select(m => m.RestaurantId).ToList();
                List<long?> menuItemList = menuItemRatings.Select(m => m.MenuItemId).ToList();


                Func<MenuItem, bool> conditions = m => !m.IsDeleted && m.Menu.RestaurantId == restaurantid;

                if (menuItemList.Count > 0 && restaurantList.Any())
                {
                    conditions = m => !m.IsDeleted && (menuItemList.Contains(m.Id) || restaurantList.Contains(m.Menu.RestaurantId)) && m.Menu.RestaurantId == restaurantid;
                }
                if (menuItemList.Any() && !restaurantList.Any())
                {
                    conditions = m => !m.IsDeleted && (menuItemList.Contains(m.Id)) && m.Menu.RestaurantId == restaurantid;
                }
                if (restaurantList.Any() && !menuItemList.Any())
                {
                    conditions = m => !m.IsDeleted && (restaurantList.Contains(m.Menu.RestaurantId)) && m.Menu.RestaurantId == restaurantid;
                }
                result.ResponseObject = GetItems(conditions, configuration);

                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsFailed = true;
            }
            return result;
        }
        private IEnumerable<MenuItemDto> GetItems(Func<MenuItem, bool> expression, PageConfiguration configuration)
        {
            string[] include = new string[] { "Menu.MenuCategory", "Ratings" };
            IEnumerable<MenuItemDto> result = null;
            var entity = _unitOfWork.Repository<MenuItem>().GetMultiple(configuration, expression, include);
            if (entity.Records.Count > 0)
            {
                result = entity.Records.Select(m => new MenuItemDto
                {
                    ItemName = m.ItemName,
                    ItemDetails = m.ItemDetails,
                    Logo = m.Logo,
                    Id = m.Id,
                    Rating = m.Ratings.Count > 0 ? m.Ratings.Average(n => n.Rate) : 0,
                    ItemPerUnitPrice = m.ItemPerUnitPrice,
                    Menu = new MenuDto
                    {
                        MenuCategoryId = m.Menu.MenuCategoryId,
                        MenuCategory = new MenuCategory
                        {
                            Name = m.Menu.MenuCategory.Name,
                            Id = m.Menu.MenuCategory.Id
                        },
                        RestaurantId = m.Menu.RestaurantId,
                        MenuLogo = m.Menu.MenuLogo,
                        MenuName = m.Menu.MenuName
                    }
                });
            }
            return result;
        }

        public ResponseModel<List<MenuDto>> GetRestaurantMenus(long restaurantid)
        {
            ResponseModel<List<MenuDto>> response = new ResponseModel<List<MenuDto>>();
            try
            {
                string[] include = new string[] { "MenuItems", "Cuisine", "MenuCategory" };
                string[] excludeMapping = new string[] { "Restaurant", "MenuItems", "MenuCategory","Cuisine","Menus","Menu" };
                int pageSize = 10;
                int.TryParse(_configuration.GetSection("MyReataurantConfiguration:TopItemCount").Value, out pageSize);
                PageConfiguration configuration = new PageConfiguration()
                {
                    PageNumber = 1,
                    PageSize = pageSize
                };
                var entity = _unitOfWork.Repository<Menu>().GetMultiple(configuration, m => m.RestaurantId == restaurantid && !m.IsDeleted, include).Records;
                List<MenuDto> dtoList = new List<MenuDto>();
                foreach (var menu in entity)
                {

                    var dto = Mapper<Menu, MenuDto>.Map(menu, new MenuDto(), excludeMapping);
                    dto.MenuCategory = Mapper<MenuCategory, MenuCategoryDto>.Map(menu.MenuCategory, new MenuCategoryDto(),excludeMapping);
                    dto.MenuItems = new List<MenuItemDto>();
                    dto.Cuisine = menu.Cuisine;
                    dto.Cuisine.Menus = null;
                    foreach (var item in menu.MenuItems)
                    {
                        var itemDto = Mapper<MenuItem, MenuItemDto>.Map(item, new MenuItemDto(),excludeMapping);
                        dto.MenuItems.Add(itemDto);
                    }
                    dtoList.Add(dto);
                }
                response.ResponseObject = dtoList;
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }
    }
}
