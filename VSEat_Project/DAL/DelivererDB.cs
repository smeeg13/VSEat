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

                            deliverer.DelivereID = (int)dr["IdDeliverer"];

                            deliverer.Availability = (int)dr["AvailabilityDeliverer"];

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

                            deliverer.DelivereID = (int)dr["IdDeliverer"];

                            if (dr["AvailabitlityDeliverer"] != null)
                                deliverer.Availability = (int)dr["AvailabitlityDeliverer"];

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
                    string query = "Insert into Deliverer(AvailabilityDeliverer, TimeAssigned) values(@AvailabilityDeliverer, @TimeAssgined); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Availability", deliverer.Availability);
                    cmd.Parameters.AddWithValue("@firstname", deliverer.TimeAssigned);


                    cn.Open();

                    deliverer.DelivereID = Convert.ToInt32(cmd.ExecuteScalar());
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
                    cmd.Parameters.AddWithValue("@IdDeliverer", deliverer.DelivereID);

                    cn.Open();

                    deliverer.DelivereID = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
    
