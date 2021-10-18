using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
        public class Deliverer
    {
        public int IdDeliverer { get; set; }
        public int AvailabilityDeliverer { get; set; } // maybe a boolean ??
        public DateTime TimeAssigned { get; set; }

        public override string ToString()
        {
            return "IdDeliverer " + IdDeliverer +
                    "AvailabilityDeliverer " + AvailabilityDeliverer +
                    "TimeAssigned " + TimeAssigned;
        }
    }


}
