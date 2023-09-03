using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}