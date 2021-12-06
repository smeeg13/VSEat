using BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class MenuController : Controller
    {

        public static List<Models.Menu> MenuList = new List<Models.Menu>
      {
          new Models.Menu{MenuID=1, CategoryID=1, MenuName="Pizza", QuantityPerUnit=1, RestaurantID=1, StatusMenu="Available", UnitPrice=15, UnitsInStock=20, UnitsOnOrder=3}


      };

        private IMenuManager menuManager { get; }

        public IActionResult Index()
        {
            var menus = menuManager.GetMenus();
            return View(menus);
        }
    }
}
