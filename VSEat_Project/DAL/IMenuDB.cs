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
        Menu GetMenu(string MenuName);
        Menu AddMenu(Menu menu);
        void UpdateMenuName(Menu menu);
        void UpdateMenuPrice(Menu menu);
        void DeleteMenu(int MenuID);
    }
}
