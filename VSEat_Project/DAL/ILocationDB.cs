using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ILocationDB
    {
        List<Location> GetLocations();
        Location GetLocationWithID(int LocationID);
        Location GetLocationWithZIP(int ZIP);
        int GetLocationWithName(string NameCity);
        Location AddLocation(Location location);
        void DeleteLocation(int LocationID);
        Location UpdateLocation(Location location);

    }
}
