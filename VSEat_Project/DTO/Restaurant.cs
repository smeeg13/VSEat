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
        public int IdRestaurant { get; set; }
        //FK
        public int IdCity { get; set; }
        public int IdMenu { get; set; }
        public string NameRestaurant { get; set; }
        public string DescriptionRestaurant { get; set; }
        public string AddressRestaurant { get; set; }

        public override string ToString()
        {
            return "Id Restaurant : " + IdRestaurant +
                "IdCity : " + IdCity +
                "IdMenu : " + IdMenu +
                "NameRestaurant : " + NameRestaurant +
                "DescriptionRestaurant : " + DescriptionRestaurant;
        }
    }
    
}
