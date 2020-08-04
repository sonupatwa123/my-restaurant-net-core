using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyRestaurant.Web.Api.Controllers
{
    public class NavigationController : ControllerBase
    {
        public async Task<IActionResult> List(PageConfiguration configuration)
        {
            return Ok();
        }
    }
}
