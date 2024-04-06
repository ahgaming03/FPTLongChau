using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        [Required]
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public ShipMode ShipMode { get; set; }
        public DeliveryInformation DeliveryInformation { get; set; }
        public PayMode PayMode { get; set; }
    }
}
