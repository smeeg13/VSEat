using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDB 
    {
        private IConfiguration Configuration { get; }

        public CategoryDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Category> GetCategory()
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

                            category.IdCategory = (int)dr["IdCategory"];

                            if (dr["NameCategory"] != null)
                                category.NameCategory = (string)dr["NameCategory"];

                            if (dr["DescriptionCategory"] != null)
                                category.DescriptionCategory = (string)dr["DescriptionCategory"];

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

                            category.IdCategory = (int)dr["idCategory"];

                            if(dr["NameCategory"] != null)
                                category.NameCategory = (string)dr["NameCategory"];

                            if (dr["DescriptionCategory"] != null)
                                category.DescriptionCategory = (string)dr["DescriptionCategory"];
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
    }
}
