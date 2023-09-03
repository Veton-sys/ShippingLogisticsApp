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


        public ServiceResponse<List<Courier>> GetCourierPrices(PackageDto packageDto)
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
            return new ServiceResponse<List<Courier>>{ Data = couriers };
        }

        public async Task<ServiceResponse<bool>> MakeOrder(OrderDto orderDto)
        {
             var order = new Order
            {
                Package = new Package
                {
                    Weight = orderDto.PackageDto.Weight,
                    Height = orderDto.PackageDto.Height,
                    Width = orderDto.PackageDto.Width,
                    Depth = orderDto.PackageDto.Depth
                },
                OrderDate = DateTime.Now,
                CourierName = orderDto.CourierName,
                CourierPrice = orderDto.CourierPrice,
            };

            await _orderRepository.MakeOrder(order);
            return new ServiceResponse<bool>{ Data = true, Message = "Order placed successfully" };
        }
    }
}