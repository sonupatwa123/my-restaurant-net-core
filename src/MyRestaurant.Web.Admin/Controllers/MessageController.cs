using Microsoft.AspNetCore.Mvc;

namespace MyRestaurant.Web.Admin.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Save(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ViewBag.Id = id;
            }
            return View();
        }
    }
}