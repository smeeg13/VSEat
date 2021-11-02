using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDB : ICategoryDB
    {
        private IConfiguration Configuration { get; }

        public CategoryDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Category> Categories
        {
            get
            {
                List<Category> results = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "Select * from Category";
                        SqlCommand cmd = new SqlCommand(query, cn);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (results == null)
                                    results = new List<Category>();

                                Category category = new Category();

                                category.CategoryID = (int)dr["IdCategory"];

                                if (dr["NameCategory"] != null)
                                    category.CategoryName = (string)dr["NameCategory"];

                                if (dr["DescriptionCategory"] != null)
                                    category.Description = (string)dr["DescriptionCategory"];

                                results.Add(category);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return results;
            }
        }

        public Category GetCategory(string nameCategory, string descriptionCategory)
        {
            Category category = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Category where NameCategory = @NameCategory AND DescriptionCategory = @DescriptionCategory";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameCategory", nameCategory);
                    cmd.Parameters.AddWithValue("@DescriptionCategory", descriptionCategory);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            category = new Category();

                            category.CategoryID = (int)dr["idCategory"];

                            if(dr["NameCategory"] != null)
                                category.CategoryName = (string)dr["NameCategory"];

                            if (dr["DescriptionCategory"] != null)
                                category.Description = (string)dr["DescriptionCategory"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return category;
        }

        public void UpdateCategoryDescription(Category category, string DescriptionCategory)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Category SET DescriptionCategory = @DescriptionCategory WHERE IdCategory = @idcategory";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DescriptionCategory", DescriptionCategory );

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Category AddCategory(Category category)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Category(CategoryName, DescriptionCategory) values(@NameCategory, @DescriptionCategory); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    cmd.Parameters.AddWithValue("@DescriptionCategory", category.Description);
             

                    cn.Open();

                    category.CategoryID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return category;
        }

        public void DeleteCategory(Category category)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from CategorY WHERE IdCategory = @IdCategory ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.RemoveAt("@CategoryName");
                    cmd.Parameters.RemoveAt("@DescriptionCategory");

                    cn.Open();

                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
