using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class DelivererController : Controller
    {
        public static List<Models.Deliverer> DelivererList = new List<Models.Deliverer>
        {
            new Models.Deliverer{DelivererID = 1, Username="Emilie", Password="Teodoro", NumberOrdersAssigned=1, Availability=1, LocationID=3, DateAssigned= DateTime.Now },
            new Models.Deliverer{DelivererID = 2, Username="Mégane", Password="Solliard", NumberOrdersAssigned=1, Availability=1, LocationID=3, DateAssigned= DateTime.Now }

        };

        private IDelivererManager delivererManager { get; }

        public ActionResult Index()
        {
            var deliverers = delivererManager.GetDeliverers();
            return View(deliverers);
        }

        public ActionResult Edit(DTO.Deliverer d)
        {
            if (ModelState.IsValid)
            {
                var deliverer  = delivererManager.UpdateDeliverer(d);
                return RedirectToAction(nameof(Index));
            }
            return View(d);
        }





    }
}

