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

        public void DeleteMenu(Menu menu)
        {
            MenuDb.DeleteMenu(menu);
        }

        public Menu GetMenu(string NameMenu, int PriceMenu)
        {
            return MenuDb.GetMenu(NameMenu, PriceMenu);
        }

        public List<Menu> GetMenus()
        {
            return MenuDb.GetMenus();
        }

        public void UpdateMenuName(Menu menu, string newname)
        {
            MenuDb.UpdateMenuName(menu, newname);
        }
        public void UpdateMenuPrice(Menu menu, int newPrice)
        {
            MenuDb.UpdateMenuPrice(menu, newPrice);
        }
    }
}
