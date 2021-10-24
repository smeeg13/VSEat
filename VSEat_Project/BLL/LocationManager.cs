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

        public Deliverer AddDeliverer(Location location)
        {
            return LocationDb.AddLocation(location);
        }

        public void DeleteDeliverer(Location location)
        {
            LocationDb.DeleteLocation(location);
        }

        public Deliverer GetDeliverer(string NameCity, int ZIP)
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
