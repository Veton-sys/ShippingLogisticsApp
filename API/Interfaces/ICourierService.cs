using API.Couriers;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICourierService
    {
        List<Courier> GetCourierPrices(PackageDto packageDto);
        void MakeOrder(OrderDto orderDto);
    }
}