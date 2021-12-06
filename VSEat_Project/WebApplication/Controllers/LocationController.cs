using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class LocationController : Controller
    {
       // public static List<Models.Location> DelivererList = new List<Models.Location>

        public IActionResult Index()
        {
            return View();
        }
    }
}
