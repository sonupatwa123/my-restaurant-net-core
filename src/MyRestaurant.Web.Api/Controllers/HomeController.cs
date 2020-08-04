using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Model.Entities;

namespace MyRestaurant.Web.Api.Controllers
{
    [Route("api/Home")]
    public class HomeController : ControllerBase
    {
     
        [AllowAnonymous]
        [Route("GetMessageXml")]
        public async Task<IActionResult> GetMessageXml()
        {
            ResponseModel<Modules> response = new ResponseModel<Modules>();
            //XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_data/Messages.xml"));
            //response.ResponseObject = MessageHelper<Modules>.Deserialize<Modules>(doc.ToString());
            return Ok(response);
        }

    }
}
