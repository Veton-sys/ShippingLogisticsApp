using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public void MakeOrder(OrderDto orderDto)
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
                Courier = orderDto.Courier
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}