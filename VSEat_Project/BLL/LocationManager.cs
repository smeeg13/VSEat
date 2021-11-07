using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LocationManager : ILocationManager
    {
        private ILocationDB LocationDb { get; }


        public LocationManager(IConfiguration conf)
        {
            LocationDb = new LocationDB(conf);
        }

        public Location AddLocation(Location location)
        {
            return LocationDb.AddLocation(location);
        }

        public void DeleteDeliverer(int LocationID)
        {
            LocationDb.DeleteLocation(LocationID);
        }


        public Location GetLocationWithID(int LocationID)
        {
            return LocationDb.GetLocationWithID(LocationID);
        }

        public int GetLocationWithName(string NameCity)
        {
            return LocationDb.GetLocationWithName(NameCity);
        }

        public List<Location> GetLocations()
        {
            return LocationDb.GetLocations();
        }

        public void UpdateLocation(Location location)
        {
            LocationDb.UpdateLocation(location);
        }
    }
}
