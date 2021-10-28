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

        public List<Menu> GetMenus()
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

        public void UpdateMenuNameMenu(string NameMenu)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Menu SET NameMenu = @NameMenu WHERE IdMenu = @IdMenu";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameMenu", NameMenu);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateMenuPriceMenu(int PriceMenu)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Menu SET PriceMenu = @PriceMenu WHERE IdMenu = @IdMenu";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@PriceMenu", PriceMenu);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Menu AddMenu(Menu menu)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Menu(NameMenu, PriceMenu, ImageMenu, IngredientsMenu, StatusMenu) values(@NameMenu, @PriceMenu, @ImageMenu, @IngredientsMenu, @StatusMenu); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameMenu", menu.NameMenu);
                    cmd.Parameters.AddWithValue("@PriceMenu", menu.PriceMenu);
                    cmd.Parameters.AddWithValue("@ImageMenu", menu.ImageMenu);
                    cmd.Parameters.AddWithValue("@IngredientsMenu", menu.IngredientsMenu);
                    cmd.Parameters.AddWithValue("@StatusMenu", menu.IngredientsMenu);

                    cn.Open();

                    menu.IdMenu = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return menu;
        }

        public void DeleteMenu(Menu menu)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Menu WHERE IdMenu = @IdMenu ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdMenu", menu.IdMenu);

                    cn.Open();

                    menu.IdMenu = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (Exception e)
            {
                throw e;
            }


        }
    }
}
