using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using MyRestaurant.Web.Api.Helpers;

namespace MyRestaurant.Web.Api.Controllers
{
    [Route("api/message")]
    public class MessageController : ControllerBase
    {
        [Route("messages")]
        [HttpPost]
        public async Task<IActionResult> GetMessages(PageConfiguration configuration)
        {
            ResponseModel<PageResultModel<Message>> response = new ResponseModel<PageResultModel<Message>>();
            response = MessageHelper<Message>.GetMessages(configuration);

            return Ok(response);
        }

        [Route("Message/Save")]
        [HttpPost]
        public async Task<IActionResult> SaveMessage(Message obj)
        {
            ResponseModel<Message> response = new ResponseModel<Message>();
            response = MessageHelper<Message>.SaveMessage(obj);
            response = MessageHelper<Message>.GetResponse(response);

            return Ok(response);

        }

        [Route("message/Get/{code}")]
        [HttpGet]
        public async Task<IActionResult> GetMesage(string code)
        {
            ResponseModel<Message> response = MessageHelper<Message>.GetMessage(code);
            response= MessageHelper<Message>.GetResponse(response);

            return Ok(response);            
        }
    }
}
