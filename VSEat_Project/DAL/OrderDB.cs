﻿using Microsoft.Extensions.Configuration;
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
                    string query = "Select * from Order";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.IdOrder = (int)dr["idOrder"];

                            order.DateOrder = (DateTime)dr["DateOrder"];

                            order.DateDelivery = (DateTime)dr["DateDelivery"];

                            order.DeliveryAddress = (string)dr["DeliveryAddress"];

                            order.Fees = (int)dr["Fees"];

                            order.TotalAmount = (int)dr["TotalAmount"];

                            order.StatusOrder = (string)dr["StatusOrder"];

                            order.DeliveryTime = (DateTime)dr["DeliveryTime"];

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
        public Order GetOrder(int IdOrder, int IdCustomer)
        {
            Order result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Order WHERE IdOrder=@IdOrder AND IdCustomer=@IdCustomer";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdOrder", IdOrder);
                    cmd.Parameters.AddWithValue("@IdCustomer", IdCustomer);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {


                            result = new Order();

                            result.IdOrder = (int)dr["IdOrder"];

                            if (dr["DateOrder"] != null)
                                result.DateOrder = (DateTime)dr["DateOrder"];

                            if (dr["DateDelivery"] != null)
                                result.DateDelivery = (DateTime)dr["DateDelivery"];

                            if (dr["DeliveryAddress"] != null)
                                result.DeliveryAddress = (string)dr["DeliveryAddress"];

                            result.Fees = (int)dr["Fees"];

                            result.TotalAmount = (int)dr["TotalAmount"];

                            result.StatusOrder = (string)dr["StatusOrder"];


                            result.DeliveryTime = (DateTime)dr["DeliveryTime"];

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
                    string query = "Insert into Order(IdUser, DateOrder) values(@IdUser, @DateOrder); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdUser", order.IdUser);
                    cmd.Parameters.AddWithValue("@DateOrder", order.DateOrder);

                    cn.Open();

                    order.IdOrder = Convert.ToInt32(cmd.ExecuteScalar());
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
                    string query = "Update from Order SET StatusOrder = @statusorder WHERE IdOrder = @idorder";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@statusorder", newStatus);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //Method to delete one order in the database
        public void DeleteOrder(int IdOrder)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Order WHERE IdOrder = @idorder";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idorder", IdOrder);

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