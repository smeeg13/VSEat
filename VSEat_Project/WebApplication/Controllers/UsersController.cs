using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class UsersController : Controller
    {
        private IUserManager UserManager { get; }

        public UsersController(IUserManager userManager)
        {
            UserManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
