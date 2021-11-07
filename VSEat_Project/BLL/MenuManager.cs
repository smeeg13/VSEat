using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSEat_Project;

namespace BLL
{
    public class MenuManager : IMenuManager
    {
        private IMenuDB MenuDb { get; }
        private IRestaurantDB RestaurantDb { get; }

        public MenuManager(IConfiguration conf)
        {
            MenuDb = new MenuDB(conf);
        }

        public Menu AddMenu(Menu menu)
        {
            return MenuDb.AddMenu(menu);
        }

        public void DeleteMenu(int MenuID)
        {
            MenuDb.DeleteMenu(MenuID);
        }

        public Menu GetMenu(string NameMenu)
        {
            return MenuDb.GetMenu(NameMenu);
        }

        public Menu GetMenuWithID(int MenuID)
        {
            return MenuDb.GetMenuWithID(MenuID);
        }

        public Menu GetMenuUnitPrice(string MenuName)
        {
            return MenuDb.GetMenuUnitPrice(MenuName);
        }

        public List<Menu> GetMenus()
        {
            return MenuDb.GetMenus();
        }

        public Menu UpdateMenu(Menu menu)
        {
           return MenuDb.UpdateMenu(menu);
        }
        public void UpdateMenuPrice(Menu menu)
        {
            MenuDb.UpdateMenuPrice(menu);
        }



    }
}
