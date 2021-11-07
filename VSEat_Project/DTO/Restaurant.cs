using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Restaurant
    {
        //PK
        public int RestaurantID { get; set; }
        //FK
        public int LocationID { get; set; }
        public string RestaurantName { get; set; }
        public string DescriptionRestaurant { get; set; }
        public string Address { get; set; }

        public Restaurant()
        {

        }
        public Restaurant(string restauName, string description, string address, int locationId)
        {
            RestaurantName = restauName;
            DescriptionRestaurant = description;
            Address = address;
            LocationID= locationId; 
        }

        public override string ToString()
        {
            return "Id Restaurant : " + RestaurantID +
                "Id Location : " + LocationID +
                "Name Restaurant : " + RestaurantName +
                "DescriptionRestaurant : " + DescriptionRestaurant+
                "Address : "+Address;
        }
    }
    
}
