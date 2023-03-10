using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   

    public class OrderDB : IOrderDB
    {

        private IConfiguration Configuration { get; }

        //Constructor
        public OrderDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Method to get all orders in the database
        public List<Order> GetOrders()
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.OrderID = (int)dr["OrderID"];
                            order.UserID = (int)dr["UserID"];
                            order.OrderDate = (DateTime)dr["OrderDate"];
                            order.RequiredDate = (DateTime)dr["RequiredDate"];
                            order.ShippedDate = (DateTime)dr["ShippedDate"];
                            order.DelivererID = (int)dr["DelivererID"];
                            order.Price = (int)dr["Price"];
                            order.ShipAddress = (string)dr["ShipAddress"];
                            order.LocationID = (int)dr["LocationID"];
                            order.StatusOrder = (string)dr["StatusOrder"];

                            results.Add(order);
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

        //Method to get all the order made by one particular User in the database
        public List<Order> GetOrdersForUser(int UserID)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.OrderID = (int)dr["OrderID"];
                            order.UserID = (int)dr["UserID"];
                            order.OrderDate = (DateTime)dr["OrderDate"];
                            order.RequiredDate = (DateTime)dr["RequiredDate"];
                            order.ShippedDate = (DateTime)dr["ShippedDate"];
                            order.DelivererID = (int)dr["DelivererID"];
                            order.Price = (int)dr["Price"];
                            order.ShipAddress = (string)dr["ShipAddress"];
                            order.LocationID = (int)dr["LocationID"];
                            order.StatusOrder = (string)dr["StatusOrder"];

                            results.Add(order);
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

        //Method to get all the order made by one particular User in the database
        public List<Order> GetOrdersForDeliverer(int DelivererID)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders WHERE DelivererID = @DelivererID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DelivererID", DelivererID);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.OrderID = (int)dr["OrderID"];
                            order.UserID = (int)dr["UserID"];
                            order.OrderDate = (DateTime)dr["OrderDate"];
                            order.RequiredDate = (DateTime)dr["RequiredDate"];
                            order.ShippedDate = (DateTime)dr["ShippedDate"];
                            order.DelivererID = (int)dr["DelivererID"];
                            order.Price = (int)dr["Price"];
                            order.ShipAddress = (string)dr["ShipAddress"];
                            order.LocationID = (int)dr["LocationID"];
                            order.StatusOrder = (string)dr["StatusOrder"];

                            results.Add(order);
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
        //Method to get one specific order with his ID
        public Order GetOrderWithID(int OrderID)
        {
            Order result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders WHERE OrderID=@OrderID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new Order();

                            result.OrderID = (int)dr["OrderID"];
                            result.UserID = (int)dr["UserID"];
                            result.OrderDate = (DateTime)dr["OrderDate"];
                            result.RequiredDate = (DateTime)dr["RequiredDate"];
                            result.ShippedDate = (DateTime)dr["ShippedDate"];
                            result.DelivererID = (int)dr["DelivererID"];
                            result.Price = (int)dr["Price"];
                            result.ShipAddress = (string)dr["ShipAddress"];
                            result.LocationID = (int)dr["LocationID"];
                            result.StatusOrder = (string)dr["StatusOrder"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        //Method to get one specific order for one deliverer in the database
        public Order GetOrderForDeliverer(int OrderID, int DelivererID)
        {
            Order result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders WHERE OrderID=@OrderID AND DelivererID=@DelivererID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    cmd.Parameters.AddWithValue("@DelivererID", DelivererID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new Order();

                            result.OrderID = (int)dr["OrderID"];
                            result.UserID = (int)dr["UserID"];
                            result.OrderDate = (DateTime)dr["OrderDate"];
                            result.RequiredDate = (DateTime)dr["RequiredDate"];
                            result.ShippedDate = (DateTime)dr["ShippedDate"];
                            result.DelivererID = (int)dr["DelivererID"];
                            result.Price = (int)dr["Price"];
                            result.ShipAddress = (string)dr["ShipAddress"];
                            result.LocationID = (int)dr["LocationID"];
                            result.StatusOrder = (string)dr["StatusOrder"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        //Method to get one specific order for one user in the database
        public Order GetOrderForUser(int OrderID, int UserID)
        {
            Order result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders WHERE OrderID=@OrderID AND UserID=@UserID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    cmd.Parameters.AddWithValue("@UserID", UserID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new Order();

                            result.OrderID = (int)dr["OrderID"];
                            result.UserID = (int)dr["UserID"];
                            result.OrderDate = (DateTime)dr["OrderDate"];
                            result.RequiredDate = (DateTime)dr["RequiredDate"];
                            result.ShippedDate = (DateTime)dr["ShippedDate"];
                            result.DelivererID = (int)dr["DelivererID"];
                            result.Price = (int)dr["Price"];
                            result.ShipAddress = (string)dr["ShipAddress"];
                            result.LocationID = (int)dr["LocationID"];
                            result.StatusOrder = (string)dr["StatusOrder"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        //Method to add one order in the database
        public Order AddOrder(Order order)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Orders(UserID, OrderDate, RequiredDate, ShippedDate, DelivererID, Price, ShipAddress, LocationID, StatusOrder) values(@UserID, @OrderDate, @RequiredDate,@ShippedDate, @DelivererID, @Price, @ShipAddress, @LocationID, @StatusOrder); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@UserID", order.UserID);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@RequiredDate", order.RequiredDate);
                    cmd.Parameters.AddWithValue("@ShippedDate", order.ShippedDate);
                    cmd.Parameters.AddWithValue("@DelivererID", order.DelivererID);
                    cmd.Parameters.AddWithValue("@Price", order.Price);
                    cmd.Parameters.AddWithValue("@ShippedAddress", order.ShipAddress);
                    cmd.Parameters.AddWithValue("@LocationID", order.LocationID);
                    cmd.Parameters.AddWithValue("@StatusOrder", order.StatusOrder);

                    cn.Open();

                    order.OrderID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        //Method to update one order 
       public Order UpdateOrder(Order order)
        {
            var result = 0;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Orders SET UserID = @UserID, OrderDate=@OrderDate, RequiredDate=@RequiredDate, DelivererID=@DelivererID, Price=@Price, ShipAddress=@ShipAddress, LocationID = @LocationID, StatusOrder = @StatusOrder WHERE OrderID = @OrderID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderID", order.OrderID);

                    cmd.Parameters.AddWithValue("@UserID", order.UserID);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@RequiredDate", order.RequiredDate);
                    cmd.Parameters.AddWithValue("@ShippedDate", order.ShippedDate);
                    cmd.Parameters.AddWithValue("@DelivererID", order.DelivererID);
                    cmd.Parameters.AddWithValue("@Price", order.Price);
                    cmd.Parameters.AddWithValue("@ShipAddress", order.ShipAddress);
                    cmd.Parameters.AddWithValue("@LocationID", order.LocationID);
                    cmd.Parameters.AddWithValue("@StatusOrder", order.StatusOrder);

                    cn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return order;
        }


        //Method to delete one order in the database
        public void DeleteOrder(int orderId, int userId)
        {
            int result = 0;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    var query = "Delete from Orders WHERE OrderID = @OrderID AND UserID=@UserID";
                    var cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderID",orderId);
                    cmd.Parameters.AddWithValue("@UserID", userId);

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