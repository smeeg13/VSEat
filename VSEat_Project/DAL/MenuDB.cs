using DTO;
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
                    string query = "Select * from Menus ";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Menu>();

                            Menu menu = new Menu();

                            if (dr["MenuID"] != null)
                            menu.MenuID = (int)dr["MenuID"];
                            if (dr["UnitPrice"] != null)
                                menu.UnitPrice = (int)dr["UnitPrice"];
                            if (dr["QuantityPerUnit"] != null)
                                menu.QuantityPerUnit = (int)dr["QuantityPerUnit"];
                            if (dr["MenuName"] != null)
                            menu.MenuName = (string)dr["MenuName"];
                            if (dr["UnitsInStock"] != null)
                                menu.UnitsInStock = (int)dr["UnitsInStock"];
                            if (dr["UnitsOnOrder"] != null)
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

        public List<Menu> GetMenusPerResto(string RestaurantName)
        {
            List<Menu> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Menus WHERE RestaurantName=@RestaurantName";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@RestaurantName", RestaurantName);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Menu>();

                            Menu menu = new Menu();

                            if (dr["MenuID"] != null)
                                menu.MenuID = (int)dr["MenuID"];
                            if (dr["UnitPrice"] != null)
                                menu.UnitPrice = (int)dr["UnitPrice"];
                            if (dr["QuantityPerUnit"] != null)
                                menu.QuantityPerUnit = (int)dr["QuantityPerUnit"];
                            if (dr["MenuName"] != null)
                                menu.MenuName = (string)dr["MenuName"];
                            if (dr["UnitsInStock"] != null)
                                menu.UnitsInStock = (int)dr["UnitsInStock"];
                            if (dr["UnitsOnOrder"] != null)
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

        public Menu GetMenuPerRestoID(int RestaurantID)
        {
            Menu menu = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Menus WHERE RestaurantID=@RestaurantID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@RestaurantID", RestaurantID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            menu = new Menu();

                            if (dr["MenuID"] != null)
                                menu.MenuID = (int)dr["MenuID"];
                            if (dr["UnitPrice"] != null)
                                menu.UnitPrice = (int)dr["UnitPrice"];
                            if (dr["QuantityPerUnit"] != null)
                                menu.QuantityPerUnit = (int)dr["QuantityPerUnit"];
                            if (dr["MenuName"] != null)
                                menu.MenuName = (string)dr["MenuName"];
                            if (dr["UnitsInStock"] != null)
                                menu.UnitsInStock = (int)dr["UnitsInStock"];
                            if (dr["UnitsOnOrder"] != null)
                                menu.UnitsOnOrder = (int)dr["UnitsOnOrder"];

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

                            if (dr["MenuID"] != null)
                                menu.MenuID = (int)dr["MenuID"];
                            if (dr["UnitPrice"] != null)
                                menu.UnitPrice = (int)dr["UnitPrice"];
                            if (dr["QuantityPerUnit"] != null)
                                menu.QuantityPerUnit = (int)dr["QuantityPerUnit"];
                            if (dr["MenuName"] != null)
                                menu.MenuName = (string)dr["MenuName"];
                            if (dr["UnitsInStock"] != null)
                                menu.UnitsInStock = (int)dr["UnitsInStock"];
                            if (dr["UnitsOnOrder"] != null)
                                menu.UnitsOnOrder = (int)dr["UnitsOnOrder"];
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

        public Menu GetMenuWithID(int MenuID)
        {
            Menu menu = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Menus where MenuID = @MenuID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@MenuID", MenuID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            menu = new Menu();

                            if (dr["MenuID"] != null)
                                menu.MenuID = (int)dr["MenuID"];
                            if (dr["UnitPrice"] != null)
                                menu.UnitPrice = (int)dr["UnitPrice"];
                            if (dr["QuantityPerUnit"] != null)
                                menu.QuantityPerUnit = (int)dr["QuantityPerUnit"];
                            if (dr["MenuName"] != null)
                                menu.MenuName = (string)dr["MenuName"];
                            if (dr["UnitsInStock"] != null)
                                menu.UnitsInStock = (int)dr["UnitsInStock"];
                            if (dr["UnitsOnOrder"] != null)
                                menu.UnitsOnOrder = (int)dr["UnitsOnOrder"];
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

        public Menu GetMenuUnitPrice(string MenuName)
        {
            Menu menu = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select UnitPrice from Menus where MenuName = @MenuName";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@MenuName", MenuName);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            menu = new Menu();

                            if (dr["MenuID"] != null)
                                menu.MenuID = (int)dr["MenuID"];
                            if (dr["UnitPrice"] != null)
                                menu.UnitPrice = (int)dr["UnitPrice"];
                            if (dr["QuantityPerUnit"] != null)
                                menu.QuantityPerUnit = (int)dr["QuantityPerUnit"];
                            if (dr["MenuName"] != null)
                                menu.MenuName = (string)dr["MenuName"];
                            if (dr["UnitsInStock"] != null)
                                menu.UnitsInStock = (int)dr["UnitsInStock"];
                            if (dr["UnitsOnOrder"] != null)
                                menu.UnitsOnOrder = (int)dr["UnitsOnOrder"];
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

        public Menu UpdateMenu(Menu menu)
        {
            int result = 0; 
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Menus SET MenuName = @MenuName WHERE IdMenu = @MenuID ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@MenuName", menu.MenuName);
                    cmd.Parameters.AddWithValue("@MenuID", menu.MenuID);
                    cmd.Parameters.AddWithValue("@RestaurantID", menu.RestaurantID);
                    cmd.Parameters.AddWithValue("@UnitPrice", menu.UnitPrice);
                    cmd.Parameters.AddWithValue("@CategoryID", menu.CategoryID);
                    cmd.Parameters.AddWithValue("@UnitsInStock", menu.UnitsInStock);
                    cmd.Parameters.AddWithValue("@UnitsOnOrder", menu.UnitsOnOrder);
                    cmd.Parameters.AddWithValue("@StatusMenu", menu.StatusMenu);

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return menu;
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
                    cmd.Parameters.AddWithValue("@MenuName", menu.MenuName);
                    cmd.Parameters.AddWithValue("@MenuID", menu.MenuID);
                    cmd.Parameters.AddWithValue("@RestaurantID", menu.RestaurantID);
                    cmd.Parameters.AddWithValue("@UnitPrice", menu.UnitPrice);
                    cmd.Parameters.AddWithValue("@CategoryID", menu.CategoryID);
                    cmd.Parameters.AddWithValue("@UnitsInStock", menu.UnitsInStock);
                    cmd.Parameters.AddWithValue("@UnitsOnOrder", menu.UnitsOnOrder);
                    cmd.Parameters.AddWithValue("@StatusMenu", menu.StatusMenu);

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
                    cmd.Parameters.AddWithValue("@MenuID", menu.MenuID);
                    cmd.Parameters.AddWithValue("@RestaurantID", menu.RestaurantID);
                    cmd.Parameters.AddWithValue("@UnitPrice", menu.UnitPrice);
                    cmd.Parameters.AddWithValue("@CategoryID", menu.CategoryID);
                    cmd.Parameters.AddWithValue("@UnitsInStock", menu.UnitsInStock);
                    cmd.Parameters.AddWithValue("@UnitsOnOrder", menu.UnitsOnOrder);
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
