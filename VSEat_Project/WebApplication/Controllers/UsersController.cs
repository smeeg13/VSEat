using BLL;
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


        public UsersController(IUserManager usermanager)
        {
            UserManager = usermanager;
        }

        //GET :UsersController
        public IActionResult Index()
        {
            var users = UserManager.GetUsers();
            return View(users);
        }
    }
}
