using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class MenuManager
    {
        private IMenuDB MenuDb { get; }


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

        public List<Menu> GetMenus()
        {
            return MenuDb.GetMenus();
        }

        public void UpdateMenuName(Menu menu)
        {
            MenuDb.UpdateMenuName(menu);
        }
        public void UpdateMenuPrice(Menu menu)
        {
            MenuDb.UpdateMenuPrice(menu);
        }

    }
}
