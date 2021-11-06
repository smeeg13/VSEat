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
                    string query = "Select * from Menus";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Menu>();

                            Menu menu = new Menu();

                            menu.MenuID = (int)dr["MenuID"];
                            menu.UnitPrice = (int)dr["UnitPrice"];

                            if (dr["MenuName"] != null)
                                menu.MenuName = (string)dr["MenuName"];
                            menu.UnitsInStock = (int)dr["UnitsInStock"];
                            menu.UnitsOnOrder = (int)dr["UnitsOnOrder"];



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

        public Menu GetMenu(string NameMenu)
        {
            Menu menu = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Menus where NameMenu = @NameMenu";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameMenu", NameMenu);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            menu = new Menu();

                            menu.MenuID = (int)dr["MenuID"];

                            if (dr["PriceMenu"] != null)
                                menu.UnitPrice = (int)dr["PriceMenu"];

                            if (dr["NameMenu"] != null)
                                menu.MenuName = (string)dr["NameMenu"];

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

        public void UpdateMenuName(Menu menu)
        {
            int result = 0; 
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Menus SET MenuName = @MenuName WHERE IdMenu = @MenuID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@MenuName", menu.MenuName);
                    cmd.Parameters.AddWithValue("@MenuID", menu.MenuID);

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateMenuPrice(Menu menu)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Menus SET UnitPrice = @UnitPrice WHERE MenuID = @MenuID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@UnitPrice", menu.UnitPrice);
                    cmd.Parameters.AddWithValue("@MenuID", menu.MenuID);


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
                    string query = "Insert into Menus(MenuName, QuantityPerUnit, UnitPrice,UnitsInStock, UnitsOnOrder, StatusMenu) values(@MenuName, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @StatusMenu); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@MenuName", menu.MenuName);
                    cmd.Parameters.AddWithValue("@QuantityPerUnit", menu.QuantityPerUnit);
                    cmd.Parameters.AddWithValue("@UnitPrice", menu.UnitPrice);
                    cmd.Parameters.AddWithValue("@UnitInStock", menu.UnitsInStock);
                    cmd.Parameters.AddWithValue("@UnitOnOrder", menu.UnitsOnOrder);
                    cmd.Parameters.AddWithValue("@StatusMenu", menu.StatusMenu);

                    cn.Open();

                    menu.MenuID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return menu;
        }

        public void DeleteMenu(int MenuID)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Menus WHERE MenuID = @MenuID ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@MenuID", MenuID);
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
