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

        public List<Deliverer> GetDeliverer()
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

        public List<Deliverer> GetDeliverers()
        {
            throw new NotImplementedException();
        }

        public Order GetDeliverer(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void AddDeliverer(Deliverer deliverer)
        {
            throw new NotImplementedException();
        }

        public void DeleteDeliverer(int id)
        {
            throw new NotImplementedException();
        }

        Deliverer IDelivererDB.GetDeliverer(string email, string password)
        {
            throw new NotImplementedException();
        }

        Deliverer IDelivererDB.AddDeliverer(Deliverer deliverer)
        {
            throw new NotImplementedException();
        }

        public void DeleteDeliverer(Deliverer deliverer)
        {
            throw new NotImplementedException();
        }

        public void UpdateDeliverer(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
    
