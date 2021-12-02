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
                    string query = "Select * from Locations";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Location>();

                            Location location = new Location();

                            location.LocationID = (int)dr["LocationID"];
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

        public Location GetLocationWithZIP(int ZIP)
        {
            Location location = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Locations where ZIP = @ZIP";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ZIP", ZIP);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            location = new Location();

                            location.LocationID = (int)dr["LocationID"];

                            if (dr["ZIP"] != null)
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


        public Location GetLocationWithID(int LocationID)
        {
            Location location = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Locations where LocationID = @LocationID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@LocationID", LocationID);
                  

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            location = new Location();

                            location.LocationID = (int)dr["LocationID"];

                            if (dr["NameCity"] != null)
                                location.NameCity = (string)dr["NameCity"];

                            ;
                            if (dr["ZIP"] != null)
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

        public int GetLocationWithName(string NameCity)
        {
            Location location = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Locations where NameCity = @NameCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameCity", NameCity);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            location = new Location();

                            location.LocationID = (int)dr["LocationID"];

                            if (dr["NameCity"] != null)
                                location.NameCity = (string)dr["NameCity"];

                            ;
                            if (dr["ZIP"] != null)
                                location.ZIP = (int)dr["ZIP"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return location.LocationID;
        }

        public Location UpdateLocation(Location location)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Locations SET NameCity = @NameCity WHERE LocationID = @LocationID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameCity", location.NameCity);
                    cmd.Parameters.AddWithValue("@ZIP", location.ZIP);

                    cn.Open();
                    result = cmd.ExecuteNonQuery();


                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return location;
        }

        public Location AddLocation(Location location)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Locations(NameCity, ZIP) values(@NameCity, @ZIP); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@NameCity", location.NameCity);
                    cmd.Parameters.AddWithValue("@firstname", location.ZIP);


                    cn.Open();

                    location.LocationID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return location;
        }

        public void DeleteLocation(int LocationID)
        {
            int result = 0; 
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Locations WHERE LocationID = @LocationID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@LocationID", LocationID);
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

