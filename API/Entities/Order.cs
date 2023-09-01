namespace API.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Package Package { get; set; }
        public string Courier { get; set; }
        public DateTime OrderDate { get; set; }
    }
}