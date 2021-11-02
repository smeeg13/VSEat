﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DelivererDB : IDelivererDB
    {
        private IConfiguration Configuration { get; }

        public DelivererDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Deliverer> GetDeliverers()
        {
            List<Deliverer> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Deliverer";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Deliverer>();

                            Deliverer deliverer = new Deliverer();

                            deliverer.IdDeliverer = (int)dr["IdDeliverer"];

                            deliverer.AvailabilityDeliverer = (int)dr["AvailabilityDeliverer"];

                            results.Add(deliverer);
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

        public Deliverer GetDeliverer(int AvailabilityDeliverer, DateTime TimeAssigned)
        {
            Deliverer deliverer = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Deliverer where AvailabilityDeliverer = @AvailabilityDeliverer AND TimeAssigned = @TimeAssigned";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@AvailabilityDeliverer", AvailabilityDeliverer);
                    cmd.Parameters.AddWithValue("@TimeAssigned", TimeAssigned);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            deliverer = new Deliverer();

                            deliverer.IdDeliverer = (int)dr["IdDeliverer"];

                            if (dr["AvailabitlityDeliverer"] != null)
                                deliverer.AvailabilityDeliverer = (int)dr["AvailabitlityDeliverer"];

                            if (dr["TimeAssigned"] != null)
                                deliverer.TimeAssigned = (DateTime)dr["TimeAssigned"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliverer;
        }

        public void UpdateDelivererAvailability(Deliverer deliverer, int AvailabilityDeliverer)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Deliverer SET AvailabilityDeliverer = @AvailibilityDeliverer WHERE IdDeliverer = @IdDeliverer";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@AvailibilityDeliverer", AvailabilityDeliverer);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Deliverer AddDeliverer(Deliverer deliverer)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Deliverer(Username, Password, NumberOrdersAssigned, AvailabilityDeliverer, TimeAssigned) values(@Username, @Password, @NumberOrdersAssigned, @AvailabilityDeliverer, @TimeAssgined); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Username", deliverer.Username);
                    cmd.Parameters.AddWithValue("@Password", deliverer.Password);
                    cmd.Parameters.AddWithValue("NumberOrdersAssigned", deliverer.NumberOrdersAssigned);
                    cmd.Parameters.AddWithValue("@Availability", deliverer.AvailabilityDeliverer);
                    cmd.Parameters.AddWithValue("@TimeAssigned", deliverer.TimeAssigned);

                    cn.Open();

                    deliverer.IdDeliverer = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliverer;
        }

        public void DeleteDeliverer(Deliverer deliverer)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Deliverer WHERE IdDeliverer = @IdDeliverer ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.RemoveAt("@Username");
                    cmd.Parameters.RemoveAt("@Password");
                    cmd.Parameters.RemoveAt("NumberOrdersAssigned");
                    cmd.Parameters.RemoveAt("@Availability");
                    cmd.Parameters.RemoveAt("@TimeAssigned");

                    cn.Open();

                  //  deliverer.IdDeliverer = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CheckCity (Deliverer deliverer, Restaurant restaurant)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "";
                    SqlCommand cmd = new SqlCommand(query, cn);

                }
            }

        }

        public void DeliveryPerMinutes(int NumberOrdersAssigned, Order order) //requiredDate
        {
           
        }

        public void DeliveryValidation (int )
    }
}
    
