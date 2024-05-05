using FPTLongChau.Models;

namespace FPTLongChau.Areas.Admin.Models
{
	public class Order
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public DateTime Time { get; set; } = DateTime.Now;
		public int Status { get; set; } = 0;
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public Guid PayModeId { get; set; }
		public virtual ApplicationUser? Customer { get; set; }
		public List<OrderDetail>? OrderDetails { get; set; }
		public PayMode? PayMode { get; set; }
	}
}
