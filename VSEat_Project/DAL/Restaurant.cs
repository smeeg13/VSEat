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
        private int IdRestaurant { get; set; }
        //FK
        public int IdCity { get; set; }

        private string Name_Restaurant { get; set; }
        private string Description_Restaurant { get; set; }
        private string Contact { get; set; }
        private string Address_Restaurant { get; set; }

        
    }
}
