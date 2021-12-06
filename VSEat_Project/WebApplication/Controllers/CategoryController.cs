using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class CategoryController : Controller
    {
        public static List<Models.Category> CategoryList = new List<Models.Category>
        {
            new Models.Category{CategoryID=1, CategoryName="Italien", Description="Nourriture italienne"},
            new Models.Category{CategoryID=2, CategoryName="Japonais", Description="Sushi et ramens"}
        };

        private ICategoryManager categoryManager { get; }


        public IActionResult Index()
        {
            var category = categoryManager.GetCategories();
            return View(category);
        }
    }
}
