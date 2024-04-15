using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Areas.Admin.Models
{
    public class DeliveryInformation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
