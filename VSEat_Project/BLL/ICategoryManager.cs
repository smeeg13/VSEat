using DAL;
using System.Collections.Generic;

namespace BLL
{
    public interface ICategoryManager
    {
        Category AddCategory(Category category);
        void DeleteCategory(int CategoryID);
        List<Category> GetCategories();
        Category GetCategoryID(string CategoryName);
        Category GetCategoryName(int CategoryID);
        Category UpdateCategory(Category category);
    }
}