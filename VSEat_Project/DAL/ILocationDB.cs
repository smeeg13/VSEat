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
        Location GetLocation(string NameCity, int ZIP);
        Location AddLocation(Location location);
        void DeleteLocation(Location location);
        void UpdateLocation(string NameCity, int ZIP);

    }
}
