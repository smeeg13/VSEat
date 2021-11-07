﻿using System;
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
        Location GetLocationWithID(int LocationID);
        Location GetLocationWithZIP(int ZIP);
        int GetLocationWithName(string NameCity);
        Location AddLocation(Location location);
        void DeleteLocation(int LocationID);
        void UpdateLocation(string NameCity, int ZIP);

    }
}
