using FPTLongChau.Models;
using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Areas.Admin.Models
{
	public class Rank
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		[Required]
		public string Title { get; set; }
		public string? Description { get; set; }
		[Display(Name = "Image")]
		public string? Image { get; set; }
		public List<ApplicationUser>? Customers { get; set; }
	}
}
