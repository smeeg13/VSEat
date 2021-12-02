using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDelivererManager
    {
        Deliverer AddDeliverer(Deliverer deliverer);
        void CheckCity(int DelivererID, int RestaurantID);
        void DeleteDeliverer(int DelivererID);
        void DeliveryPerMinutes(int NumberOrdersAssigned, Order order);
        void DeliveryValidation(Order order, Deliverer deliverer);
        Deliverer GetDeliverer(int DelivererID);
        List<Deliverer> GetDeliverers();
        Deliverer UpdateDeliverer(Deliverer deliverer);
    }
}