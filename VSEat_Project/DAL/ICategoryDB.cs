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

        Category GetCategoryName(string NameCategory);
        Category GetCategoryID(int CategoryID);
        Category AddCategory(Category category);
        void DeleteCategory(int CategoryID);
        void UpdateCategoryDescription(Category category, string newDescriptionCategory);
    }
}
