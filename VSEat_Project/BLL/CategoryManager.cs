using DAL;
using DTO;
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


        public CategoryManager(ICategoryDB CategoryDb)
        {
            this.CategoryDb = CategoryDb;
        }

        public Category AddCategory(Category category)
        {
            return CategoryDb.AddCategory(category);
        }

        public void DeleteCategory(int CategoryID)
        {
            CategoryDb.DeleteCategory(CategoryID);
        }

        public List<Category> GetCategories()
        {
            return CategoryDb.Categories;
        }

        public Category GetCategoryID(string CategoryName)
        {
            return CategoryDb.GetCategoryID(CategoryName);

        }

        public Category GetCategoryName(int CategoryID)
        {
            return CategoryDb.GetCategoryName(CategoryID);
        }

        public Category UpdateCategory(Category category)
        {
            return CategoryDb.UpdateCategory(category);
        }
    }
}
