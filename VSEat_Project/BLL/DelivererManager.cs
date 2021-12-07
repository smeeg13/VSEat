﻿using BLL.Interfaces;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using VSEat_Project;

namespace BLL
{
    public class DelivererManager : IDelivererManager
    {
        private IDelivererDB DelivererDb { get; }
        private IRestaurantDB RestaurantDb { get; }


        public DelivererManager(IDelivererDB DelivererDb, IRestaurantDB RestaurantDb)
        {
            this.DelivererDb = DelivererDb;
            this.RestaurantDb = RestaurantDb;
        }

        public Deliverer AddDeliverer(Deliverer deliverer)
        {
            return DelivererDb.AddDeliverer(deliverer);
        }

        public void DeleteDeliverer(int DelivererID)
        {
            DelivererDb.DeleteDeliverer(DelivererID);
        }

        public Deliverer GetDelivererWithID(int DelivererID)
        {
            return DelivererDb.GetDelivererWithID(DelivererID);
        }

        public List<Deliverer> GetDeliverers()
        {
            return DelivererDb.GetDeliverers();
        }

        public Deliverer UpdateDeliverer(Deliverer deliverer)
        {
            return DelivererDb.UpdateDeliverer(deliverer);
        }

        public void DeliveryPerMinutes(int NumberOrdersAssigned, Order order) //requiredDate
        {
            string available = null;

            //current date must be at least 3 hours before shipped Date
            var diffOfDates = order.RequiredDate - DateTime.Now; //get difference of two dates
            Console.WriteLine("Difference in Hours: {0}", diffOfDates.Hours);

          //  if (NumberOrdersAssigned < 5 && diffOfDates < 30)
           // {
              //  available = "yes";
          //  }

            // si NumberOrdersAssigned < 5 pour 30 minutes = Ok
            // string available = yes;
            //or
            // BusinessExceptions
        }
        public void DeliveryValidation(Order order, Deliverer deliverer)
        {
            // if string available = yes 
            // sout the deliverer is available
            // or business exceptions

        }
        public void CheckCity(int DelivererID, int RestaurantID)
        {
            int delivererID;
            int restaurantID;

            Deliverer deliverer = DelivererDb.GetDeliverer(DelivererID);
            delivererID = deliverer.DelivererID;

            Restaurant restaurant = RestaurantDb.GetRestaurantWithID(RestaurantID);
            restaurantID = restaurant.RestaurantID;

            if (deliverer.DelivererID == restaurant.RestaurantID)
                Console.WriteLine("The deliverer work in this city");
            else
                throw new BusinessExceptions("You must choose another deliverer !");

        }
    }
}
