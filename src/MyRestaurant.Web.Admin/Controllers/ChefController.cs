using Microsoft.AspNetCore.Mvc;

namespace MyRestaurant.Web.Admin.Controllers
{
    public class ChefController : Controller
    {
        // GET: Chef
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Save(long? id)
        {
            if (id != null)
            {
                ViewBag.Id = id;
            }
            return View();
        }
    }
}