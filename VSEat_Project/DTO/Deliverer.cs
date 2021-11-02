using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
        public class Deliverer
    {
        //PK
        public int IdDeliverer { get; set; }
        //FK 
        public int IdOrder { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public int NumberOrdersAssigned { get; set; }
        public int AvailabilityDeliverer { get; set; } 
        public DateTime TimeAssigned { get; set; }

        public override string ToString()
        {
            return "IdDeliverer " + IdDeliverer +
                    "AvailabilityDeliverer " + AvailabilityDeliverer +
                    "TimeAssigned " + TimeAssigned;
        }
    }


}
