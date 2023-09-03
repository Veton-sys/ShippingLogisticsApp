using API.Couriers;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICourierService
    {
        bool CheckPackageInformation(PackageDto packageDto);
        ServiceResponse<List<Courier>> GetCourierPrices(PackageDto packageDto);
        Task<ServiceResponse<bool>> MakeOrder(OrderDto orderDto);
    }
}