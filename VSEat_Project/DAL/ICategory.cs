using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface ICategory
    {
        List<Category> GetCategories();
        Category GetCategory();
        void AddCategory();
        void DeleteCategory();
        void UpdateCategory();
    }
}
