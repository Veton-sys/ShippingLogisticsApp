using API.Data;
using API.DTOs;

namespace API.Interfaces
{
    public interface IOrderRepository
    {
        void MakeOrder(OrderDto orderDto);
    }
}