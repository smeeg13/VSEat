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

        public void DeleteCategory(Category category)
        {
            CategoryDb.DeleteCategory(category);
        }

        public Category GetCategory(string NameCategory, string DescriptionCategory)
        {
            return CategoryDb.GetCategory(NameCategory, DescriptionCategory);
        }

        public List<Category> GetCategories()
        {
            return CategoryDb.Categories;
        }

        public void UpdateCategory(Category category, string newDescriptionCategory)
        {
            CategoryDb.UpdateCategory(category, newDescriptionCategory);
        }
    }
}
