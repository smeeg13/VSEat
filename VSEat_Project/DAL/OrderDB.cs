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

        //Method to get all the order in the database
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

                            order.OrderDate = (DateTime)dr["OrderDate"];

                            order.ShippedDate = (DateTime)dr["ShippedDate"];

                            order.ShipAddress = (string)dr["ShipAddress"];


                            order.Price = (int)dr["Price"];

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

        //Method to get one specific order in the database
        public Order GetOrder(int OrderID, int UserID)
        {
            Order result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Order WHERE OrderID=@OrderID AND UserID=@UserID";
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

                            if (dr["OrderDate"] != null)
                                result.OrderDate = (DateTime)dr["OrderDate"];

                            if (dr["ShippedDate"] != null)
                                result.ShippedDate = (DateTime)dr["ShippedDate"];

                            if (dr["ShipAddress"] != null)
                                result.ShipAddress = (string)dr["ShipAddress"];

                            result.Price = (int)dr["Price"];

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
                    string query = "Insert into Order(UserID, DateOrder) values(@IdUser, @DateOrder); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@UserID", order.UserID);
                    cmd.Parameters.AddWithValue("@DateOrder", order.OrderDate);

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

        //Method to update the status of one order in the database
        public void UpdateOrderStatus(Order order, string newStatus)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Order SET StatusOrder = @statusorder WHERE OrderID = @OrderID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@statusorder", newStatus);
                    cmd.Parameters.AddWithValue("@OrderID", order.OrderID);


                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //Method to delete one order in the database
        public void DeleteOrder(Order order)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Order WHERE IdOrder = @idorder";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idorder", order.OrderID);

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