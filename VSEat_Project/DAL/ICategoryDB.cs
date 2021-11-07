using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface ICategoryDB
    {
        List<Category> Categories { get; }

        Category GetCategoryName(int CategoryID);
        Category GetCategoryID(string CategoryName);
        Category AddCategory(Category category);
        void DeleteCategory(int CategoryID);
        Category UpdateCategory(Category category);
    }
}
