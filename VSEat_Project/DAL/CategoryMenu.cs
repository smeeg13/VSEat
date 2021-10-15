using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CategoryMenu
    {
        private int id_CategoryMenu;
        private string Name_category;
        private string Description_category;

        public CategoryMenu(int id_CategoryMenu, string name_category, string description_category)
        {
            id_CategoryMenu = id_categoryMenu;
            Name_category = name_category;
            Description_category = description_category;
        }

        public int id_categoryMenu { get; set; }
        public int name_category { get; set; }
        public int description_category { get; set; }

    }


}
