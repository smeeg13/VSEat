using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryManager
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

        public Category GetCategoryName(string NameCategory)
        {
            return CategoryDb.GetCategoryName(NameCategory);
        }

        public Category GetCategoryID (int CategoryID)
        {
            return CategoryDb.GetCategoryID(CategoryID);

        }

        public List<Category> GetCategories()
        {
            return CategoryDb.Categories;
        }

        public void UpdateCategoryDescription(Category category, string newDescriptionCategory)
        {
            CategoryDb.UpdateCategoryDescription(category, newDescriptionCategory);
        }
    }
}
