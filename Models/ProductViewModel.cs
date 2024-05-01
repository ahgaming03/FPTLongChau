using FPTLongChau.Areas.Admin.Models;
namespace FPTLongChau.Models
{
	public class ProductViewModel
	{
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public ProductViewModel(IEnumerable<Product> products, IEnumerable<Category> categories)
		{
			Products = products;
			Categories = categories;
		}
	}
}
