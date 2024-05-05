using FPTLongChau.Models;

namespace FPTLongChau.Areas.Admin.Models
{
	public class Order
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public DateTime Time { get; set; } = DateTime.Now;
		public int Status { get; set; } = 0;
        public virtual ApplicationUser Customer { get; set; }
		public List<OrderDetail>? OrderDetails { get; set; }
		public PayMode PayMode { get; set; }
	}
}
