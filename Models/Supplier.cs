using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Models
{
    public class Supplier
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
