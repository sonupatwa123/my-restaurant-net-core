using Microsoft.AspNetCore.Mvc;

namespace MyRestaurant.Web.Admin.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Navigations()
        {
            return View();
        }
        public ActionResult Add(long? id)
        {
            if (id != null)
            {
                ViewBag.Id = id;
            }
            return View();
        }
    }
}