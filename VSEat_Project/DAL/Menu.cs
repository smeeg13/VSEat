using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Menu
    {

        private int Id_Menu { get; set; }
        private string Name_Menu { get; set; }
        private int Price_Menu { get; set; }
        private int Image_Menu { get; set; }
        private string Ingredients_Menu { get; set; }
        private string Status_Menu { get; set; }
        public Menu(int id_Menu, string name_Menu, int price_Menu, int image_Menu, string ingredients_Menu, string status_Menu)
        {
            Id_Menu = id_Menu;
            Name_Menu = name_Menu;
            Price_Menu = price_Menu;
            Image_Menu = image_Menu;
            Ingredients_Menu = ingredients_Menu;
            Status_Menu = status_Menu;
        }


    }
}
