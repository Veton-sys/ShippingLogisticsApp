using API.Couriers;

namespace API.DTOs
{
    public class OrderDto
    {
        public PackageDto PackageDto { get; set; }
        public string CourierName { get; set; }
        public double CourierPrice { get; set; }
        public DateTime OrderDate { get; set; }
        
    }
}