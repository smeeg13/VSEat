using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
        public class LocationDB
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
                        string query = "Select * from Deliverer where AvailabilityDeliverer = @AvailabilityDeliverer AND TimeAssigned = @TimeAssigned";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@AvailabilityDeliverer", AvailabilityDeliverer);
                        cmd.Parameters.AddWithValue("@TimeAssigned", TimeAssigned);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                location = new Location();

                                location.IdCity = (int)dr["IdCity"];

                                if (dr["PriceMenu"] != null)
                                    menu.PriceMenu = (int)dr["PriceMenu"];

                                if (dr["NameMenu"] != null)
                                    menu.NameMenu = (string)dr["NameMenu"];

                                if (dr["ImageMenu"] != null)
                                    menu.ImageMenu = (int)dr["ImageMenu"];

                                if (dr["IngredientsMenu"] != null)
                                    menu.IngredientsMenu = (string)dr["IngredientsMenu"];

                                if (dr["StatusMenu"] != null)
                                    menu.StatusMenu = (string)dr["StatusMenu"];

                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return menu;
            }
        }
    }

