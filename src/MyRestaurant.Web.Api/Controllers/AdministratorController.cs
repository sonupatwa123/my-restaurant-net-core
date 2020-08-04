using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using MyRestaurant.Services.Interfaces;
using MyRestaurant.Web.Api.Helpers;

namespace MyRestaurant.Web.Api.Controllers
{
    /// <summary>
    /// controller to handle all admin activity
    /// </summary>
    [Route("api/Admin")]
    public class AdministratorController : ControllerBase
    {
        private INavigationService _service;
        public AdministratorController(INavigationService Service)
        {
            _service = Service;
        }

        #region Messages
        [Route("messages")]
        [HttpPost]
        public async Task<IActionResult> GetMessages(PageConfiguration configuration)
        {
            ResponseModel<PageResultModel<Message>> response = new ResponseModel<PageResultModel<Message>>();
            response = MessageHelper<Message>.GetMessages(configuration);

            return Ok(response);
        }

        [Route("message/Save")]
        [HttpPost]
        public async Task<IActionResult> SaveMessage(Message obj)
        {
            ResponseModel<Message> response = new ResponseModel<Message>();
            response = MessageHelper<Message>.SaveMessage(obj);
            response = MessageHelper<Message>.GetResponse(response);

            return Ok(response);

        }

        [Route("Get/{code}")]
        [HttpGet]
        public async Task<IActionResult> GetMesage(string code)
        {
            ResponseModel<Message> response = MessageHelper<Message>.GetMessage(code);
            response = MessageHelper<Message>.GetResponse(response);

            return Ok(response);
        }
        #endregion Messages

        #region Navigation
        [HttpPost]
        [Route("Navigation/Navigations")]
        public async Task<IActionResult> GetNavigations(PageConfiguration configuration)
        {
            var result = _service.Navigations(configuration);

            return Ok(result);
        }

        [HttpPost]
        [Route("Navigation/Save")]
        public async Task<IActionResult> SaveNavigation(PageDto dto)
        {
            var result = _service.SaveNavigation(dto);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Navigation/Delete/{id}")]
        public async Task<IActionResult> DeleteNavigation(long id)
        {
            var result = _service.DeleteNavigation(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("Navigation/Get/{id}")]
        public async Task<IActionResult> GetNavigation(long id)
        {
            var result = _service.GetNavigation(id);

            return Ok(result);
        }
        
        #endregion Navigation
    }

}
