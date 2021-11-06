using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LocationManager
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

        public Location GetLocation(string NameCity, int ZIP)
        {
            return LocationDb.GetLocation(NameCity,ZIP);
        }

        public List<Location> GetLocations()
        {
            return LocationDb.GetLocations();
        }

        public void UpdateLocation(string NameCity, int ZIP)
        {
            LocationDb.UpdateLocation(NameCity, ZIP);
        }
    }
}
