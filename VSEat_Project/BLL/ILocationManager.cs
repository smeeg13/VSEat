using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface ILocationManager
    {
        Location AddLocation(Location location);
        void DeleteDeliverer(int LocationID);
        List<Location> GetLocations();
        Location GetLocationWithID(int LocationID);
        int GetLocationWithName(string NameCity);
        Location UpdateLocation(Location location);
    }
}