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
    public class OrderDetailDB : IOrderDetailDB
    {
        private IConfiguration Configuration { get; }

        public OrderDetailDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<OrderDetail> GetOrdersDetails()
        {
            List<OrderDetail> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from OrderDetails";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<OrderDetail>();

                            OrderDetail orderDetails = new OrderDetail();

                            orderDetails.OrderDetailsID = (int)dr["idOrderDetails"];
                            orderDetails.MenuID = (int)dr["MenuID"];
                            orderDetails.OrderID = (int)dr["OrderID"];
                            if (dr["UnitPrice"] != null)
                                orderDetails.UnitPrice = (int)dr["UnitPrice"];

                            if (dr["Quantity"] != null)
                                orderDetails.Quantity = (int)dr["Quantity"];

                            orderDetails.Discount = (short)dr["Discount"];

                            orderDetails.TotalAmount = (int)dr["TotalAmount"];

                            results.Add(orderDetails);
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
        //Method to get all orderdetails for one order
        public List<OrderDetail> GetOrdersDetailsByOrder(int OrderID)
        {
            List<OrderDetail> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from OrderDetails WHERE OrderID = @OrderID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<OrderDetail>();

                            OrderDetail orderDetails = new OrderDetail();

                            orderDetails.OrderDetailsID = (int)dr["idOrderDetails"];
                            orderDetails.MenuID = (int)dr["MenuID"];
                            orderDetails.OrderID = (int)dr["OrderID"];
                            if (dr["UnitPrice"] != null)
                                orderDetails.UnitPrice = (int)dr["UnitPrice"];

                            if (dr["Quantity"] != null)
                                orderDetails.Quantity = (int)dr["Quantity"];

                            orderDetails.Discount = (short)dr["Discount"];

                            orderDetails.TotalAmount = (int)dr["TotalAmount"];

                            results.Add(orderDetails);
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

        //Method to get all orderdetails for one menu
        public List<OrderDetail> GetOrdersDetailsByMenu(int MenuID)
        {
            List<OrderDetail> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from OrderDetails WHERE MenuID = @MenuID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@MenuID", MenuID);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<OrderDetail>();

                            OrderDetail orderDetails = new OrderDetail();

                            orderDetails.OrderDetailsID = (int)dr["idOrderDetails"];
                            orderDetails.MenuID = (int)dr["MenuID"];
                            orderDetails.OrderID = (int)dr["OrderID"];
                            if (dr["UnitPrice"] != null)
                                orderDetails.UnitPrice = (int)dr["UnitPrice"];

                            if (dr["Quantity"] != null)
                                orderDetails.Quantity = (int)dr["Quantity"];

                            orderDetails.Discount = (short)dr["Discount"];

                            orderDetails.TotalAmount = (int)dr["TotalAmount"];

                            results.Add(orderDetails);
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

        //Method to get one order with his ID 
        public OrderDetail GetOrderDetailWithID(int OrderDetailsID)
        {
            OrderDetail result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from OrderDetails WHERE OrderDetailsID=@OrderDetailsID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderDetailsID", OrderDetailsID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new OrderDetail();

                            result.OrderDetailsID = (int)dr["OrderDetailsID"];

                            if (dr["UnitPrice"] != null)
                                result.UnitPrice = (int)dr["UnitPrice"];

                            if (dr["Quantity"] != null)
                                result.Quantity = (int)dr["Quantity"];

                            result.Discount = (short)dr["Discount"];

                            result.TotalAmount = (int)dr["TotalAmount"];
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

        //Method to get one order with his OrderID 
        public OrderDetail GetOrderDetailWithOrderID(int OrderID)
        {
            OrderDetail result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from OrderDetails WHERE OrderID=@OrderID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new OrderDetail();

                            result.OrderDetailsID = (int)dr["OrderDetailsID"];

                            if (dr["UnitPrice"] != null)
                                result.UnitPrice = (int)dr["UnitPrice"];

                            if (dr["Quantity"] != null)
                                result.Quantity = (int)dr["Quantity"];

                            result.Discount = (short)dr["Discount"];

                            result.TotalAmount = (int)dr["TotalAmount"];
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

        //Method to get one order with his MenuID 
        public OrderDetail GetOrderDetailWithMenuID(int MenuID)
        {
            OrderDetail result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from OrderDetails WHERE MenuID=@MenuID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@MenuID", MenuID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new OrderDetail();

                            result.OrderDetailsID = (int)dr["OrderDetailsID"];

                            if (dr["UnitPrice"] != null)
                                result.UnitPrice = (int)dr["UnitPrice"];

                            if (dr["Quantity"] != null)
                                result.Quantity = (int)dr["Quantity"];

                            result.Discount = (short)dr["Discount"];

                            result.TotalAmount = (int)dr["TotalAmount"];
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
        public OrderDetail AddOrderDetails(OrderDetail orderDetails)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into OrderDetails(UnitPrice, Quantity, Discount, TotalAmount) values(@UnitPrice, @Quantity, @Discount, @TotalAmount); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@UnitPrice", orderDetails.UnitPrice);
                    cmd.Parameters.AddWithValue("@Quantity", orderDetails.Quantity);
                    cmd.Parameters.AddWithValue("@Discount", orderDetails.Discount);
                    cmd.Parameters.AddWithValue("@TotalAmount", orderDetails.TotalAmount);

                    cn.Open();

                    orderDetails.OrderDetailsID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return orderDetails;
        }

        //Method to update one orderdetail in the database
        public OrderDetail UpdateOrderDetails(OrderDetail orderDetails)
        {
            var result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from OrderDetails SET UnitPrice = @UnitPrice, Quantity = @Quantity, Discount = @Discount, TotalAmount = @TotalAmount WHERE OrderDetailsID = @OrderDetailsID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderDetailsID", orderDetails.OrderDetailsID);

                    cmd.Parameters.AddWithValue("@UnitPrice", orderDetails.UnitPrice);
                    cmd.Parameters.AddWithValue("@Quantity", orderDetails.Quantity);
                    cmd.Parameters.AddWithValue("@Discount", orderDetails.Discount);
                    cmd.Parameters.AddWithValue("@TotalAmount", orderDetails.TotalAmount);

                    cn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return orderDetails;
        }


        //Method to delete one order details in the database
        public void DeleteOrderDetails(int orderDetails)
        {
            var result = 0;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from OrderDetails WHERE OrderDetailsID = @OrderdetailsID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderDetailsID", orderDetails);

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