using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IMenuDB
    {
        List<Menu> GetMenus();
        Menu GetMenu(string email, string password);
        void AddMenu(Menu menu);
        void UpdateMenu(Menu menu);
        void DeleteMenu(int id);

    }
}
