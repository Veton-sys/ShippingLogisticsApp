using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Couriers;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Services
{
    public class CourierService : ICourierService
    {
        List<Courier> Couriers;
        private readonly IOrderRepository _orderRepository;

        public CourierService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            Couriers = new List<Courier>
            {
                new Cargo4You("Cargo4You"),
                new ShipFaster("ShipFaster"),
                new MaltaShip("MaltaShip")
            };
        }


        public List<Courier> GetCourierPrices(PackageDto packageDto)
        {
            List<Courier> couriers = new();

            foreach (Courier c in Couriers)
            {
                if (c.ValidateDimension(packageDto) && c.ValidateWeight(packageDto))
                {
                    c.CalculatePrice(packageDto);
                    couriers.Add(c);
                }
            }
            return couriers;
        }

        public void MakeOrder(OrderDto orderDto)
        {
            _orderRepository.MakeOrder(orderDto);
        }
    }
}