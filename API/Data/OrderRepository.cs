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
        public async Task<ServiceResponse<bool>> MakeOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>{ Data = true };
        }
    }
}