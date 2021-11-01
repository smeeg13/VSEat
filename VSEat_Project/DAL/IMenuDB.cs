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
        Menu GetMenu(string MenuName, int UnitPrice);
        Menu AddMenu(Menu menu);
        void UpdateMenuName(Menu menu, string NameMenu);
        void UpdateMenuPrice(Menu menu, int UnitPrice);
        void DeleteMenu(Menu menu);
    }
}
