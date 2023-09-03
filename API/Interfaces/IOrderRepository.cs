using API.Data;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IOrderRepository
    {
        Task<ServiceResponse<bool>> MakeOrder(Order order);
    }
}