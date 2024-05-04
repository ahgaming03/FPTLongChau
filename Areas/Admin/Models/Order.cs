using FPTLongChau.Models;

namespace FPTLongChau.Areas.Admin.Models
{
	public class Order
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public DateTime Time { get; set; } = DateTime.Now;
		public virtual ApplicationUser Customer { get; set; }
		public List<OrderDetail>? OrderDetails { get; set; }
		public ShipMode ShipMode { get; set; }
		public DeliveryInformation DeliveryInformation { get; set; }
		public PayMode PayMode { get; set; }
	}
}
