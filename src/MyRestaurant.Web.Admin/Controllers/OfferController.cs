using Microsoft.AspNetCore.Mvc;

namespace MyRestaurant.Web.Admin.Controllers
{
    public class OfferController : Controller
    {
        // GET: Offer
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Save(long? id) {
            if (id != null)
            {
                ViewBag.Id = id;
            }
            return View();
        }
    }
}