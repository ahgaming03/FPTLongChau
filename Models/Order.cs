namespace FPTLongChau.Models
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime Time { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public ShipMode ShipMode { get; set; }
        public DeliveryInformation DeliveryInformation { get; set; }
        public PayMode PayMode { get; set; }


    }
}
