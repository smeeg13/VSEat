using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryManager : ICategoryManager
    {
        private ICategoryDB CategoryDb { get; }


        public CategoryManager(IConfiguration conf)
        {
            CategoryDb = new CategoryDB(conf);
        }

        public Category AddCategory(Category category)
        {
            return CategoryDb.AddCategory(category);
        }

        public void DeleteCategory(int CategoryID)
        {
            CategoryDb.DeleteCategory(CategoryID);
        }

        public Category GetCategoryName(int CategoryID)
        {
            return CategoryDb.GetCategoryName(CategoryID);
        }

        public Category GetCategoryID(string CategoryName)
        {
            return CategoryDb.GetCategoryID(CategoryName);

        }

        public List<Category> GetCategories()
        {
            return CategoryDb.Categories;
        }

        public void UpdateCategory(Category category)
        {
            CategoryDb.UpdateCategory(category);
        }
    }
}
