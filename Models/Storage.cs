using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Models
{
    public class Storage
    {
        public string Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public List<Product> Products { get; set; }

    }
}
