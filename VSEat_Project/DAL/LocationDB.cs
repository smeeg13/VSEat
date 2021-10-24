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

            public List<Location> GetLocation()
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

            public Location GetLocation(int IdCity, string NameCity, int ZIP)
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

        public List<Location> GetLocations()
        {
            throw new NotImplementedException();
        }

        Deliverer ILocationDB.GetLocation(string NameCity, int ZIP)
        {
            throw new NotImplementedException();
        }

        Deliverer ILocationDB.AddLocation(Location location)
        {
            throw new NotImplementedException();
        }

        void ILocationDB.DeleteLocation(Location location)
        {
            throw new NotImplementedException();
        }

        void ILocationDB.UpdateLocation(string NameCity, int ZIP)
        {
            throw new NotImplementedException();
        }
    }
    }

