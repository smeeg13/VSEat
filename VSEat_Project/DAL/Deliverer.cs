using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
        public class Deliverer : User
    {
        private int IdDeliverer { get; set; }
        private int AvailabilityDeliverer { get; set; } // maybe a boolean ??
        private DateTime TimeAssigned { get; set; }



        public Deliverer(int idDeliverer, int availabilityDeliverer, DateTime timeAssigned) : base(idUser, lastname, firstname, birthDate, phoneNumber, email, address, username, password, status_Account, isAdmin)
        {
            this.IdDeliverer = idDeliverer;
            this.AvailabilityDeliverer = availabilityDeliverer;
            this.TimeAssigned = timeAssigned;
        }


    }


}
