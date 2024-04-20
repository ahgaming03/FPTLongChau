using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Areas.Admin.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(256)]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Description { get; set; }
        [Required]
        [Display(Name ="Category")]
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public List<Storage>? Storages { get; set; }
        public List<Unit>? Units { get; set; }
    }
}
