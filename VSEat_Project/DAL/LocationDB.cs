using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LocationDB : ILocationDB
    {
        private IConfiguration Configuration { get; }

        public LocationDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Location> GetLocations()
        {
            List<Location> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Location";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Location>();

                            Location location = new Location();

                            location.IdCity = (int)dr["IdCity"];
                            location.ZIP = (int)dr["ZIP"];

                            if (dr["NameCity"] != null)
                                location.NameCity = (string)dr["NameCity"];

                            results.Add(location);
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

        public Location GetLocation(string NameCity, int ZIP)
        {
            Location location = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Location where NameCity = @NameCity AND ZIP = @ZIP";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameCity", NameCity);
                    cmd.Parameters.AddWithValue("@ZIP", ZIP);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            location = new Location();

                            location.IdCity = (int)dr["IdCity"];

                            if (dr["PriceMenu"] != null)
                                location.ZIP = (int)dr["ZIP"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return location;
        }

        public void UpdateLocation(string NameCity, int ZIP)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Location SET NameCity = @NameCity WHERE IdCity = @IdCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameCity", NameCity);
                    cmd.Parameters.AddWithValue("@ZIP", ZIP);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Location AddLocation(Location location)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Location(NameCity, ZIP) values(@NameCity, @ZIP); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameCity", location.NameCity);
                    cmd.Parameters.AddWithValue("@firstname", location.ZIP);


                    cn.Open();

                    location.IdCity = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return location;
        }

        public void DeleteLocation(Location location)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Location WHERE IdCity = @IdCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdCity", location.IdCity);

                    cn.Open();

                    location.IdCity = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

