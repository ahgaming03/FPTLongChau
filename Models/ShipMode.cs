namespace FPTLongChau.Models
{
    public class ShipMode
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Order> Orders { get; set; }

    }
}
