using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MenuDB : IMenuDB
    {
        private IConfiguration Configuration { get; }

        public MenuDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Menu> GetMenu()
        {
            List<Menu> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Menu";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Menu>();

                            Menu menu = new Menu();

                            menu.IdMenu = (int)dr["IdMenu"];
                            menu.PriceMenu = (int)dr["PriceMenu"];

                            menu.ImageMenu = (int)dr["ImageMenu"];

                            if (dr["NameMenu"] != null)
                                menu.NameMenu = (string)dr["NameMenu"];

                            if (dr["IngredientsMenu"] != null)
                                menu.IngredientsMenu = (string)dr["IngredientsMenu"];

                            if (dr["StatusMenu"] != null)
                                menu.StatusMenu = (string)dr["StatusMenu"];

                            results.Add(menu);
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

        public Menu GetMenu(string NameMenu, int PriceMenu)
        {
            Menu menu = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Deliverer where NameMenu = @NameMenu AND PriceMenu = @PriceMenu";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameMenu", NameMenu);
                    cmd.Parameters.AddWithValue("@PriceMenu", PriceMenu);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            menu = new Menu();

                            menu.IdMenu = (int)dr["IdMenu"];

                            if (dr["PriceMenu"] != null)
                                menu.PriceMenu = (int)dr["PriceMenu"];

                            if (dr["NameMenu"] != null)
                                menu.NameMenu = (string)dr["NameMenu"];

                            if (dr["ImageMenu"] != null)
                                menu.ImageMenu = (int)dr["ImageMenu"];

                            if (dr["IngredientsMenu"] != null)
                                menu.IngredientsMenu = (string)dr["IngredientsMenu"];

                            if (dr["StatusMenu"] != null)
                                menu.StatusMenu = (string)dr["StatusMenu"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return menu;
        }

        public List<Menu> GetMenus()
        {
            throw new NotImplementedException();
        }

        public void AddMenu(Menu menu)
        {
            throw new NotImplementedException();
        }

        public void UpdateMenu(Menu menu)
        {
            throw new NotImplementedException();
        }

        public void DeleteMenu(Menu menu)
        {
            throw new NotImplementedException();
        }

        Menu IMenuDB.AddMenu(Menu menu)
        {
            throw new NotImplementedException();
        }
    }
}
