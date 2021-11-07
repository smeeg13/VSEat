using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface IMenuDB
    {
        List<Menu> GetMenus();
        List<Menu> GetMenusPerResto(string RestaurantName);
        Menu GetMenuPerResto(string RestaurantName);
        Menu GetMenu(string MenuName);
        Menu GetMenuWithID(int MenuID);
        Menu GetMenuUnitPrice(string NameMenu);
        Menu AddMenu(Menu menu);
        Menu UpdateMenu(Menu menu);
        void UpdateMenuPrice(Menu menu);
        void DeleteMenu(int MenuID);
    }
}
