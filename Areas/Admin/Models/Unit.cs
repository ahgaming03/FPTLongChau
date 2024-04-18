using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Areas.Admin.Models
{
    public class Unit
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Title { get; set; }
        [Display(Name = "Desc")]
        public string? Description { get; set; }
        public List<Product>? Products { get; set; }
    }
}
