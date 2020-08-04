using Microsoft.AspNetCore.Mvc;

namespace MyRestaurant.Web.Admin.Controllers
{

    public class AdminController : Controller
    {

        
        public IActionResult Navigations()
        {
            return View();
        }      
        public IActionResult SaveNavigation(long? id)
        {
            if (id != null)
            {
                ViewBag.Id = id;
            }
            return View();
        }

    }
}