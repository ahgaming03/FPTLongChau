using FPTLongChau.Areas.Admin.Models;
namespace FPTLongChau.Models
{
	public class ProductViewModel
	{
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public string SearchString { get; set; }

        public ProductViewModel(IEnumerable<Product> products, IEnumerable<Category> categories)
		{
			Products = products;
			Categories = categories;
		}

        public ProductViewModel(IEnumerable<Product> products,IEnumerable<Category> categories, String searchString)
        {
            Products = products;
			Categories = categories;
			SearchString = searchString;
        }
    }
}
