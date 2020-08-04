using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;

namespace MyRestaurant.Services.Interfaces
{
  public  interface IFileService
    {
        ResponseModel<FileModel> SaveFile();
    }
}
