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
                    string query = "Select * from Deliverers";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Deliverer>();

                            Deliverer deliverer = new Deliverer();

                            deliverer.DelivererID = (int)dr["DelivererID"];

                            if (dr["Username"] != null)
                                deliverer.Username = (string)dr["Username"];

                            if (dr["Password"] != null)
                                deliverer.Password = (string)dr["Password"];

                            deliverer.Availability = (int)dr["Availability"];

                            deliverer.NumberOrdersAssigned = (int)dr["NumberOrdersAssigned"];
                            deliverer.LocationID = (int)dr["LocationID"];

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

        public Deliverer GetDeliverer(int DelivererID)
        {
            Deliverer deliverer = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Deliverers where DelivererID = @DelivererID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DelivererID", DelivererID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            deliverer = new Deliverer();

                            deliverer.DelivererID = (int)dr["IdDeliverer"];

                            if (dr["AvailabitlityDeliverer"] != null)
                                deliverer.Availability = (int)dr["Availabitlity"];

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

        public Deliverer UpdateDeliverer(Deliverer deliverer)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Deliverer SET Availability = @Availibility, Username=@Username, Password=@Password, NumberOrdersAssigned=@NumberOrdersAssigned,LocationID=@LocationID WHERE IdDeliverer = @IdDeliverer";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Username", deliverer.Username);
                    cmd.Parameters.AddWithValue("@Password", deliverer.Password);
                    cmd.Parameters.AddWithValue("@NumberOrdersAssgined", deliverer.NumberOrdersAssigned);
                    cmd.Parameters.AddWithValue("@Availibility", deliverer.Availability);
                    cmd.Parameters.AddWithValue("@LocationID", deliverer.LocationID);

                    cn.Open();
                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliverer;
        }

        public Deliverer AddDeliverer(Deliverer deliverer)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Deliverers (Username, Password, NumberOrdersAssigned, Availability) values(@Username, @Password, @NumberOrdersAssigned, @Availability); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Username", deliverer.Username);
                    cmd.Parameters.AddWithValue("@Password", deliverer.Password);
                    cmd.Parameters.AddWithValue("@NumberOrdersAssigned", deliverer.NumberOrdersAssigned);
                    cmd.Parameters.AddWithValue("@Availability", deliverer.Availability);
                    cmd.Parameters.AddWithValue("@LocationID", deliverer.Availability);

                    cn.Open();

                    deliverer.DelivererID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliverer;
        }

        public void DeleteDeliverer(int DelivererID)
        {
            int result = 0; 

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Deliverers WHERE DelivererID = @DelivererID ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DelivererID", DelivererID);
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
    
