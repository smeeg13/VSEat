using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface ICategoryDB
    {
        List<Category> GetCategories();
        Category GetCategory(string NameCategory, string DescriptionCategory);
        Category AddCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category, string DescriptionCategory);
    }
}
