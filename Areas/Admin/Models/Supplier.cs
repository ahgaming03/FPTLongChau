using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Areas.Admin.Models
{
	public class Supplier
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		[Required]
		public string Name { get; set; }
		public string? Description { get; set; }
		public List<Storage>? Storages { get; set; }
	}
}
