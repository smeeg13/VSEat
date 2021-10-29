﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface IDelivererDB
    {
        List<Deliverer> GetDeliverers();
        Deliverer GetDeliverer(int AvailabilityDeliverer, DateTime TimeAssigned);
        Deliverer AddDeliverer(Deliverer deliverer);
        void DeleteDeliverer(Deliverer deliverer);
        void UpdateDelivererAvailability(Deliverer deliverer, int AvailabilityDeliverer);
    }
}