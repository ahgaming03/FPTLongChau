using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Areas.Admin.Models
{
    public class Storage
    {
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;

    }
}
