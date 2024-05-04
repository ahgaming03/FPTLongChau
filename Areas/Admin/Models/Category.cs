using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Areas.Admin.Models
{
	public class Category
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		[Required]
		public string Title { get; set; }
		public string? Description { get; set; }
		public List<Product>? Products { get; set; }
	}
}
