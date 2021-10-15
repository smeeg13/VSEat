using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CategoryMenu
    {
        private int id_CategoryMenu  { get; set; }
        private string Name_category  { get; set; }
        private string Description_category  { get; set; }

        public CategoryMenu(int id_CategoryMenu, string name_category, string description_category)
        {
            id_CategoryMenu = id_CategoryMenu;
            Name_category = name_category;
            Description_category = description_category;
        }

    }


}
