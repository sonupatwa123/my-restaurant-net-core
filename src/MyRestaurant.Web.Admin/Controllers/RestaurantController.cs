using Microsoft.AspNetCore.Mvc;

namespace MyRestaurant.Web.Admin.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult List()
        {
            return View("Index");
        }
        public ActionResult Save(long ? id)
        {
            if (id != null)
            {
                ViewBag.Id = id;
            }
            return View("Save");
        }
    }
}