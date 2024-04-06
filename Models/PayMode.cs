using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Models
{
    public class PayMode
    {
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Order> Orders { get; set; }
    }
}
