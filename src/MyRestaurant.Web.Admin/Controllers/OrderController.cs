using Microsoft.AspNetCore.Mvc;

namespace MyRestaurant.Web.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public IActionResult Index()
        {
            return View();
        }
    }
}