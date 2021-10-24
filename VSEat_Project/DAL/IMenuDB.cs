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
        Menu GetMenu(string NameMenu, int PriceMenu);
        Menu AddMenu(Menu menu);
        void UpdateMenu(Menu menu);
        void DeleteMenu(Menu menu);
    }
}
