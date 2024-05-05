using FPTLongChau.Areas.Admin.Models;

namespace FPTLongChau.Models
{
	public class CartItemViewModel : Product
	{
		public int Quantity { get; set; }
		public int Stock { get; set; }
		public double TotalPrice { get; set; }
	}
}
