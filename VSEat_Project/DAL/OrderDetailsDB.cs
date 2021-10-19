using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDetailsDB : IOrderDetailsDB
    {
        private IConfiguration Configuration { get; }

        public OrderDetailsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<OrderDetails> GetOrdersDetails()
        {
            List<OrderDetails> results = null;
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
                                results = new List<OrderDetails>();

                            OrderDetails orderDetails = new OrderDetails();

                            orderDetails.IdOrderDetails = (int)dr["idOrderDetails"];

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

        public OrderDetails GetOrderDetails(int idOrderDetails, int TotalAmount)
        {
            OrderDetails result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from OrderDetails WHERE idOrderDetails=@idOrderDetails AND TotalAmount=@TotalAmount";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idOrderDetails", idOrderDetails);
                    cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {


                            result = new OrderDetails();

                            result.IdOrderDetails = (int)dr["idOrder"];

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
        public OrderDetails AddOrderDetails(OrderDetails orderDetails)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into OrderDetails(UnitPrice, Quantity, Discount, Totalamount) values(@unitprice, @quantity, @discount, @totalAmount); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@unitprice", orderDetails.UnitPrice);
                    cmd.Parameters.AddWithValue("@quantity", orderDetails.Quantity);
                    cmd.Parameters.AddWithValue("@discount", orderDetails.Discount);
                    cmd.Parameters.AddWithValue("@totalamount", orderDetails.TotalAmount);


                    cn.Open();

                    orderDetails.IdOrderDetails = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orderDetails;
        }

        //Method to update the quantity of one orderdetail in the database
        public void UpdateOrderDetailsQuantity(OrderDetails orderDetails, string newQuantity)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from OrderDetails SET Quantity = @quantity WHERE IdOrderDetails = @idorderdetails";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@quantity", newQuantity);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //Method to delete one order details in the database
        public void DeleteOrderDetails(OrderDetails orderDetails)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from OrderDetails WHERE IdOrderDetails = @idorderdetails";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idorderdetails", orderDetails.IdOrderDetails);

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