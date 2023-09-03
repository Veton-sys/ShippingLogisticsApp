using API.Couriers;

namespace API.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Package Package { get; set; }
        public string CourierName { get; set; }
        public double CourierPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}