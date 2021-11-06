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
                        string query = "Select * from Categories";
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

        public Category GetCategoryName(string nameCategory)
        {
            Category category = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Categories where NameCategory = @NameCategory";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameCategory", nameCategory);
                   

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

        public Category GetCategoryID(int CategoryID)
        {
            Category category = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Categories where CategoryID = @CategoryID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            category = new Category();

                            category.CategoryID = (int)dr["idCategory"];

                            if (dr["NameCategory"] != null)
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
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Categories SET DescriptionCategory = @DescriptionCategory WHERE IdCategory = @idcategory";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DescriptionCategory", DescriptionCategory );
                    result = cmd.ExecuteNonQuery();

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
                    string query = "Insert into Categories(CategoryName, DescriptionCategory) values(@NameCategory, @DescriptionCategory); SELECT SCOPE_IDENTITY()";
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

        public void DeleteCategory(int CategoryID)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Categories WHERE IdCategory = @IdCategory ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

   
    }
}
