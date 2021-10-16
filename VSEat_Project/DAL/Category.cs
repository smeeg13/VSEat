using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Category
    {
        private int IdCategory  { get; set; }
        private string NameCategory  { get; set; }
        private string DescriptionCategory  { get; set; }

        public Category(int idCategory, string nameCategory, string descriptionCategory)
        {
            IdCategory = idCategory;
            NameCategory = nameCategory;
            DescriptionCategory = descriptionCategory;
        }
    }


}
