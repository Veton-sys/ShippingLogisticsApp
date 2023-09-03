using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        public Package Package { get; set; }
        public string CourierName { get; set; }
        public double CourierPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}