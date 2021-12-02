using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IMenuManager
    {
        Menu AddMenu(Menu menu);
        void DeleteMenu(int MenuID);
        Menu GetMenu(string NameMenu);
        List<Menu> GetMenus();
        Menu GetMenuUnitPrice(string MenuName);
        Menu GetMenuWithID(int MenuID);
        Menu UpdateMenu(Menu menu);
        void UpdateMenuPrice(Menu menu);
    }
}