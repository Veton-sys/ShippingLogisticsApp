using API.Entities;

namespace API.DTOs
{
    public class OrderDto
    {
        public PackageDto PackageDto { get; set; }
        public string Courier { get; set; }
        public DateTime OrderDate { get; set; }
        
    }
}