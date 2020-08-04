
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MyRestaurant.Data.Interfaces;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using MyRestaurant.Models.Constants;
using MyRestaurant.Models.Helpers;
using MyRestaurant.Services.Interfaces;

namespace MyRestaurant.Business.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public RestaurantService(IUnitOfWork unitofwork, IConfiguration configuration)
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = unitofwork;
            }
            _configuration = configuration;
        }

        public ResponseModel<RestaurantDto> Delete(long id)
        {
            ResponseModel<RestaurantDto> response = new ResponseModel<RestaurantDto>();
            try
            {
                _unitOfWork.Repository<Restaurant>().Delete(id);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.SuccessCode = CommonConstants.SuccessCode.RestaurantDelete;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public ResponseModel<RestaurantDto> DeleteAll(IEnumerable<long> ids)
        {
            ResponseModel<RestaurantDto> response = new ResponseModel<RestaurantDto>();
            try
            {
                _unitOfWork.Repository<Restaurant>().DeleteMultiple(ids);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.SuccessCode = CommonConstants.SuccessCode.RestaurantDelete;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return response;
        }

        public void Dispose()
        {

        }

        public ResponseModel<RestaurantDto> Get(long id)
        {
            ResponseModel<RestaurantDto> response = new ResponseModel<RestaurantDto>();
            try
            {
                RestaurantDto dto = new RestaurantDto();

                dto = GetRestauarantMethod2(dto, id);

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

        public ResponseModel<PageResultModel<RestaurantDto>> List(PageConfiguration configuration)
        {
            ResponseModel<PageResultModel<RestaurantDto>> response = new ResponseModel<PageResultModel<RestaurantDto>>();
            PageResultModel<RestaurantDto> menuRecords = new PageResultModel<RestaurantDto>();

            menuRecords.Records = new List<RestaurantDto>();
            try
            {

                Func<Restaurant, bool> expression = m => m.AspNetUserId == configuration.UserId && (configuration.ShowDeleted ? (m.IsDeleted || !m.IsDeleted) : !m.IsDeleted);
                if (!string.IsNullOrEmpty(configuration.Search))
                {
                    expression = m => (configuration.ShowDeleted ? (m.IsDeleted || !m.IsDeleted) : !m.IsDeleted) && (m.RestaurantName.ToLower().Contains(configuration.Search.ToLower())
                    && m.AspNetUserId == configuration.UserId);
                }
                var records = _unitOfWork.Repository<Restaurant>().GetMultiple(configuration, expression);
                foreach (var item in records.Records)
                {
                    RestaurantDto dto = new RestaurantDto();
                    dto = Mapper<Restaurant, RestaurantDto>.Map(item, dto);
                    menuRecords.Records.Add(dto);
                }
                menuRecords.TotalPages = records.TotalPages;
                menuRecords.TotalRecords = records.TotalRecords;
                menuRecords.PageNumber = records.PageNumber;
                menuRecords.Showing = records.Showing;
                response.IsSuccess = true;
                response.ResponseObject = menuRecords;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }

            return response;
        }

        public ResponseModel<RestaurantDto> Save(RestaurantDto dto)
        {
            ResponseModel<RestaurantDto> response = new ResponseModel<RestaurantDto>();
            using (var tran = _unitOfWork.BeginTransaction())
            {
                try
                {
                    if (dto.Id == 0)
                    {
                        var restaurantCode = RandomValue.RandomString(5);
                        bool codeExists = true;
                        while (codeExists)
                        {
                            if (_unitOfWork.Repository<Restaurant>().Any(r => r.RestaurantCode == restaurantCode))
                            {
                                restaurantCode = RandomValue.RandomString(5);
                            }
                            else
                            {
                                codeExists = false;
                                dto.RestaurantCode = restaurantCode;
                            }
                        }
                    }
                    string[] restIgnore = new string[] { "Menus", "CreatedDate", "UpdatedDate", "DeliveryAreas", "DeliveryFees", "RestaurantGalleries" };
                    string[] restPart = new string[] { "Address" };

                    var entity = Mapper<RestaurantDto, Restaurant>.Map(dto, new Restaurant(), restIgnore);
                    if (dto.Id == 0)
                    {

                        var address = Mapper<AddressDto, Address>.Map(dto.Address, new Address());
                        _unitOfWork.Repository<Address>().Insert(address);
                        _unitOfWork.Save();
                        entity.AddressId = address.Id;
                        _unitOfWork.Repository<Restaurant>().Insert(entity);
                        _unitOfWork.Save();
                        response.SuccessCode = CommonConstants.SuccessCode.RestaurantSaved;
                    }
                    else
                    {
                        entity = _unitOfWork.Repository<Restaurant>().Get(m => m.Id == dto.Id, restPart);
                        Mapper<AddressDto, Address>.Map(dto.Address, entity.Address);
                        _unitOfWork.Repository<Address>().Update(entity.Address);

                        Mapper<RestaurantDto, Restaurant>.Map(dto, entity, restIgnore);
                        _unitOfWork.Repository<Restaurant>().Update(entity);

                        _unitOfWork.Save();

                        response.SuccessCode = CommonConstants.SuccessCode.RestaurantUpdated;

                    }

                    dto.Id = entity.Id;
                    SaveMenu(dto.Menus, dto.Id);

                    response.ResponseObject = dto;
                    response.IsSuccess = true;
                    if (dto.DeliveryAreas != null)
                    {
                        SaveDeliveryArea(dto.DeliveryAreas, dto.Id);
                    }
                    if (dto.DeliveryFees != null && dto.DeliveryFees.Count > 0)
                    {
                        var deliveryFees = SaveDeliveryFees(dto.DeliveryFees, dto.Id);
                    }
                    if (dto.RestaurantGalleries != null && dto.RestaurantGalleries.Count > 0)
                    {
                        SaveGallery(dto.RestaurantGalleries, dto);
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    response.IsFailed = true;
                    response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
                }
            }
            return response;
        }
        private void SaveMenu(IEnumerable<MenuDto> menusDto, long restaurantId)
        {
            List<Menu> menusToAdd = new List<Menu>();
            List<MenuItem> menuItemsToAdd = new List<MenuItem>();
            List<Menu> menuToEdit = new List<Menu>();
            List<MenuItem> menuItemToEdit = new List<MenuItem>();
            string[] ignoreMenu = new string[] { "MenuItems" };
            string[] ignoreMenuItem = new string[] { "Menu" };
            var otherCatgories = menusDto.Select(m => m.OtherCategory).Distinct();
            if (otherCatgories != null && otherCatgories.Count() > 0)
            {
                List<MenuCategory> categoriesToSave = new List<MenuCategory>();
                foreach (var category in otherCatgories)
                {
                    categoriesToSave.Add(new MenuCategory
                    {
                        IsGlobal = false,
                        Name = category
                    });
                }

            }

            foreach (var menu in menusDto.Where(m => m.Id == 0))
            {
                var menuObj = Mapper<MenuDto, Menu>.Map(menu, new Menu(), ignoreMenu);
                menuObj.RestaurantId = restaurantId;
                menusToAdd.Add(menuObj);
                if (menu.MenuItems != null && menu.MenuItems.Count() > 0)
                {
                    foreach (var item in menu.MenuItems.Where(m => m.Id == 0))
                    {
                        menuItemsToAdd.Add(Mapper<MenuItemDto, MenuItem>.Map(item, new MenuItem(), ignoreMenuItem));
                    }
                }
            }
            foreach (var menu in menusDto.Where(m => m.Id > 0))
            {
                menuToEdit.Add(Mapper<MenuDto, Menu>.Map(menu, new Menu(), ignoreMenu));
                if (menu.MenuItems != null && menu.MenuItems.Count() > 0)
                {
                    foreach (var item in menu.MenuItems.Where(m => m.Id > 0))
                    {
                        menuItemToEdit.Add(Mapper<MenuItemDto, MenuItem>.Map(item, new MenuItem(), ignoreMenuItem));
                    }
                }
            }
            _unitOfWork.Repository<Menu>().InsertMultiple(menusToAdd);
            foreach (var menu in menuToEdit)
            {
                _unitOfWork.Repository<Menu>().Update(menu);
            }
            foreach (var menuItem in menuItemToEdit)
            {
                _unitOfWork.Repository<MenuItem>().Update(menuItem);
            }
            _unitOfWork.Save();
            SaveMenuItems(menuItemsToAdd, menusToAdd);
        }
        private void SaveMenuItems(List<MenuItem> menuItems, List<Menu> menus)
        {
            foreach (var item in menuItems)
            {
                var menu = menus.FirstOrDefault(m => m.Guid == item.MenuGuid);
                if (menu != null)
                {
                    item.MenuId = menu.Id;
                }
            }
            _unitOfWork.Repository<MenuItem>().InsertMultiple(menuItems);
            _unitOfWork.Save();
        }

        private void SaveOtherCategories(List<MenuCategory> categories)
        {
            foreach (var category in categories)
            {
                if (!_unitOfWork.Repository<MenuCategory>().Any(m => m.Name.ToLower() == category.Name.ToLower()))
                {
                    _unitOfWork.Repository<MenuCategory>().Insert(category);
                }
            }
            _unitOfWork.Save();
        }
        private void SaveDeliveryArea(IEnumerable<DeliveryAreaDto> areas, long restauranId)
        {
            List<DeliveryArea> areaToSave = new List<DeliveryArea>();
            List<DeliveryArea> areaToUpdate = new List<DeliveryArea>();
            foreach (var area in areas.Where(m => m.Id == 0).ToList())
            {
                var deliveryArea = Mapper<DeliveryAreaDto, DeliveryArea>.Map(area, new DeliveryArea());
                deliveryArea.RestaurantId = restauranId;
                areaToSave.Add(deliveryArea);
            }
            foreach (var area in areas.Where(m => m.Id > 0))
            {
                var deliveryArea = Mapper<DeliveryAreaDto, DeliveryArea>.Map(area, new DeliveryArea());
                _unitOfWork.Repository<DeliveryArea>().Update(deliveryArea);
            }
            _unitOfWork.Repository<DeliveryArea>().InsertMultiple(areaToSave);
            _unitOfWork.Save();

        }

        private void SaveGallery(List<GalleryDto> galleries, RestaurantDto restaurant)
        {
            var galleryList = new List<Gallery>();
            foreach (var gallery in galleries)
            {
                var galleryModel = Mapper<GalleryDto, Gallery>.Map(gallery, new Gallery());
                galleryList.Add(galleryModel);
            }
            _unitOfWork.Repository<Gallery>().InsertMultiple(galleryList);
            _unitOfWork.Save();
            List<RestaurantGallery> restaurantGallery = new List<RestaurantGallery>();

            foreach (var gallery in galleryList)
            {
                restaurantGallery.Add(new RestaurantGallery
                {
                    GalleryId = gallery.Id,
                    RestaurantId = restaurant.Id
                });
            }
            _unitOfWork.Repository<RestaurantGallery>().InsertMultiple(restaurantGallery);
            _unitOfWork.Save();

        }

        private RestaurantDto GetRestauarantMethod1(RestaurantDto dto, long id)
        {
            string[] exclude = new string[] {
                    "UpdatedById",
                    "CreatedById",
                    "IsDeleted",
                    "AspNetUserId",
                    "Addresses",
                    "Menus",
                    "MenuItems",
                    "Menu",
                    "Restaurant"
                };

            var query = (from rest in _unitOfWork.Repository<Restaurant>().Table()
                         join add in _unitOfWork.Repository<Address>().Table() on rest.AddressId equals add.Id

                         join menu in _unitOfWork.Repository<Menu>().Table() on rest.Id equals menu.RestaurantId
                         join item in _unitOfWork.Repository<MenuItem>().Table() on menu.Id equals item.MenuId
                         where rest.Id == id
                         && !menu.IsDeleted
                         && !item.IsDeleted
                         select new
                         {
                             restaurant = rest,
                             menus = menu,
                             items = item,
                             address = add
                         }
                       );
            dto = Mapper<Restaurant, RestaurantDto>.Map(query.FirstOrDefault().restaurant, new RestaurantDto(), exclude);
            dto.Address = Mapper<Address, AddressDto>.Map(query.FirstOrDefault().address, new AddressDto(), exclude);
            var menus = query.Select(m => m.menus).Distinct().ToList();

            foreach (var menu in menus)
            {
                var menuDto = Mapper<Menu, MenuDto>.Map(menu, new MenuDto(), exclude);

                var menuItems = query.Select(m => m.items).Distinct().Where(m => m.MenuId == menu.Id).ToList();
                foreach (var item in menuItems)
                {
                    var itemDto = Mapper<MenuItem, MenuItemDto>.Map(item, new MenuItemDto(), exclude);
                    menuDto.MenuItems.Add(itemDto);
                }
                dto.Menus.Add(menuDto);
            }
            return dto;
        }
        private RestaurantDto GetRestauarantMethod2(RestaurantDto dto, long id)
        {
            string[] exclude = new string[] {
                    "UpdatedById",
                    "CreatedById",
                    "IsDeleted",
                    "AspNetUserId",
                    "Addresses",
                    "Menus",
                    "MenuItems",
                    "Menu",
                    "City",
                    "State",
                    "Country",
                    "Restaurant",
                    "Address",
                    "DeliveryAreas",
                    "DeliveryFees"
                };
            var restaurantParts = new string[]
               {
                    "Address",
                    "Menus.MenuItems",
                    "DeliveryAreas",
                    "DeliveryFees"
               };


            var data = _unitOfWork
                    .Repository<Restaurant>()
                    .Get(r => r.Id == id && !r.IsDeleted &&

                    r.Menus.Any(m => !m.IsDeleted), restaurantParts);
            Mapper<Restaurant, RestaurantDto>.Map(data, dto, exclude);
            dto.Address = Mapper<Address, AddressDto>.Map(data.Address, new AddressDto(), exclude);

            if (data.Menus != null && data.Menus.Count > 0)
            {
                foreach (var menuData in data.Menus.Where(m => !m.IsDeleted))
                {
                    var menu = Mapper<Menu, MenuDto>.Map(menuData, new MenuDto(), exclude);
                    if (menuData.MenuItems.Count > 0)
                    {
                        foreach (var menuitem in menuData.MenuItems.Where(m => !m.IsDeleted))
                        {
                            var item = Mapper<MenuItem, MenuItemDto>.Map(menuitem, new MenuItemDto(), exclude);
                            menu.MenuItems.Add(item);
                        }
                    }
                    dto.Menus.Add(menu);
                }
            }
            if (data.DeliveryAreas != null && data.DeliveryAreas.Count > 0)
            {
                foreach (var area in data.DeliveryAreas.Where(m => !m.IsDeleted))
                {
                    var deliveryAreaDto = Mapper<DeliveryArea, DeliveryAreaDto>.Map(area, new DeliveryAreaDto());
                    dto.DeliveryAreas.Add(deliveryAreaDto);
                }
            }
            if (data.DeliveryFees != null && data.DeliveryFees.Count > 0)
            {
                foreach (var fees in data.DeliveryFees)
                {
                    dto.DeliveryFees.Add(new DeliveryFeesDto
                    {
                        Id = fees.Id,
                        DistanceFrom = fees.DistanceFrom,
                        DistanceTo = fees.DistanceTo,
                        Fees = fees.Fees,
                        RestaurantId = fees.RestaurantId
                    });
                }
            }

            return dto;
        }
        public ResponseModel<IEnumerable<DropDownModel>> AllRestaurant(string userId)
        {
            ResponseModel<IEnumerable<DropDownModel>> result = new ResponseModel<IEnumerable<DropDownModel>>();
            try
            {
                var entity = _unitOfWork.Repository<Restaurant>().GetMultiple(m => !m.IsDeleted && m.AspNetUserId == userId, new string[0]);
                result.ResponseObject = entity.Select(m => new DropDownModel
                {
                    Id = m.Id,
                    Name = m.RestaurantName
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

        public ResponseModel<List<DeliveryFeesDto>> SaveDeliveryFees(List<DeliveryFeesDto> dtoList, long restaurantId)
        {
            ResponseModel<List<DeliveryFeesDto>> response = new ResponseModel<List<DeliveryFeesDto>>();
            List<DeliveryFees> itemToSave = new List<DeliveryFees>();
            foreach (var dto in dtoList)
            {
                dto.RestaurantId = restaurantId;
                if (dto.Id == 0)
                {
                    itemToSave.Add(new DeliveryFees
                    {
                        RestaurantId = dto.RestaurantId,
                        DistanceFrom = dto.DistanceFrom,
                        DistanceTo = dto.DistanceTo,
                        Fees = dto.Fees
                    });
                }
                else
                {
                    var existing = _unitOfWork.Repository<DeliveryFees>().Get(m => !m.IsDeleted && m.Id == dto.Id);
                    Mapper<DeliveryFeesDto, DeliveryFees>.Map(dto, existing, new string[] { "CreatedDate", "UpdatedDate", "CreatedById", "UpdatedById" });

                }
            }
            _unitOfWork.Repository<DeliveryFees>().InsertMultiple(itemToSave);
            _unitOfWork.Save();
            return response;

        }

        public ResponseModel<IEnumerable<RestaurantDto>> TopRatedRestaurants()
        {
            ResponseModel<IEnumerable<RestaurantDto>> result = new ResponseModel<IEnumerable<RestaurantDto>>();
            try
            {
                int itemCount = 10;
                int.TryParse(_configuration.GetSection("MyReataurantConfiguration:TopItemCount").Value, out itemCount);
                PageConfiguration configuration = new PageConfiguration
                {
                    PageNumber = 1,
                    PageSize = itemCount

                };
                var restaurantRatings = _unitOfWork.Repository<Rating>()
                    .GetAll(m => m.RestaurantId != null && m.Rate > 3 && m.Rate < 5)
                    .OrderBy(m => m.Rate).Select(m => m.RestaurantId).ToList();
                Func<Restaurant, bool> expression = m => !m.IsDeleted;

                IEnumerable<RestaurantDto> restaurants;
                if (_unitOfWork.Repository<Restaurant>().Any(m => restaurantRatings.Contains(m.Id)))
                {
                    expression = m => !m.IsDeleted && restaurantRatings.Contains(m.Id);
                }
                restaurants = _unitOfWork.Repository<Restaurant>()
                        .GetMultiple(configuration, expression)
                        .Records.Select(m => new RestaurantDto
                        {
                            Id = m.Id,
                            Logo = m.Logo,
                            RestaurantCode = m.RestaurantCode,
                            RestaurantName = m.RestaurantName

                        }).ToList();
                result.IsSuccess = true;
                result.ResponseObject = restaurants;
            }
            catch (Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }
        public ResponseModel<IEnumerable<RestaurantDto>> TopSellingRestaurants()
        {
            ResponseModel<IEnumerable<RestaurantDto>> result = new ResponseModel<IEnumerable<RestaurantDto>>();
            try
            {
                int itemCount = 10;
                int.TryParse(_configuration.GetSection("MyReataurantConfiguration:TopItemCount").Value, out itemCount);

                var query = (from rest in _unitOfWork.Repository<Restaurant>().Table()
                             join ord in _unitOfWork.Repository<Order>().Table() on rest.Id equals ord.RestaurantId into orders
                             select new
                             {
                                 Restaurant = rest,
                                 OrderCount = orders.Count()
                             }).GroupBy(m => m.Restaurant)
                             .Select(m => m.FirstOrDefault())
                             .OrderBy(m => m.OrderCount).Skip(0).Take(itemCount);
                IEnumerable<RestaurantDto> restaurants = query.Select(m => new RestaurantDto
                {
                    Id = m.Restaurant.Id,
                    Logo = m.Restaurant.Logo,
                    RestaurantCode = m.Restaurant.RestaurantCode,
                    RestaurantName = m.Restaurant.RestaurantName
                }).ToList();
                result.ResponseObject = restaurants;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsFailed = true;
                result.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            }
            return result;
        }

        public ResponseModel<RestaurantDto> RestaurantInfoUI(string restaurantCode)
        {
            ResponseModel<RestaurantDto> response = new ResponseModel<RestaurantDto>();
            try
            {

                string[] include = new string[] { };
                string[] excludeMapping = new string[] { "Address", "Menus", "Ratings", "DeliveryAreas", "Feedbacks", "Offers", "DeliveryFees", "Reservations", "RestaurantTimings" };
                var entity = _unitOfWork.Repository<Restaurant>().Get(m => m.RestaurantCode == restaurantCode && !m.IsDeleted);
                if (entity != null)
                {
                    var dto = Mapper<Restaurant, RestaurantDto>.Map(entity, new RestaurantDto());
                    response.ResponseObject = dto;
                    response.IsSuccess = true;
                }
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
